using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Common;
using System.Text;
using System.IO;

public partial class categoria : System.Web.UI.Page
{
    private int vTipoCategoria = 0;
    private string vCategoria = "";
    private AjaxControlToolkit.Accordion acc;
    private WebService ws = new WebService();

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {

            if (Request.QueryString["c"] == null)
            {
                vTipoCategoria = Convert.ToInt32(Request.QueryString["tipo_categoria"].ToString());
            }
            else
            {
                vTipoCategoria = 0;

            }


            DataSet dados = new DataSet();
            dados = ws.descricaoCategoria(Convert.ToString(vTipoCategoria));
            if (dados.Tables[0].Rows.Count != 0)
            {
                lblTituloCat.Text = dados.Tables[0].Rows[0]["descricao"].ToString();
                Page.Title = dados.Tables[0].Rows[0]["descricao"].ToString();
            }                

        }
    }

    protected void dlAnunciante_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView dbr = (DataRowView)e.Item.DataItem;
        acc = (AjaxControlToolkit.Accordion)e.Item.FindControl("accAnunciante");

        Label lblCodigoAnuncio = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblCodigoAnuncio");
        lblCodigoAnuncio.Text = Convert.ToString(DataBinder.Eval(dbr, "codigo"));

        Label lblNomeFantasia = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblNomeFantasia");
        lblNomeFantasia.Text = Convert.ToString(DataBinder.Eval(dbr, "nome_fantasia"));

        Label lblBairroCidade = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblBairroCidade");
        lblBairroCidade.Text = Convert.ToString(DataBinder.Eval(dbr, "bairro")) + "-" + Convert.ToString(DataBinder.Eval(dbr, "cidade"));

        Label lblEndereco = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblEndereco");
        lblEndereco.Text = Convert.ToString(DataBinder.Eval(dbr, "endereco"));

        Label lblTelefone = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblTelefone");
        lblTelefone.Text = Convert.ToString(DataBinder.Eval(dbr, "telefone"));

        //Label lblRedes = (Label)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("lblRedes");
        //lblRedes.Text = "";

        Int32 mes = DateTime.Now.Month;
        DataSet dados = ws.ConsultaMesAgenda(Convert.ToInt32(lblCodigoAnuncio.Text),mes);

        DropDownList ddlMes = (DropDownList)this.acc.Panes[1].ContentContainer.FindControl("ddlMes");
        ddlMes.SelectedValue = mes.ToString();

        Label lblCodAnuncio = (Label)this.acc.Panes[1].ContentContainer.FindControl("lblCodAnuncio");
        lblCodAnuncio.Text = Convert.ToString(DataBinder.Eval(dbr, "codigo"));

        if (dados != null)
        {
            if (dados.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dados.Tables[0].Rows)
                {                                    
                    TextBox txtInformacoes = (TextBox)this.acc.Panes[1].ContentContainer.FindControl("txtInformacoes");
                    txtInformacoes.Text = "-" + row["descricao"].ToString() + " Data:" + Convert.ToDateTime(row["data"].ToString()).ToString("dd/MM/yyyy") + " Hora: " + Convert.ToDateTime(row["data"].ToString()).ToString("HH:mm:ss");                    
                }
            }
        }

        if (Convert.ToString(DataBinder.Eval(dbr, "logo")) != "")
        {
            ImageButton btn = (ImageButton)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("btnImgLogo");
            btn.ImageUrl = Page.Request.ApplicationPath.ToString()+ "/logos/" + Convert.ToString(DataBinder.Eval(dbr, "logo"));
        }
        
        if (Convert.ToString(DataBinder.Eval(dbr, "site")) == "")
        {
            ImageButton btn = (ImageButton)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("btnImgSite");

            btn.ImageUrl = Page.Request.ApplicationPath.ToString() + "/imagens/SEMWEB.png";
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aSite");

        }
        else
        {
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aSite");
            lnk.Attributes["href"] = "http://" + Convert.ToString(DataBinder.Eval(dbr, "site"));

            HyperLink lnk2 = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aLogo");

            string myScript = "window.open('" + "http://" + Convert.ToString(DataBinder.Eval(dbr, "site")) + "', null,''); void(0)";
            lnk2.Attributes["onclick"] = myScript;
            lnk.Attributes["onclick"] = myScript;
            
            lnk2.Attributes["href"] = "http://" + Convert.ToString(DataBinder.Eval(dbr, "site"));

            ImageButton btn = (ImageButton)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("btnImgSite");

            btn.ImageUrl = Page.Request.ApplicationPath.ToString() + "/imagens/WEB.png";

            lblGMais.Text = "<g:plusone size='small' href='" + Convert.ToString(DataBinder.Eval(dbr, "site")) + "'></g:plusone>";
            lblTwitter.Text = "<a href='http://twitter.com/share' class='twitter-share-button' data-url='" + Convert.ToString(DataBinder.Eval(dbr, "site")) + "' data-text='Acesse " + Convert.ToString(DataBinder.Eval(dbr, "site")) + "' data-count='none' data-via='guiafestasctba' data-lang='pt'>Tweet</a><script type='text/javascript' src='http://platform.twitter.com/widgets.js'></script>";
            lblFacebook.Text = "<iframe src='http://www.facebook.com/plugins/like.php?href=" + Convert.ToString(DataBinder.Eval(dbr, "site")) + "&layout=button_count&show_faces=false&width=380&action=like&colorscheme=light&height=25&locale=pt_BR' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:100px; height:20px; vertical-align:bottom; ' allowTransparency='true'></iframe>";

        }

        this.acc.Panes[this.acc.SelectedIndex].HeaderContainer.Controls.Add(lblNomeFantasia);


        if (Convert.ToString(DataBinder.Eval(dbr, "email")) == "")
        {
            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgEmail");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/SEMEMAIL.png";
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aEmail");
        }
        else
        {
            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgEmail");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/EMAIL.png";

            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aEmail");
            lnk.Attributes["href"] = "mailto:"+Convert.ToString(DataBinder.Eval(dbr, "email"));       
        }

        if (Convert.ToString(DataBinder.Eval(dbr, "orkut")) != "")
        {
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aOrkut");
            lnk.Attributes["href"] = Convert.ToString(DataBinder.Eval(dbr, "orkut"));

            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgOrkut");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/orkAtivo.jpg";        

        }
        else
        {
            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgOrkut");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/orkInativo.jpg";        
        }

        if (Convert.ToString(DataBinder.Eval(dbr, "facebook")) != "")
        {
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aFacebook");
            lnk.Attributes["href"] = Convert.ToString(DataBinder.Eval(dbr, "facebook"));

            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgFacebook");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/facebAtivo.jpg";               

        }
        else
        {
            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgFacebook");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/facebInativo.jpg";               
        }

        if (Convert.ToString(DataBinder.Eval(dbr, "twitter")) != "")
        {
            HyperLink lnk = (HyperLink)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("aTwitter");
            lnk.Attributes["href"] = Convert.ToString(DataBinder.Eval(dbr, "twitter"));

            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgTwitter");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/twitAtivo.jpg";

        }
        else
        {
            HtmlImage btn = (HtmlImage)this.acc.Panes[this.acc.SelectedIndex].ContentContainer.FindControl("imgTwitter");
            btn.Src = Page.Request.ApplicationPath.ToString() + "/imagens/twitInativo.jpg";
        }

    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["ordem"] = ddlFiltro.SelectedValue;      
    }

    protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.Select();
        dlAnunciante.DataBind();
    }

    protected void dlAnunciante_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ContaClick") 
        {
            Label lnk1 = (Label)e.Item.FindControl("lblCodigoAnuncio"); 
            string key = lnk1.Text;
            ws.contaClicks(Convert.ToInt32(key));

            HyperLink lnk = (HyperLink)e.Item.FindControl("aLogo");

            string myScript = "window.open('"+lnk.NavigateUrl+"', null,''); void(0)";

            lnk.Attributes["onclick"] = myScript; 

        }

    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList actionsDDL = sender as DropDownList;
        Label projectCandidateIdHF = actionsDDL.Parent.FindControl("lblCodAnuncio") as Label;
    }
}
