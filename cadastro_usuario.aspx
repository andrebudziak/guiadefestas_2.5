<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_usuario.aspx.cs" Inherits="cadastro_usuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                   <asp:Label ID="lblHash" runat="server"></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="left">
                                               <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                                   onclick="btnExportaExcel_Click" 
                           Text="Exporta para Excel" />
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="left">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:GridView ID="grdUsuario" runat="server" 
                                   AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                   Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                   ShowFooter="True" onrowcommand="grdBonus_RowCommand" 
                                   onrowcreated="grdBonus_RowCreated" onrowdeleting="grdBonus_RowDeleting" 
                                   AllowPaging="True">
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="Silver" />
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField ShowHeader="False">
                                          <EditItemTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Atualizar" />
                                             <asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                          </EditItemTemplate>
                                          <ItemTemplate>
                                             <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                                             <asp:LinkButton ID="LinkButtonDelete"  CssClass="deletar" runat="server" CausesValidation="False" CommandName="Delete"
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
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" Text="0" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descrição" SortExpression="bonus">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="100px" Text='<%# Bind("descricao") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblDescricao" runat="server" Text='<%# Bind("descricao") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="100px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Senha" SortExpression="senha">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" Width="100px" Text='<%# Bind("senha") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblSenha" runat="server" Text="" />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" Width="100px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                            
                                        <asp:TemplateField HeaderText="Anunciante">
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Enabled="false" Width="200px"
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_anunciante")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>                                           
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Width="200px"
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Eval("codigo_anunciante")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Width="200px" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" 
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                       </asp:TemplateField>                  
                                                                        
                                   </Columns>                                   
                                   
                               </asp:GridView>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                   DeleteMethod="ExcluirUsuario" InsertMethod="IncluirUsuario" 
                                   SelectMethod="ConsultaUsuario" TypeName="WebService" 
                                   UpdateMethod="IncluirUsuario" onupdating="ObjectDataSource1_Updating" 
                                   ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_anunciante" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="senha" Type="String" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_anunciante" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="senha" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService">
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
    style="width: 50px; height: 50px" />Aguarde..
                           </ProgressTemplate>
                       </asp:UpdateProgress>
                   </td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td>
                             <asp:GridView ID="grdRelUsuario" runat="server" 
                                   AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                   Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                   ShowFooter="True" 
                                   AllowPaging="False">
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="Silver" />
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("codigo") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                           <ItemTemplate>
                                              <asp:Label ID="lblDescricao" runat="server" Text="" />
                                           </ItemTemplate>
                                        </asp:TemplateField>    
                                       <asp:TemplateField HeaderText="Anunciante">
                                           <ItemTemplate>
                                              <asp:Label ID="lblAnunciante" runat="server" Text="" Width="200px" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>                                   
                                   
                               </asp:GridView>                  
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
