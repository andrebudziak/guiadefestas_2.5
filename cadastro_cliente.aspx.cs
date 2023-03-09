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

public partial class cadastro_cliente : System.Web.UI.Page
{
    private WebService ws = new WebService();
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
                //  set the key names from my data class.
                grdCliente.DataKeyNames = new WebService().PrimaryKeyColumnNames;
                grdRelCliente.Visible = false;

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

    protected void grdCliente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //  handle the save button on the footer row.
        if (e.CommandName == "Save")
        {
            ObjectDataSource2.Insert();
        }
        if (e.CommandName == "Update")
        {
            ObjectDataSource2.Update();
        }

    }
    protected void grdCliente_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void ObjectDataSource2_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //  on insert, pass the values from the footer controls.
        e.InputParameters["codigo"] = ((TextBox)grdCliente.FooterRow.FindControl("txtCodigo")).Text;
        e.InputParameters["razao_social"] = ((TextBox)grdCliente.FooterRow.FindControl("txtRazaoSocial")).Text;
        e.InputParameters["cnpj"] = ((TextBox)grdCliente.FooterRow.FindControl("txtCnpj")).Text;
        e.InputParameters["cpf"] = ((TextBox)grdCliente.FooterRow.FindControl("txtCpf")).Text;
        e.InputParameters["rg"] = ((TextBox)grdCliente.FooterRow.FindControl("txtRg")).Text;
        e.InputParameters["endereco"] = ((TextBox)grdCliente.FooterRow.FindControl("txtEndereco")).Text;
        e.InputParameters["cep"] = ((TextBox)grdCliente.FooterRow.FindControl("txtCep")).Text;
        e.InputParameters["bairro"] = ((TextBox)grdCliente.FooterRow.FindControl("txtBairro")).Text;
        e.InputParameters["cidade"] = ((TextBox)grdCliente.FooterRow.FindControl("txtCidade")).Text;
        e.InputParameters["email"] = ((TextBox)grdCliente.FooterRow.FindControl("txtEmail")).Text;
        e.InputParameters["responsavel"] = ((TextBox)grdCliente.FooterRow.FindControl("txtResponsavel")).Text;
        e.InputParameters["telefone"] = ((TextBox)grdCliente.FooterRow.FindControl("txtTelefone")).Text;
        e.InputParameters["nome_fantasia"] = ((TextBox)grdCliente.FooterRow.FindControl("txtNomeFantasia")).Text;
    }

    protected void ObjectDataSource2_Selected(object sender, ObjectDataSourceStatusEventArgs e)
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

    protected void ObjectDataSource2_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = lblCodigo.Text;
    }

    protected void ObjectDataSource2_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //  on insert, pass the values from the footer controls.
        e.InputParameters["codigo"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtCodigo")).Text;
        e.InputParameters["razao_social"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtRazaoSocial")).Text;
        e.InputParameters["cnpj"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtCnpj")).Text;
        e.InputParameters["cpf"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtCpf")).Text;
        e.InputParameters["rg"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtRg")).Text;
        e.InputParameters["endereco"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtEndereco")).Text;
        e.InputParameters["cep"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtCep")).Text;
        e.InputParameters["bairro"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtBairro")).Text;
        e.InputParameters["cidade"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtCidade")).Text;
        e.InputParameters["email"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtEmail")).Text;
        e.InputParameters["responsavel"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtResponsavel")).Text;
        e.InputParameters["telefone"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtTelefone")).Text;
        e.InputParameters["nome_fantasia"] = ((TextBox)grdCliente.Rows[grdCliente.EditIndex].FindControl("txtNomeFantasia")).Text;
    }

    protected void grdCliente_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int codigo = Convert.ToInt32(((Label)grdCliente.Rows[index].FindControl("lblCodigo")).Text);
        lblCodigo.Text = codigo.ToString();
    }

    protected void btnBusca_Click(object sender, ImageClickEventArgs e)
    {
        grdCliente.DataBind();
        ObjectDataSource2.Select();
    }

    protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["codigo"] = lblCodigo.Text;
        if (txtValor.Text == "")
            e.InputParameters["nome"] = "0";
        else
            e.InputParameters["nome"] = txtValor.Text;
    }

    protected void grdCliente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblCodigo.Text = "0";
        txtValor.Text = "0";
        grdCliente.DataBind();
        ObjectDataSource2.Select();

    }
    protected void btnExportaExcel_Click(object sender, EventArgs e)
    {
        grdRelCliente.Visible = true;

        Response.Clear();
        exportando = true;

        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        Response.Charset = "";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        StringWriter stringWrite = new System.IO.StringWriter();

        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        this.EnableViewState = false;
        grdRelCliente.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());

        Response.End();

        grdRelCliente.Visible = false;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        if (!exportando)
        {
            base.VerifyRenderingInServerForm(control);
        }
    }

}
