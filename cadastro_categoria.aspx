<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_categoria.aspx.cs" Inherits="cadastro_categoria" %>

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
                   <td class="style1">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                  <asp:Label ID="lblHash" runat="server"></asp:Label>                   
                   </td>
                   <td align="center">
                                               <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                                   onclick="btnExportaExcel_Click" 
                           Text="Exporta para Excel" />
                   </td>
                   <td class="style1">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="center">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:GridView ID="grdCategoria" runat="server" 
    CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
    GridLines="Horizontal" AllowSorting="True" AutoGenerateColumns="False" Font-Names="Arial" 
                                   Font-Size="11px" onrowcommand="grdCategoria_RowCommand" 
                                   onrowcreated="grdCategoria_RowCreated" 
                                   onrowdeleting="grdCategoria_RowDeleting" ShowFooter="True" 
                                   AllowPaging="True">
                                   <PagerSettings Position="Top" />
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
                                               <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" 
                                                   CommandName="Update" Text="Atualizar" />
                                               <asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False" 
                                                   CommandName="Cancel" Text="Cancelar" />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" 
                                                   CommandName="Save" Text="Salvar" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" 
                                                   CommandName="Edit" Text="Editar" />
                                               <asp:LinkButton ID="LinkButtonDelete" runat="server" CssClass="deletar" CausesValidation="False" 
                                                   CommandName="Delete" 
                                                   OnClientClick="return confirm('Deseja excluir o registro?');" Text="Deletar" />
                                           </ItemTemplate>
                                       </asp:TemplateField>                                  
                                   
                                       <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="txtCodigo" runat="server" Text='<%# Bind("codigo") %>' 
                                                   Width="50px" />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:TextBox ID="txtCodigo" runat="server" Width="50px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Descriçao" SortExpression="descricao">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="txtDescricao" runat="server" Text='<%# Bind("descricao") %>' 
                                                   Width="200px" />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:TextBox ID="txtDescricao" runat="server" Width="200px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("descricao") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Tipo" SortExpression="tipo_categoria">
                                           <ItemTemplate>
                                                <asp:DropDownList ID="ddlTipoCategoria" Enabled="false" runat="server" SelectedValue='<%# Bind("tipo_categoria")%>'>
                                                  <asp:ListItem Value="0">[]</asp:ListItem>
                                                  <asp:ListItem Value="1">Onde fazer a sua FESTA</asp:ListItem>
                                                  <asp:ListItem Value="2">Serviços para FESTA</asp:ListItem>
                                                </asp:DropDownList>
                                           </ItemTemplate>                                       
                                           <EditItemTemplate>
                                                <asp:DropDownList ID="ddlTipoCategoria" runat="server" SelectedValue='<%# Bind("tipo_categoria")%>'>
                                                  <asp:ListItem Value="0">[]</asp:ListItem>
                                                  <asp:ListItem Value="1">Onde fazer a sua FESTA</asp:ListItem>
                                                  <asp:ListItem Value="2">Serviços para FESTA</asp:ListItem>
                                                </asp:DropDownList>                                             
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                                <asp:DropDownList ID="ddlTipoCategoria" runat="server" >
                                                  <asp:ListItem Value="0">[]</asp:ListItem>
                                                  <asp:ListItem Value="1">Onde fazer a sua FESTA</asp:ListItem>
                                                  <asp:ListItem Value="2">Serviços para FESTA</asp:ListItem>
                                                </asp:DropDownList>                                             
                                           </FooterTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Texto" SortExpression="texto">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="txtTexto" runat="server" Height="50px" 
                                                   Text='<%# Bind("texto") %>' TextMode="MultiLine" Width="300px" />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:TextBox ID="txtTexto" runat="server" Height="50px" TextMode="MultiLine" 
                                                   Width="300px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="lblTexto" runat="server" Text='<%# Eval("texto") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="ExcluirCategoria" 
    InsertMethod="IncluirCategoria" SelectMethod="DadosCategoria" 
    TypeName="WebService" UpdateMethod="IncluirCategoria" ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onupdating="ObjectDataSource1_Updating">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="nome" Type="String" />
                                       <asp:Parameter Name="tipocategoria" Type="Int32" />
                                       <asp:Parameter Name="observacao" Type="String" />
                                   </UpdateParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="nome" Type="String" />
                                       <asp:Parameter Name="tipocategoria" Type="Int32" />
                                       <asp:Parameter Name="observacao" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                           </ContentTemplate>
                       </asp:UpdatePanel>
                   </td>
                   <td class="style1">
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
                   <td >
                       &nbsp;</td>
               </tr>
               
               <tr>
                   <td>
                       &nbsp;</td>                       
                   <td>
                     <asp:GridView ID="grdRelCategoria" runat="server" 
                     CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
                     GridLines="Horizontal" AutoGenerateColumns="False" Font-Names="Arial" 
                                   Font-Size="11px" >
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#CCCCCC" />
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>                                      
                                   
                                       <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <ItemTemplate>
                                               <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Descriçao" SortExpression="descricao">
                                           <ItemTemplate>
                                               <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("descricao") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Tipo" SortExpression="tipo_categoria">
                                           <ItemTemplate>
                                                <asp:DropDownList ID="ddlTipoCategoria" runat="server" SelectedValue='<%# Bind("tipo_categoria")%>'>
                                                  <asp:ListItem Value="0">[]</asp:ListItem>
                                                  <asp:ListItem Value="1">Onde fazer a sua FESTA</asp:ListItem>
                                                  <asp:ListItem Value="2">Serviços para FESTA</asp:ListItem>
                                                </asp:DropDownList>
                                           </ItemTemplate>                                       
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Texto" SortExpression="texto">
                                           <ItemTemplate>
                                               <asp:Label ID="lblTexto" runat="server" Text='<%# Eval("texto") %>' />
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
