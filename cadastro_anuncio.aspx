<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_anuncio.aspx.cs" Inherits="cadastro_anuncio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />    
   
</head>
<body>

    <form id="frmPrincipal" runat="server">
    <div>
       <center>
       
           <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
               <tr>
                   <td>
                       </td>
                   <td  >
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                                           </td>
                   <td  >
                       </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="lblHash" runat="server"></asp:Label>
                   </td>
                   <td>
                       &nbsp;</td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td>
                       &nbsp;</td>
                   <td align="left">
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           <ContentTemplate>
                   
                       <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                           <tr>
                               <td>
                                   &nbsp;
                                   </td>
                               <td>
                                   &nbsp;
                                   <table style="width:200px;" border="0" cellpadding="0" cellspacing="0">
                                       <tr>
                                           <td>
                                               <asp:Label ID="Label1" runat="server" CssClass="TituloCinzaEscuro" 
                                                   Text="Pesquisar:"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtValor" runat="server" Font-Names="Arial" Font-Size="11px" 
                                                   Width="250px"></asp:TextBox>
                                               <cc1:AutoCompleteExtender ID="AutoCompleteExtenderDemo" runat="server" 
                                                   EnableCaching="false" MinimumPrefixLength="1" 
                                                   ServiceMethod="RetornaNomeCliente" ServicePath="WebService.asmx" 
                                                   TargetControlID="txtValor">
                                               </cc1:AutoCompleteExtender>
                                           </td>
                                           <td>
                                               <asp:ImageButton ID="btnBusca" runat="server" 
                                                   ImageUrl="~/imagens/PESQUISAR.png" onclick="btnBusca_Click" 
                                                   style="height: 33px" />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Button ID="btnAnuncioCategoria" runat="server" CssClass="BotaoSubmit" 
                                                   onclick="btnAnuncioCategoria_Click" Text="Categoria Anuncio" />
                                               <cc1:ModalPopupExtender ID="btnAnuncioCategoria_ModalPopupExtender" 
                                                   runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnFechar" 
                                                   Drag="True" DynamicServicePath="" Enabled="True" OnOkScript="onOk()" 
                                                   PopupControlID="pnAnuncioCategoria" TargetControlID="btnAnuncioCategoria">
                                               </cc1:ModalPopupExtender>
                                           </td>
                                           <td>
                                               <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                                   onclick="btnExportaExcel_Click" Text="Exporta para Excel" />
                                           </td>
                                           <td>
                                               &nbsp;</td>
                                       </tr>
                                   </table>
                               </td>
                               <td>
                                   &nbsp;
                                   </td>
                           </tr>
                           <tr>
                               <td align="center" colspan="3" >
                               <br />
                               <asp:Panel ID="pnAnuncioCategoria" runat="server" BackColor="White" 
                                   Height="480px" Width="640px">
                                   <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                       <tr>
                                           <td>
                                               &nbsp;</td>
                                           <td>
                                               &nbsp;</td>
                                           <td align="right">
                                               <asp:ImageButton ID="btnFechar" runat="server" 
                                                   ImageUrl="~/imagens/fechar.gif" />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td align="center" colspan="3">
                                               <iframe ID="ifCategoriaAnuncio" runat="server" align="middle" frameborder="0" 
                                                   height="480px" marginheight="0" marginwidth="0" scrolling="auto" 
                                                   width="640px">
                                               </iframe>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               &nbsp;</td>
                                           <td>
                                               &nbsp;</td>
                                           <td>
                                               &nbsp;</td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                               </td>
                            
                           </tr>
                       </table>
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
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                           <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                               <tr>
                                   <td align="center">
                                    
                                       <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                           <tr>
                                               <td>
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="PopulaAnuncio" TypeName="WebService">
                               </asp:ObjectDataSource>                             
                                               
                                               </td>
                                               <td>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                   DeleteMethod="ExcluirAnuncio" InsertMethod="IncluirAnuncio" 
                                   SelectMethod="ConsultaAnuncio" TypeName="WebService" 
                                   UpdateMethod="IncluirAnuncio" ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onupdating="ObjectDataSource1_Updating" 
                                                       onselecting="ObjectDataSource1_Selecting">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>                                   
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="cep" Type="String" />
                                       <asp:Parameter Name="bairro" Type="String" />
                                       <asp:Parameter Name="cidade" Type="String" />
                                       <asp:Parameter Name="endereco" Type="String" />
                                       <asp:Parameter Name="telefone" Type="String" />
                                       <asp:Parameter Name="email" Type="String" />
                                       <asp:Parameter Name="site" Type="String" />
                                       <asp:Parameter Name="status" Type="Int32" />
                                       <asp:Parameter Name="senha" Type="String" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo" Type="Int32" />
                                       <asp:Parameter DefaultValue="0" Name="nome" Type="String" />                                       
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="cep" Type="String" />
                                       <asp:Parameter Name="bairro" Type="String" />
                                       <asp:Parameter Name="cidade" Type="String" />
                                       <asp:Parameter Name="endereco" Type="String" />
                                       <asp:Parameter Name="telefone" Type="String" />
                                       <asp:Parameter Name="email" Type="String" />
                                       <asp:Parameter Name="site" Type="String" />
                                       <asp:Parameter Name="status" Type="Int32" />
                                       <asp:Parameter Name="senha" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                                               
                                               </td>
                                               <td>
                                                   <asp:Label ID="lblIndex" runat="server"></asp:Label>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>                                               
                                                   <asp:Label ID="lblCodigoAnuncio" runat="server" Text="Label"></asp:Label>
                               
                                               </td>
                                           </tr>
                                           <tr>
                                              <td align="center" colspan="3" >
                                                  &nbsp;</td>
                                           
                                           </tr>
                                           <tr>
                                               <td align="center" colspan="3" >
                  <asp:GridView ID="grdAnuncio" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                   DataSourceID="ObjectDataSource1" Font-Names="Arial" Font-Size="11px" 
                                   ForeColor="#333333" GridLines="Horizontal" Width="100%" 
                                   onrowcommand="grdAnuncio_RowCommand" onrowcreated="grdAnuncio_RowCreated" 
                                   onrowdeleting="grdAnuncio_RowDeleting" ShowFooter="True" 
                                   onrowediting="grdAnuncio_RowEditing" AllowPaging="True" 
                                                       onrowcancelingedit="grdAnuncio_RowCancelingEdit" 
                                                       onrowupdated="grdAnuncio_RowUpdated">
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="Silver" Font-Names="Arial" Font-Size="11px" />                                  
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField ShowHeader="False">
                                          <EditItemTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Atualizar" />
                                             <asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Save" Text="Salvar" />
                                          </FooterTemplate>
                                          <ItemTemplate>
                                             <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />                                       
                                            <asp:LinkButton ID="LinkButtonDelete" runat="server" CssClass="deletar" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Deseja excluir o registro?');" Text="Deletar" />                                          
                                          </ItemTemplate>
                                           <ItemStyle Width="100px" />
                                       </asp:TemplateField>                                   
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' ForeColor="#FFFBD6"  />
                                           </ItemTemplate>                                        
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Enabled="false" Width="20px" Text='<%# Bind("codigo") %>' />
                                           </EditItemTemplate>                                        
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                      
                                       <asp:TemplateField HeaderText="Anunciante">
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_cliente")%>'
                                                   DataSourceID="ObjectDataSource2">                                                   
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Enabled="false" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_cliente")%>'
                                                   DataSourceID="ObjectDataSource2">                                                   
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cep" SortExpression="cep">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCep" runat="server" Width="60px" Text='<%# Bind("cep") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCep" runat="server" Width="60px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCep" runat="server" Text='<%# Eval("cep") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="Bairro" SortExpression="bairro">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtBairro" runat="server" Width="60px" Text='<%# Bind("bairro") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtBairro" runat="server" Width="60px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblBairro" runat="server" Text='<%# Eval("bairro") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Cidade" SortExpression="cidade">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCidade" runat="server" Width="100px" Text='<%# Bind("cidade") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCidade" runat="server" Width="100px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCidade" runat="server" Text='<%# Eval("cidade") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtEndereco" runat="server" Width="200px" Text='<%# Bind("endereco") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtEndereco" runat="server" Width="200px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblEndereco" runat="server" Text='<%# Eval("endereco") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                                                              
                                        <asp:TemplateField HeaderText="Telefone" SortExpression="telefone">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtTelefone" runat="server" Width="150px" Text='<%# Bind("telefone") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtTelefone" runat="server" Width="150px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefone") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtEmail" runat="server" Width="200px" Text='<%# Bind("email") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtEmail" runat="server" Width="200px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Site" SortExpression="site">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtSite" runat="server" Width="150px" Text='<%# Bind("site") %>' />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtSite" runat="server" Width="150px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblSite" runat="server" Text='<%# Eval("site") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Senha" SortExpression="senha">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtSenha" runat="server" Width="40px" Text='<%# Bind("senha") %>'  />
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtSenha" runat="server" Width="40px" />
                                           </FooterTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblSenha" runat="server" Text='<%# Eval("senha") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                               
                                       <asp:TemplateField HeaderText="Status">
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("status")%>' >
                                                   <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                                   <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlStatus" runat="server"> 
                                                   <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                                   <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                               </asp:DropDownList>                                           
                                           </FooterTemplate>
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("status")%>' Enabled="false" >
                                                   <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                                   <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                       </asp:TemplateField>        
                                        <asp:TemplateField HeaderText="Acesso" SortExpression="acesso">                                          
                                           <ItemTemplate>
                                              <asp:Label ID="lblAcesso" runat="server" Text='<%# Eval("acesso") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                               
                                                                      
                                   
                                   </Columns>                                   
                               </asp:GridView>                                                                                              
              
                                               </td>
                                            
                                           </tr>
                                           <tr>
                                               <td>
                                                   &nbsp;</td>
                                               <td>
                                                   &nbsp;</td>
                                               <td>
                                                   &nbsp;</td>
                                           </tr>
                                       </table>
                                    
                                   </td>
                                   
                               </tr>
                               <tr>
                                   <td align="center">
                          
                                   
                                   </td>
                                  
                               </tr>
                           </table>
                       
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
               <tr>
                   <td>
                       &nbsp;</td>
                   <td>
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                           AssociatedUpdatePanelID="UpdatePanel2">
                           <ProgressTemplate>
                               <img alt="" src="imagens/wait.gif" 
    style="width: 50px; height: 50px" />Aguarde...
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
                                 <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"                                    
                                   SelectMethod="ConsultaRelAnuncio" TypeName="WebService">
                               </asp:ObjectDataSource>                   
                   
  <asp:GridView ID="grdRelAnuncio" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                   DataSourceID="ObjectDataSource3" Font-Names="Arial" Font-Size="11px" 
                                   ForeColor="#333333" GridLines="Horizontal" Width="100%" 
                                   >
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="Silver" Font-Names="Arial" Font-Size="11px" />                                  
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <asp:TemplateField HeaderText="Anunciante">
                                           <ItemTemplate>
                                              <asp:Label ID="lblAnunciante" runat="server" Text='<%# Eval("nome_fantasia") %>' />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cep" SortExpression="cep">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCep" runat="server" Text='<%# Eval("cep") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="Bairro" SortExpression="bairro">
                                           <ItemTemplate>
                                              <asp:Label ID="lblBairro" runat="server" Text='<%# Eval("bairro") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Cidade" SortExpression="cidade">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCidade" runat="server" Text='<%# Eval("cidade") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                                           <ItemTemplate>
                                              <asp:Label ID="lblEndereco" runat="server" Text='<%# Eval("endereco") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                                                              
                                        <asp:TemplateField HeaderText="Telefone" SortExpression="telefone">
                                           <ItemTemplate>
                                              <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefone") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                           <ItemTemplate>
                                              <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Site" SortExpression="site">
                                           <ItemTemplate>
                                              <asp:Label ID="lblSite" runat="server" Text='<%# Eval("site") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Senha" SortExpression="senha">
                                           <ItemTemplate>
                                              <asp:Label ID="lblSenha" runat="server" Text='<%# Eval("senha") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                               
                                       <asp:TemplateField HeaderText="Status">
                                           <ItemTemplate>
                                               <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                                                          
                                       <asp:TemplateField HeaderText="Clicks">
                                           <ItemTemplate>
                                               <asp:Label ID="lblAcesso" runat="server" Text='<%# Bind("acesso") %>'></asp:Label>
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
