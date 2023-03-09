<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_logo.aspx.cs" Inherits="cadastro_logo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                       </cc1:ToolkitScriptManager>
                   </td>
                   <td>
                   <asp:Label ID="lblHash" runat="server"></asp:Label>
                  </td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="left">
                      <table style="width:200px;" border="0" cellpadding="0" cellspacing="0">
                                       <tr>
                                           <td>
                                               <asp:Label ID="Label1" runat="server" CssClass="TituloCinzaEscuro" 
                                                   Text="Pesquisar:"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtValor" runat="server" Font-Names="Arial" Font-Size="11px" 
                                                   Width="250px"></asp:TextBox>
                                               <cc1:autocompleteextender ID="AutoCompleteExtenderDemo" runat="server" 
                                                   EnableCaching="false" MinimumPrefixLength="1" 
                                                   ServiceMethod="RetornaNomeCliente" ServicePath="WebService.asmx" 
                                                   TargetControlID="txtValor">
                                               </cc1:autocompleteextender>
                                           </td>
                                           <td>
                                               <asp:ImageButton ID="btnBusca" runat="server" 
                                                   ImageUrl="~/imagens/PESQUISAR.png" onclick="btnBusca_Click" 
                                                   style="height: 33px" />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                                   onclick="btnExportaExcel_Click" Text="Exporta para Excel" />
                                           </td>
                                           <td>
                                               &nbsp;</td>
                                           <td>
                                               &nbsp;</td>
                                       </tr>
                                   </table>                   
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="center">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                   DeleteMethod="DeleteLogo" InsertMethod="IncluirLogo" 
                                   SelectMethod="ConsultaLogo" TypeName="WebService" 
                                   UpdateMethod="IncluirLogo" oninserting="ObjectDataSource1_Inserting" 
                                   onupdating="ObjectDataSource1_Updating" 
                                   ondeleting="ObjectDataSource1_Deleting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onselecting="ObjectDataSource1_Selecting">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="codigo_anuncio" Type="Int32" />                                       
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="codigo_anuncio" Type="Int32" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService"></asp:ObjectDataSource>
                               <asp:GridView ID="grdLogo" runat="server" 
                                   AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                   Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                   onrowcommand="grdLogo_RowCommand" onrowcreated="grdLogo_RowCreated" 
                                   ShowFooter="True" onrowdeleting="grdLogo_RowDeleting" AllowPaging="True" 
                                   AllowSorting="True">
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#999999" />
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
                                              <asp:Label ID="lblAnunciante" runat="server" Text='<%# Eval("nome_fantasia") %>' />
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_anuncio")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="300px" Text='<%# Bind("descricao") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("descricao") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="300px" />
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
