<%@ Application Language="C#" %>
<%@ Import Namespace="eChat" %>
<%@ Import Namespace="System.Threading " %>
<%@ Import Namespace="System.Data" %>
<script runat="server">

    void Application_BeginRequest(object Sender, EventArgs e)
    {

        string path = HttpContext.Current.Request.Path.ToUpperInvariant();
        string url = HttpContext.Current.Request.RawUrl.ToUpperInvariant();

        if (url.Contains("/CATEGORIA/"))
        {
            string[] parameters = url.Substring(url.IndexOf("/CATEGORIA/") + 1).Split('/');
            string type = parameters[0];
            string categoria = parameters[1];
            string operation = parameters[2];

            if (type.Equals("CATEGORIA") && operation.Contains("CURITIBA"))
            {
                WebService ws = new WebService();
                DataSet dados = new DataSet();
                dados = ws.descricaoCodigoCategoria(categoria);

                HttpContext.Current.RewritePath("~/Categoria.aspx?tipo_categoria=" + dados.Tables[0].Rows[0]["codigo"].ToString());               
            }
        }
        

    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        System.Threading.Timer ChatRoomsCleanerTimer = new System.Threading.Timer(new TimerCallback(ChatEngine.CleanChatRooms), null, 1200000, 1200000);

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
