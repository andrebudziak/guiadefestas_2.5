using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class cadastro_usuario : System.Web.UI.Page
{
    public bool exportando;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblHash.Visible = false;
            grdRelUsuario.Visible = false;

            if (Request.QueryString["h"] != null)
            {
                lblHash.Text = Request.QueryString["h"].ToString();

                lblCodigo.Visible = false;
                //  set the key names from my data class.
                grdUsuario.DataKeyNames = new WebService().PrimaryKeyColumnNames;

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
                // Response.Redirect("login.aspx");
            }


        }
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportaExcel);

    }

    private bool LoadDataEmpty
    {
        //  some controls that are used within a GridView, such as the calendar control, can cuase post backs.
        //  we need to preserve LoadDataEmpty across post backs.
        get { return (bool)(ViewState["LoadDataEmpty"] ?? false); }
        set { ViewState["LoadDataEmpty"] = value; }
    }

    protected void grdBonus_RowCommand(object sender, GridViewCommandEventArgs e)
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
    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = ((TextBox)grdUsuario.Rows[grdUsuario.EditIndex].FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_anunciante"] = ((DropDownList)grdUsuario.Rows[grdUsuario.EditIndex].FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["descricao"] = ((TextBox)grdUsuario.Rows[grdUsuario.EditIndex].FindControl("txtDescricao")).Text;
        e.InputParameters["senha"] = ((TextBox)grdUsuario.Rows[grdUsuario.EditIndex].FindControl("txtSenha")).Text;
    }

    protected void grdBonus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int codigo = Convert.ToInt32(((Label)grdUsuario.Rows[index].FindControl("lblCodigo")).Text);
        lblCodigo.Text = codigo.ToString();
    }

    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = ((TextBox)grdUsuario.FooterRow.FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_anunciante"] = ((DropDownList)grdUsuario.FooterRow.FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["descricao"] = ((TextBox)grdUsuario.FooterRow.FindControl("txtDescricao")).Text;
        e.InputParameters["senha"] = ((TextBox)grdUsuario.FooterRow.FindControl("txtSenha")).Text;
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

    protected void grdBonus_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void btnExportaExcel_Click(object sender, EventArgs e)
    {
        grdRelUsuario.Visible = true;

        Response.Clear();
        exportando = true;

        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        Response.Charset = "";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        this.EnableViewState = false;
        grdRelUsuario.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());

        Response.End();

        grdRelUsuario.Visible = false;

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        if (!exportando)
        {
            base.VerifyRenderingInServerForm(control);
        }
    }
}