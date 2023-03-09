<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_categoriaanuncio.aspx.cs" Inherits="cadastro_categoriaanuncio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>
       
           <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
               <tr>
                   <td>
                       &nbsp;</td>
                   <td>
                       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                       </asp:ToolkitScriptManager>
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="center">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService"></asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                   SelectMethod="PopulaCategoria" TypeName="WebService"></asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteCategoriaAnunciante" 
    InsertMethod="IncluiCategoriaAnunciante" 
    SelectMethod="ConsultaAnuncioCategoria" TypeName="WebService" 
    UpdateMethod="IncluiCategoriaAnunciante" ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onselecting="ObjectDataSource1_Selecting" 
                                   onupdating="ObjectDataSource1_Updating">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo_anunciante" Type="Int32" />
                                       <asp:Parameter Name="codigo_categoria" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="vCodigoAnunciante" Type="Int32" />
                                       <asp:Parameter Name="vCategoria" Type="Int32" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo_anunciante" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="vCodigoAnunciante" Type="Int32" />
                                       <asp:Parameter Name="vCategoria" Type="Int32" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                               <asp:Label ID="lblCodigoCategoria" runat="server"></asp:Label>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:GridView ID="grdCategoriaAnuncio" runat="server" 
                                   AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                   Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                   onrowcommand="grdCategoriaAnuncio_RowCommand" 
                                   onrowcreated="grdCategoriaAnuncio_RowCreated" 
                                   onrowdeleting="grdCategoriaAnuncio_RowDeleting" ShowFooter="True">
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#CCCCCC" />
                                   <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                       <asp:TemplateField ShowHeader="False">
                                          <EditItemTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Atualizar" />
                                             <asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                          </EditItemTemplate>
                                          <ItemTemplate>
                                             <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                                             <asp:LinkButton ID="LinkButtonDelete" runat="server" CssClass="deletar" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Deseja excluir o registro?');" Text="Deletar" />
                                          </ItemTemplate>
                                          <FooterTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Save" Text="Salvar" />
                                          </FooterTemplate>
                                       </asp:TemplateField>
                                   
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" Text='<%# Bind("codigo") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("codigo") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Anuncio">
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Enabled="false"
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_anunciante")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>                                           
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Eval("codigo_anunciante")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" 
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                       </asp:TemplateField>                  
                                        <asp:TemplateField HeaderText="Categoria">
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlCategoria" runat="server" Enabled="false"
                                                  DataTextField="descricao" DataValueField="codigo" SelectedValue='<%# Eval("codigo_categoria")%>'
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" 
                                                  DataTextField="descricao" DataValueField="codigo" SelectedValue='<%# Eval("codigo_categoria")%>'
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" 
                                                  DataTextField="descricao" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                          
                                       </asp:TemplateField>                                  
                                                                        
                                   </Columns>                                   
                               </asp:GridView>
                           </ContentTemplate>
                       </asp:UpdatePanel>
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td>
                       <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                           AssociatedUpdatePanelID="UpdatePanel1">
                           <ProgressTemplate>
                               <img alt="" src="imagens/wait.gif" 
    style="width: 50px; height: 50px" />Aguarde...
                           </ProgressTemplate>
                       </asp:UpdateProgress>
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
           </table>
       
       </center>    
    </div>
    </form>
</body>
</html>
