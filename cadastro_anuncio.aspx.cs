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
using System.IO;

public partial class cadastro_anuncio : System.Web.UI.Page
{
    public bool exportando;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblHash.Visible = false;

            if (Request.QueryString["h"] != null)
            {
                lblHash.Text = Request.QueryString["h"].ToString();

                lblCodigo.Visible = false;
                lblCodigo.Text = "0";
                lblCodigoAnuncio.Visible = false;
                lblCodigoAnuncio.Text = "0";
                //  set the key names from my data class.
                grdAnuncio.DataKeyNames = new WebService().PrimaryKeyColumnNames;
                btnAnuncioCategoria.Enabled = false;
                grdRelAnuncio.Visible = false;

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
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportaExcel);


    }

    private bool LoadDataEmpty
    {
        //  some controls that are used within a GridView, such as the calendar control, can cuase post backs.
        //  we need to preserve LoadDataEmpty across post backs.
        get { return (bool)(ViewState["LoadDataEmpty"] ?? false); }
        set { ViewState["LoadDataEmpty"] = value; }
    }

    protected void grdAnuncio_RowCommand(object sender, GridViewCommandEventArgs e)
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

    protected void grdAnuncio_RowCreated(object sender, GridViewRowEventArgs e)
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
        e.InputParameters["codigo"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_cliente"] = ((DropDownList)grdAnuncio.FooterRow.FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["cep"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtCep")).Text;
        e.InputParameters["bairro"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtBairro")).Text;
        e.InputParameters["cidade"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtCidade")).Text;
        e.InputParameters["endereco"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtEndereco")).Text;
        e.InputParameters["telefone"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtTelefone")).Text;
        e.InputParameters["email"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtEmail")).Text;
        e.InputParameters["site"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtSite")).Text;
        e.InputParameters["status"] = ((DropDownList)grdAnuncio.FooterRow.FindControl("ddlStatus")).SelectedValue;
        e.InputParameters["senha"] = ((TextBox)grdAnuncio.FooterRow.FindControl("txtSenha")).Text;
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
        e.InputParameters["codigo"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtCodigo")).Text;
        e.InputParameters["codigo_cliente"] = ((DropDownList)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("ddlCliente")).SelectedValue;
        e.InputParameters["cep"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtCep")).Text;
        e.InputParameters["bairro"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtBairro")).Text;
        e.InputParameters["cidade"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtCidade")).Text;
        e.InputParameters["endereco"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtEndereco")).Text;
        e.InputParameters["telefone"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtTelefone")).Text;
        e.InputParameters["email"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtEmail")).Text;
        e.InputParameters["site"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtSite")).Text;
        e.InputParameters["status"] = ((DropDownList)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("ddlStatus")).SelectedValue;
        e.InputParameters["senha"] = ((TextBox)grdAnuncio.Rows[grdAnuncio.EditIndex].FindControl("txtSenha")).Text;

    }


    protected void grdAnuncio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int codigo = Convert.ToInt32(((Label)grdAnuncio.Rows[index].FindControl("lblCodigo")).Text);
        lblCodigo.Text = codigo.ToString();
    }


    protected void grdAnuncio_RowEditing(object sender, GridViewEditEventArgs e)
    {
       int index = e.NewEditIndex;
       int codigo = Convert.ToInt32(((DropDownList)grdAnuncio.Rows[index].FindControl("ddlCliente")).SelectedValue);
       lblCodigo.Text = codigo.ToString();
       lblCodigoAnuncio.Text = ((Label)grdAnuncio.Rows[index].FindControl("lblCodigo")).Text;
       btnAnuncioCategoria.Enabled = true;
       ifCategoriaAnuncio.Attributes["src"] = "cadastro_categoriaanuncio.aspx?c=" + lblCodigo.Text;     

    }

    protected void btnAnuncioCategoria_Click(object sender, EventArgs e)
    {

    }


    protected void btnBusca_Click(object sender, ImageClickEventArgs e)
    {  
       grdAnuncio.DataBind();
       ObjectDataSource1.Select();
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["codigo"] = lblCodigoAnuncio.Text;
        if(txtValor.Text =="")
            e.InputParameters["nome"] = "0";
        else
            e.InputParameters["nome"] = txtValor.Text;
    }

    protected void grdAnuncio_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblCodigo.Text="0";
        lblCodigoAnuncio.Text = "0";
        txtValor.Text = "0";
        grdAnuncio.DataBind();
        ObjectDataSource1.Select();
    }


    protected void grdAnuncio_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblCodigo.Text = "0";
        lblCodigoAnuncio.Text = "0";
        txtValor.Text = "0";
        grdAnuncio.DataBind();
        ObjectDataSource1.Select();
    }

    protected void btnExportaExcel_Click(object sender, EventArgs e)
    {
        grdRelAnuncio.Visible = true;

        Response.Clear();
        exportando = true;

        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        Response.Charset = "";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        this.EnableViewState = false;
        grdRelAnuncio.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());

        Response.End();

        grdRelAnuncio.Visible = false;
         


    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        if (!exportando)
        {
            base.VerifyRenderingInServerForm(control);
        }
    }

}
