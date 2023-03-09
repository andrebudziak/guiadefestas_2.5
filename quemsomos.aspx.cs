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
using System.Data;

public partial class quemsomos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebService ws = new WebService();

            //#region MontaMenu
            DataSet dados = new DataSet();
            dados = ws.montamenu("1");
            grdMenu.DataSource = dados;
            grdMenu.DataBind();

            //#region MontaMenu
            DataSet dados2 = new DataSet();
            dados2 = ws.montamenu("2");
            grdMenu2.DataSource = dados2;
            grdMenu2.DataBind();

            #region MontaBannerPrincipal
            DataSet dados4 = new DataSet();
            dados4 = ws.montabannerlateral("2");

            dlPublicidade.DataSource = dados4;
            dlPublicidade.DataBind();
            #endregion

            ws.Dispose();

        }

    }
}
