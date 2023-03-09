using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.MasterPage
{
    private int vTipoCategoria = 0, ht = 0;
    private string vCategoria = "";
    private WebService ws = new WebService();
    DataTable tabela = new DataTable();
    private DataSet dadosBanner = new DataSet();
    private DataSet dadosBannerTopo = new DataSet();

    private void Page_PreInit(object sender, EventArgs e)
    {
        string appPath = HttpContext.Current.Request.ApplicationPath;

        CssSite.Attributes["href"] = appPath + "/Styles.css";
        imgLogoGuia.ImageUrl = appPath + "/imagens/lgguia213x79.jpg";
        btnBusca.ImageUrl = appPath + "/imagens/PESQUISAR.png";
        btnFechar.ImageUrl = appPath + "/imagens/close.png";

    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        pnChatCli.Visible = false;
        pnChatUsr.Visible = false;

        if (!IsPostBack)
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;

            CssSite.Attributes["href"] = appPath + "/Styles.css";
            imgLogoGuia.ImageUrl = appPath + "/imagens/lgguia213x79.jpg";
            btnBusca.ImageUrl = appPath + "/imagens/PESQUISAR.png";
            btnFechar.ImageUrl = appPath + "/imagens/close.png";

            montaBanner();

            lblCodigo.Visible = false;
            lblCodigoCategoria.Visible = false;
            lblDescricao.Visible = false;
            btnFechar.Attributes.Add("onclick", "imgFI_onmouseout();");

            if (Request.QueryString["tipo_categoria"] != null)
            {
                string codigo = Request.QueryString["tipo_categoria"].ToString();
                DataSet dados = new DataSet();
                dados = ws.descricaoCategoria(codigo);
 
                //btnFechar.PostBackUrl = Page.Request.ApplicationPath.ToString() + "/Categoria/" + dados.Tables[0].Rows[0]["descricao"].ToString() + "/CURITIBA";

                string palavras = "Curitiba,Guia de Festas Curitiba,Festas Curitiba,festas,";

                if (Request.QueryString["c"] == null)
                {
                    lblCodigoCategoria.Text = Request.QueryString["tipo_categoria"].ToString();
                    vTipoCategoria = Convert.ToInt32(Request.QueryString["tipo_categoria"].ToString());
                    lblDescricao.Text = "0";

                }
                else
                {
                    vTipoCategoria = 0;
                    lblCodigoCategoria.Text = "0";
                    lblDescricao.Text = Request.QueryString["c"].ToString();

                }

                ws.Dispose();

                txtValor.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnBusca.UniqueID + "').click();return false;}} else {return true}; ");

            }

        }      
    }

    protected void btnBusca_Click(object sender, ImageClickEventArgs e)
    {
       /* if (txtValor.Text != "")
        {
            Response.Redirect("categoria.aspx?tipo_categoria=0&c=" + txtValor.Text);
        }
        else
        {
            string myScript = @"alert('Digite um conteudo para pesquisa!');";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>" + myScript + "</script>", false);
        }*/

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  
    private DataTable CriaDataTable()
    {

        DataTable mDataTable = new DataTable();

        DataColumn mDataColumn;

        mDataColumn = new DataColumn();
        mDataColumn.DataType = Type.GetType("System.String");
        mDataColumn.ColumnName = "email";
        mDataTable.Columns.Add(mDataColumn);

        mDataColumn = new DataColumn();
        mDataColumn.DataType = Type.GetType("System.String");
        mDataColumn.ColumnName = "usuario";
        mDataTable.Columns.Add(mDataColumn);
        
        return mDataTable;

    }

    private void incluirNoDataTable(string email, string usuario, DataTable mTable)
    {

        DataRow linha;
        linha = mTable.NewRow();

        linha["email"] = email;

        linha["usuario"] = usuario;

        mTable.Rows.Add(linha);

        tabela = mTable;
        HttpContext.Current.Session["dadosT"] = mTable;

    } 
 
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
       /* if (ddlTipoAcesso.SelectedValue == "2")
        {
            Session["UserName"] = txtUsuarioCliente.Text;
            Session["EmailUsuario"] = txtEmailCliente.Text;
        
        }
        string senha = SenhaHASH(Convert.ToString(DateTime.Now));
        Response.Redirect("Chat.aspx?h=" + senha + "&rid=2&tp=" + ddlTipoAcesso.SelectedValue, false);

        UpdatePanel2.Update();*/
    }

    protected void btnMini_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnLoginCliente_Click(object sender, ImageClickEventArgs e)
    {
        /*Service ws = new Service();
        int login = ws.authenticateUser(txtUsuario.Text, txtSenha.Text);
        if (login != 0)
        {
            string nomeUser = ws.NomeUser(txtUsuario.Text, txtSenha.Text);
            Session["UserName"] = nomeUser;
            Session["idCliente"] = login;

            string senha = SenhaHASH(Convert.ToString(DateTime.Now));
            Response.Redirect("Chat.aspx?h="+senha+"&rid=2&tp=" + ddlTipoAcesso.SelectedValue, false);
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>alert('Usuario e/ou Senha Invalido(s)! Verifique'); </script>", false);
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }
        UpdatePanel2.Update();*/

    }

    public string SenhaHASH(string Senha)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //banner topo superior permuta
        dadosBannerTopo = ws.montaBannerPermuta();
        if (dadosBannerTopo.Tables[0].Rows.Count > 0)
        {

            lblBannerTopoDireito.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                               "<param name='movie' value='banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                               "<param name='quality' value='High'>" +
                               "<param name='wmode' value='transparent'>" +
                               "<embed src='banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            UpdatePanel1.Update();

        }
    }

    protected void ddlTipoAcesso_SelectedIndexChanged(object sender, EventArgs e)
    {
     /*   if (ddlTipoAcesso.SelectedValue != "0")
        {
            if (ddlTipoAcesso.SelectedValue == "1")
            {
                pnChatCli.Visible = true;
                pnChatUsr.Visible = false;

            }
            if (ddlTipoAcesso.SelectedValue == "2")
            {
                pnChatUsr.Visible = true;
                pnChatCli.Visible = false;
            }

            UpdatePanel2.Update();
        }*/
    }

    protected void montaBanner()
    {
        lblTopo.Text = "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='760' height='30' title='Topo'>" +
                        "<param name='movie' value='" + Page.Request.ApplicationPath.ToString() + "/imagens/topo.swf'>" +
                        "<param name='quality' value='High'" +
                        "<param name='_cx' value='20108'>" +
                        "<param name='_cy' value='1852'>" +
                        "<param name='FlashVars' value>" +
                        "<param name='Src' value='" + Page.Request.ApplicationPath.ToString() + "/imagens/topo.swf'>" +
                        "<param name='WMode' value='Window'>" +
                        "<param name='Play' value='0'>" +
                        "<param name='Loop' value='-1'>" +
                        "<param name='SAlign' value>" +
                        "<param name='Menu' value='-1'>" +
                        "<param name='Base' value>" +
                        "<param name='AllowScriptAccess' value>" +
                        "<param name='Scale' value='ShowAll'>" +
                        "<param name='DeviceFont' value='0'>" +
                        "<param name='EmbedMovie' value='0'>" +
                        "<param name='BGColor' value>" +
                        "<param name='SWRemote' value>" +
                        "<param name='MovieData' value>" +
                        "<param name='SeamlessTabbing' value='1'>" +
                        "<param name='Profile' value='0'>" +
                        "<param name='ProfileAddress' value>" +
                        "<param name='ProfilePort' value='0'>" +
                        "<param name='AllowNetworking' value='all'>" +
                        "<param name='AllowFullScreen' value='false'>" +
                        "<param name='wmode' value='transparent'>" +
                        "<embed src='" + Page.Request.ApplicationPath.ToString() + "/imagens/topo.swf' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='760' height='30' wmode='transparent'></embed></object>";


        if (Request.QueryString["tipo_categoria"] != null)
        {
            int vTipoCategoria = Convert.ToInt32(Request.QueryString["tipo_categoria"].ToString());


            //banner lado esquerdo pequeno
            dadosBanner = ws.montaBannerSuperior(vTipoCategoria, 5);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerSE.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";


            }

            //banner central
            dadosBanner = ws.montaBannerSuperior(vTipoCategoria, 4);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerCe.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            }

            //banner lado direito pequeno
            dadosBanner = ws.montaBannerSuperior(vTipoCategoria, 8);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerSD.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            }


            //banner topo superior permuta
            dadosBannerTopo = ws.montaBannerPermuta();
            if (dadosBannerTopo.Tables[0].Rows.Count > 0)
            {

                lblBannerTopoDireito.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='" + Page.Request.ApplicationPath.ToString() + "/banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            }

        }
        else
        {

            //banner topo superior permuta
            dadosBannerTopo = ws.montaBannerPermuta();
            if (dadosBannerTopo.Tables[0].Rows.Count > 0)
            {

                lblBannerTopoDireito.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='banners/" + dadosBannerTopo.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBannerTopo.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBannerTopo.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";


            }

            //index

            //banner lado esquerdo pequeno
            dadosBanner = ws.montaBannerSuperior(0, 10);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerSE.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";


            }

            //banner central
            dadosBanner = ws.montaBannerSuperior(0, 9);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerCe.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            }

            //banner lado direito pequeno
            dadosBanner = ws.montaBannerSuperior(0, 11);
            if (dadosBanner.Tables[0].Rows.Count > 0)
            {

                lblBannerSD.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='obj10' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "'>" +
                                   "<param name='movie' value='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "'>" +
                                   "<param name='quality' value='High'>" +
                                   "<param name='wmode' value='transparent'>" +
                                   "<embed src='banners/" + dadosBanner.Tables[0].Rows[0]["descricao"].ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + dadosBanner.Tables[0].Rows[0]["largura"].ToString() + "' height='" + dadosBanner.Tables[0].Rows[0]["altura"].ToString() + "' quality='High' wmode='transparent'></object>";

            }


        }
        UpdatePanel1.Update();

    }


    protected void dlPublicidade_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView dbr = (DataRowView)e.Item.DataItem;

        if (Convert.ToString(DataBinder.Eval(dbr, "descricao")) != "")
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;

            Label lblBanner = (Label)e.Item.FindControl("lblBanner");
            lblBanner.Text = "<object classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' id='objBannerL' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0' border='0' width='" + Convert.ToString(DataBinder.Eval(dbr, "largura")) + "' height='" + Convert.ToString(DataBinder.Eval(dbr, "altura")) + "'>" +
                   "<param name='movie' value='"+appPath+"/banners/" + Convert.ToString(DataBinder.Eval(dbr, "descricao")) + "'>" +
                   "<param name='quality' value='High'>" +
                   "<param name='wmode' value='transparent'>" +
                   "<embed src='"+ appPath +"/banners/" + Convert.ToString(DataBinder.Eval(dbr, "descricao")) + "' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='obj10' width='" + Convert.ToString(DataBinder.Eval(dbr, "largura")) + "' height='" + Convert.ToString(DataBinder.Eval(dbr, "altura")) + "' quality='High' wmode='transparent'></object>";


           // btn.Attributes.Add("onmouseover", "imgFI_onmouseover();montaBanner('" + Convert.ToString(DataBinder.Eval(dbr, "codigo")) + "','" + Page.Request.ApplicationPath.ToString() + "/banners/" + Convert.ToString(DataBinder.Eval(dbr, "descricao")) + "','" + Convert.ToString(DataBinder.Eval(dbr, "largura")) + "','" + Convert.ToString(DataBinder.Eval(dbr, "altura")) + "');");
            //btn.Attributes.Add("onmouseout", "imgFI_onmouseout();");

        }

    }

    protected void grdMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dbr = (DataRowView)e.Row.DataItem;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink lnk = (HyperLink)e.Row.FindControl("lnkCategoria");
            
            if (Request.QueryString["tipo_categoria"] != null)
            {
                lnk.Attributes["href"] = Page.Request.ApplicationPath.ToString()+ "/Categoria/" + Convert.ToString(DataBinder.Eval(dbr, "Descricao")) + "/CURITIBA";
            }
            else
            {
               lnk.Attributes["href"] = "Categoria/" + Convert.ToString(DataBinder.Eval(dbr, "Descricao")) + "/CURITIBA";            
            }
        }

    }

    protected void grdMenu2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView dbr = (DataRowView)e.Row.DataItem;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink lnk = (HyperLink)e.Row.FindControl("lnkCategoria");
            lnk.Attributes["CommandArgument"] = Convert.ToString(DataBinder.Eval(dbr, "Descricao"));

            if (Request.QueryString["tipo_categoria"] != null)
            {
                lnk.Attributes["href"] = Page.Request.ApplicationPath.ToString() + "/Categoria/" + Convert.ToString(DataBinder.Eval(dbr, "Descricao")) + "/CURITIBA";                
            }
            else
            {
                lnk.Attributes["href"] = "Categoria/" + Convert.ToString(DataBinder.Eval(dbr, "Descricao")) + "/CURITIBA";
            }
        }
    }

    protected void btnFechar_Click(object sender, ImageClickEventArgs e)
    {
        mpe.Hide();
    }

}
