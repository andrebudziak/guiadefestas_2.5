using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class cadastro_link : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblHash.Visible = false;

            if (Request.QueryString["h"] != null)
            {
                lblHash.Text = Request.QueryString["h"].ToString();

                lblCodigo.Visible = false;
                //  set the key names from my data class.
                grdLinkAnuncio.DataKeyNames = new WebService().PrimaryKeyColumnNames;

                //'HTTP/1.1
                Response.CacheControl = "no-cache";
                Response.AddHeader("cache-control", "no-cache");
                //'HTTP/1.0
                Response.AddHeader("Pragma", "no-cache");
                Response.Expires = -1;// ' minutos até a expiração
                Response.ExpiresAbsolute = DateTime.Now; //' data de expiração

            }
            else
            {
                Response.Redirect("login.aspx");
            }


        }
    }

    private bool LoadDataEmpty
    {
        //  some controls that are used within a GridView, such as the calendar control, can cuase post backs.
        //  we need to preserve LoadDataEmpty across post backs.
        get { return (bool)(ViewState["LoadDataEmpty"] ?? false); }
        set { ViewState["LoadDataEmpty"] = value; }
    }

    protected void grdLinkAnuncio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //  handle the save button on the footer row.
        if (e.CommandName == "Save")
        {
            ObjectDataSource1.Insert();
        }
        if (e.CommandName == "Update")
        {
            ObjectDataSource1.Update();
        }
    }

    protected void grdLinkAnuncio_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //  when binding a row, look for a zero row condition based on the flag.
        //  if we have zero data rows (but a dummy row), hide the grid view row
        //  and clear the controls off of that row so they don't cause binding errors
        if (LoadDataEmpty && e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Visible = false;
            e.Row.Controls.Clear();
        }
    }

    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = ((TextBox)grdLinkAnuncio.FooterRow.FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_anuncio"] = ((DropDownList)grdLinkAnuncio.FooterRow.FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["orkut"] = ((TextBox)grdLinkAnuncio.FooterRow.FindControl("txtOrkut")).Text;
        e.InputParameters["facebook"] = ((TextBox)grdLinkAnuncio.FooterRow.FindControl("txtFacebook")).Text;
        e.InputParameters["twitter"] = ((TextBox)grdLinkAnuncio.FooterRow.FindControl("txtTwitter")).Text;

    }

    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {        
        e.InputParameters["codigo"] = lblCodigo.Text;
    }

    protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //  bubble exceptions before we touch e.ReturnValue
        if (e.Exception != null)
        {
            throw e.Exception;
        }

        //  get the DataTable from the ODS select mothod
        DataSet dataTable = (DataSet)e.ReturnValue;

        //  if rows=0 then add a dummy (null) row and set the LoadDataEmpty flag.
        if (dataTable.Tables[0].Rows.Count == 0)
        {
            dataTable.Tables[0].Rows.Add(dataTable.Tables[0].NewRow());
            LoadDataEmpty = true;
        }
        else
        {
            LoadDataEmpty = false;
        }
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = ((TextBox)grdLinkAnuncio.Rows[grdLinkAnuncio.EditIndex].FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_anuncio"] = ((DropDownList)grdLinkAnuncio.Rows[grdLinkAnuncio.EditIndex].FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["orkut"] = ((TextBox)grdLinkAnuncio.Rows[grdLinkAnuncio.EditIndex].FindControl("txtOrkut")).Text;
        e.InputParameters["facebook"] = ((TextBox)grdLinkAnuncio.Rows[grdLinkAnuncio.EditIndex].FindControl("txtFacebook")).Text;
        e.InputParameters["twitter"] = ((TextBox)grdLinkAnuncio.Rows[grdLinkAnuncio.EditIndex].FindControl("txtTwitter")).Text;

    }

    protected void grdLinkAnuncio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int codigo = Convert.ToInt32(((Label)grdLinkAnuncio.Rows[index].FindControl("lblCodigo")).Text);
        lblCodigo.Text = codigo.ToString();
    }
}
