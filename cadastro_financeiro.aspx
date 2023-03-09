<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_financeiro.aspx.cs" Inherits="cadastro_financeiro" %>

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
           <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
               <tr>
                   <td align="center">
                       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                       </cc1:ToolkitScriptManager>
                   </td>                 
               </tr>             
               <tr>
                   <td align="center">
                   <asp:Label ID="lblHash" runat="server"></asp:Label>
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:GridView ID="grdFinanceiro" runat="server" 
                                   CellPadding="4" DataSourceID="ObjectDataSource1" Font-Names="Arial" 
                                   Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" Width="800px" 
                                   AutoGenerateColumns="False" onrowcommand="grdFinanceiro_RowCommand" 
                                   onrowcreated="grdFinanceiro_RowCreated" ShowFooter="True" 
                                   onrowdeleting="grdFinanceiro_RowDeleting">
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
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>                                        
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" Text='<%# Bind("codigo") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Anunciante">
                                           <ItemTemplate>
                                               <asp:Label ID="lblAnunciante" runat="server" Text='<%# Eval("nome_fantasia") %>' />
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_cliente")%>'
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                       </asp:TemplateField>                                        
                                       <asp:TemplateField HeaderText="Mes">
                                           <ItemTemplate>
                                             <asp:DropDownList ID="ddlMes" runat="server" SelectedValue='<%# Bind("mes")%>'>
                                                <asp:ListItem Value="1" Text="Janeiro"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Fevereiro"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Março"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Abril"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Maio"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Junho"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Julho"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Agosto"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="Setembro"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="Outubro"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Novembro"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Dezembro"></asp:ListItem>
                                             </asp:DropDownList>
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                             <asp:DropDownList ID="ddlMes" runat="server" SelectedValue='<%# Bind("mes")%>'>
                                                <asp:ListItem Value="1" Text="Janeiro"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Fevereiro"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Março"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Abril"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Maio"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Junho"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Julho"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Agosto"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="Setembro"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="Outubro"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Novembro"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Dezembro"></asp:ListItem>
                                             </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                             <asp:DropDownList ID="ddlMes" runat="server" >
                                                <asp:ListItem Value="1" Text="Janeiro"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Fevereiro"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Março"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Abril"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Maio"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Junho"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Julho"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Agosto"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="Setembro"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="Outubro"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Novembro"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Dezembro"></asp:ListItem>
                                             </asp:DropDownList>
                                           </FooterTemplate>                                           
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vencimento" SortExpression="vencimento">
                                           <ItemTemplate>
                                              <asp:Label ID="lblVencimento" runat="server" Text='<%# Eval("vencimento") %>' />
                                           </ItemTemplate>                                        
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtVencimento" runat="server" Width="100px" Text='<%# Bind("vencimento") %>' />
                                              <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtVencimento" runat="server">
                                              </cc1:CalendarExtender>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtVencimentoF" runat="server" Width="100px" />
                                               <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtVencimentoF" runat="server">
                                               </cc1:CalendarExtender>
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mensalidade" SortExpression="mensalidade">
                                           <ItemTemplate>
                                              <asp:Label ID="lblMensalidade" runat="server" Text='<%# Eval("mensalidade") %>' />
                                           </ItemTemplate>                                        
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtMensalidade" runat="server" Width="50px" Text='<%# Bind("mensalidade") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtMensalidade" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Boleto" SortExpression="boleto">
                                           <ItemTemplate>
                                              <asp:Label ID="lblBoleto" runat="server" Text='<%# Eval("boleto") %>' />
                                           </ItemTemplate>                                        
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtBoleto" runat="server" Width="50px" Text='<%# Bind("boleto") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtBoleto" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Observação" SortExpression="observacao">
                                           <EditItemTemplate>
                                               <asp:TextBox ID="txtObservacao" runat="server" Height="50px" 
                                                   Text='<%# Bind("observacao") %>' TextMode="MultiLine" Width="300px" />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:TextBox ID="txtObservacao" runat="server" Height="50px" TextMode="MultiLine" 
                                                   Width="300px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:Label ID="lblObservacao" runat="server" Text='<%# Eval("observacao") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   
                                   
                                   </Columns>
                               </asp:GridView>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                   DeleteMethod="ExcluirFinanceiro" InsertMethod="IncluirFinanceiro" 
                                   SelectMethod="ConsultaFinanceiro" TypeName="WebService" 
                                   UpdateMethod="IncluirFinanceiro" ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onupdating="ObjectDataSource1_Updating">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="mes" Type="Int32" />
                                       <asp:Parameter Name="vencimento" Type="DateTime" />
                                       <asp:Parameter Name="mensalidade" Type="Single" />
                                       <asp:Parameter Name="boleto" Type="String" />
                                       <asp:Parameter Name="observacao" Type="String" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="mes" Type="Int32" />
                                       <asp:Parameter Name="vencimento" Type="DateTime" />
                                       <asp:Parameter Name="mensalidade" Type="Single" />
                                       <asp:Parameter Name="boleto" Type="String" />
                                       <asp:Parameter Name="observacao" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService">
                               </asp:ObjectDataSource>
                               
                           </ContentTemplate>
                       </asp:UpdatePanel>
                   </td>                 
               </tr>             
               <tr>
                   <td align="center">
                       <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                           AssociatedUpdatePanelID="UpdatePanel1">
                           <ProgressTemplate>
                               <img alt="" src="imagens/wait.gif" 
    style="width: 50px; height: 50px" />Aguarde...</ProgressTemplate>
                       </asp:UpdateProgress>
                   </td>                 
               </tr>             
           </table>
       </center>    
    </div>
    </form>
</body>
</html>
