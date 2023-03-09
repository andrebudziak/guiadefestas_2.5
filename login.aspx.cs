using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class _login : System.Web.UI.Page
{
    private string connstring = ConfigurationManager.AppSettings["ConnectionString"];

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection MyConnection3 = new SqlConnection();
        MyConnection3.ConnectionString = connstring;

        SqlCommand MyCommand3 = new SqlCommand("select descricao,senha from usuario", MyConnection3);

        MyCommand3.Dispose();  //Dispose of the Command object.
        MyConnection3.Close(); //Close the connection.

        SqlCommand MyCommand2 = new SqlCommand("SELECT DESCRICAO,SENHA FROM USUARIO " +
                                  "WHERE ((descricao=@usuario) AND (senha=@senha))", MyConnection3);

        MyCommand2.CommandType = CommandType.Text;
        MyCommand2.Parameters.Add("@usuario", SqlDbType.VarChar).Value = tedUsuario.Text.Trim();
        MyCommand2.Parameters.Add("@senha", SqlDbType.VarChar).Value = tedSenha.Text.Trim();
        MyCommand2.Connection.Open();

        SqlDataReader MyDataReader = MyCommand2.ExecuteReader();

        if (MyDataReader.Read())
        {
            string senha = SenhaHASH(Convert.ToString(DateTime.Now));     
            Response.Redirect("principal.aspx?h=" + senha);
            tedUsuario.Text = "";
            tedSenha.Text = "";

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>alert('Usuario e/ou Senha Invalido(s)! Verifique'); </script>", false);
            tedUsuario.Text = "";
            tedSenha.Text = "";
        }

        MyCommand2.Dispose();  //Dispose of the Command object.
        MyConnection3.Close(); //Close the connection.


    }

    public string SenhaHASH(string Senha)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
    }

}
