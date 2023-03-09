<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_link.aspx.cs" Inherits="cadastro_link" %>

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
                   <td class="style1">
                       </td>
                   <td class="style1">
                       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                       </asp:ToolkitScriptManager>
                   </td>
                   <td >
                   <asp:Label ID="lblHash" runat="server"></asp:Label>
                       </td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="center">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                               <asp:GridView ID="grdLinkAnuncio" runat="server" Width="800px" 
                                   AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                   ForeColor="#333333" GridLines="Horizontal" Font-Names="Arial" 
                                   Font-Size="11px" onrowcommand="grdLinkAnuncio_RowCommand" 
                                   onrowcreated="grdLinkAnuncio_RowCreated" ShowFooter="True" 
                                   onrowdeleting="grdLinkAnuncio_RowDeleting" >
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#CCCCCC" Font-Names="Arial" Font-Size="11px" />
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
                                              <asp:Label ID="lblAnunciante" runat="server" Text='<%# Bind("nome_fantasia") %>'  />
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
                                       <asp:TemplateField HeaderText="Orkut" SortExpression="orkut">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtOrkut" runat="server" Width="200px" Text='<%# Bind("orkut") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblOrkut" runat="server" Text='<%# Eval("orkut") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtOrkut" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                                         
                                       <asp:TemplateField HeaderText="Facebook" SortExpression="facebook">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtFacebook" runat="server" Width="200px" Text='<%# Bind("facebook") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblFacebook" runat="server" Text='<%# Eval("facebook") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtFacebook" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                                         
                                       <asp:TemplateField HeaderText="Twitter" SortExpression="twitter">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtTwitter" runat="server" Width="200px" Text='<%# Bind("twitter") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblTwitter" runat="server" Text='<%# Eval("twitter") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtTwitter" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                                       
                                                                        
                                   </Columns>
                               </asp:GridView>  
                               
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService">
                               </asp:ObjectDataSource>                              
                                                             
                             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                   DeleteMethod="ExcluirLink" InsertMethod="IncluirLink" 
                                   SelectMethod="ConsultaLink" TypeName="WebService" 
                                   UpdateMethod="IncluirLink" oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   ondeleting="ObjectDataSource1_Deleting" 
                                   onupdating="ObjectDataSource1_Updating">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" DefaultValue="0" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_anuncio" Type="Int32" />
                                       <asp:Parameter Name="orkut" Type="String" />
                                       <asp:Parameter Name="facebook" Type="String" />
                                       <asp:Parameter Name="twitter" Type="String" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo_link" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_anuncio" Type="Int32" />
                                       <asp:Parameter Name="orkut" Type="String" />
                                       <asp:Parameter Name="facebook" Type="String" />
                                       <asp:Parameter Name="twitter" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>                                                                                            
                                                                                                              
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
