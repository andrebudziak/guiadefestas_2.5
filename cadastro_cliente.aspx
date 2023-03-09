<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_cliente.aspx.cs" Inherits="cadastro_cliente" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
       
      
           <table border="0" cellpadding="0" cellspacing="0" style="width:800px;">
               <tr>
                   <td align="center">
                       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                       </cc1:ToolkitScriptManager>
                   </td>
               </tr>
               <tr>
                   <td align="center">            
        <asp:Label ID="lblHash" runat="server"></asp:Label>                   
                   </td>
               </tr>
               <tr>
                   <td align="center">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               
                               <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
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
                                                       <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                                           onclick="btnExportaExcel_Click" Text="Exporta para Excel" />
                                                   </td>
                                                   <td>
                                                       &nbsp;</td>
                                                   <td>
                                                       &nbsp;</td>
                                               </tr>
                                           </table>
                                       </td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td align="center" colspan="3">
                              <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False" 
                                   CellPadding="4" Font-Names="Arial" Font-Size="11px" ForeColor="#333333" 
                                   GridLines="Horizontal" Width="800px" DataSourceID="ObjectDataSource2" 
                                   AllowSorting="True" onrowcommand="grdCliente_RowCommand" 
                                   onrowcreated="grdCliente_RowCreated" ShowFooter="True" 
                                   onrowdeleting="grdCliente_RowDeleting" AllowPaging="True" 
                                               onrowcancelingedit="grdCliente_RowCancelingEdit">
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
                                             <asp:LinkButton ID="LinkButtonDelete" runat="server"  CssClass="deletar" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Deseja excluir o registro?');" Text="Deletar" />
                                          </ItemTemplate>
                                          <FooterTemplate>
                                             <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="true" CommandName="Save" Text="Salvar" />
                                          </FooterTemplate>
                                       </asp:TemplateField>                                     
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCodigo" Enabled="false" runat="server" Width="20px" Text='<%# Bind("codigo") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nome Fantasia" SortExpression="nome_fantasia">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtNomeFantasia" runat="server" Width="200px" Text='<%# Bind("nome_fantasia") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblNomeFantasia" runat="server" Text='<%# Eval("nome_fantasia") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtNomeFantasia" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                                                                            
                                        <asp:TemplateField HeaderText="Razão Social" SortExpression="razao_social">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtRazaoSocial" runat="server" Width="200px" Text='<%# Bind("razao_social") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblRazaoSocial" runat="server" Text='<%# Eval("razao_social") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtRazaoSocial" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="C.N.P.J" SortExpression="cnpj">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCnpj" runat="server" Width="50px" Text='<%# Bind("cnpj") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCnpj" runat="server" Text='<%# Eval("cnpj") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCnpj" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="C.P.F" SortExpression="cpf">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCpf" runat="server" Width="50px" Text='<%# Bind("cpf") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCpf" runat="server" Text='<%# Eval("cpf") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCpf" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="R.G" SortExpression="rg">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtRg" runat="server" Width="50px" Text='<%# Bind("rg") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblRg" runat="server" Text='<%# Eval("rg") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtRg" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtEndereco" runat="server" Width="200px" Text='<%# Bind("endereco") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblEndereco" runat="server" Text='<%# Eval("endereco") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtEndereco" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Bairro" SortExpression="bairro">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtBairro" runat="server" Width="100px" Text='<%# Bind("bairro") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblBairro" runat="server" Text='<%# Eval("bairro") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtBairro" runat="server" Width="100px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Cidade" SortExpression="cidade">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCidade" runat="server" Width="100px" Text='<%# Bind("cidade") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCidade" runat="server" Text='<%# Eval("cidade") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCidade" runat="server" Width="100px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Cep" SortExpression="cep">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtCep" runat="server" Width="50px" Text='<%# Bind("cep") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblCep" runat="server" Text='<%# Eval("cep") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCep" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtEmail" runat="server" Width="200px" Text='<%# Bind("email") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtEmail" runat="server" Width="200px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Responsavel" SortExpression="responsavel">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtResponsavel" runat="server" Width="100px" Text='<%# Bind("responsavel") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("responsavel") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtResponsavel" runat="server" Width="100px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Telefone" SortExpression="telefone">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtTelefone" runat="server" Width="50px" Text='<%# Bind("telefone") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefone") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtTelefone" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                     </Columns>
                                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                     <PagerSettings Position="Top" />
                                     <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Wrap="false" />
                                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                  </asp:GridView>                           
                           
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                           
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   DeleteMethod="ExcluirCliente" InsertMethod="IncluirCliente" 
                                   SelectMethod="ConsultaCliente" TypeName="WebService" 
                                   UpdateMethod="IncluirCliente" oninserting="ObjectDataSource2_Inserting" 
                                   onselected="ObjectDataSource2_Selected" 
                                   ondeleting="ObjectDataSource2_Deleting" 
                                   onupdating="ObjectDataSource2_Updating" onselecting="ObjectDataSource2_Selecting">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" DefaultValue="0" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="razao_social" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="nome_fantasia" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="cnpj" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="cpf" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="rg" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="endereco" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="cep" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="bairro" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="cidade" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="email" DefaultValue=""  Type="String" />
                                       <asp:Parameter Name="responsavel" DefaultValue="" Type="String" />
                                       <asp:Parameter Name="telefone" DefaultValue="" Type="String" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="nome" DefaultValue="0" Type="String" />                                       
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="razao_social" Type="String" />
                                       <asp:Parameter Name="nome_fantasia" Type="String" />
                                       <asp:Parameter Name="cnpj" Type="String" />
                                       <asp:Parameter Name="cpf" Type="String" />
                                       <asp:Parameter Name="rg" Type="String" />
                                       <asp:Parameter Name="endereco" Type="String" />
                                       <asp:Parameter Name="cep" Type="String" />
                                       <asp:Parameter Name="bairro" Type="String" />
                                       <asp:Parameter Name="cidade" Type="String" />
                                       <asp:Parameter Name="email" Type="String" />
                                       <asp:Parameter Name="responsavel" Type="String" />
                                       <asp:Parameter Name="telefone" Type="String" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                                       
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
    style="width: 50px; height: 50px" />Aguarde...
                           </ProgressTemplate>
                       </asp:UpdateProgress>
                   </td>
               </tr>
               <tr>
                  <td>
                     <asp:GridView ID="grdRelCliente" runat="server" AutoGenerateColumns="False" 
                                   CellPadding="4" Font-Names="Arial" Font-Size="11px" ForeColor="#333333" 
                                   GridLines="Horizontal" Width="800px" DataSourceID="ObjectDataSource2" 
                                   AllowSorting="False" >
                                  <EditRowStyle BackColor="#CCCCCC" Font-Names="Arial" Font-Size="11px" />
                                  <AlternatingRowStyle BackColor="White" />
                                     <Columns>                                       
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nome Fantasia" SortExpression="nome_fantasia">
                                           <ItemTemplate>
                                              <asp:Label ID="lblNomeFantasia" runat="server" Text='<%# Eval("nome_fantasia") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                                                                            
                                        <asp:TemplateField HeaderText="Razão Social" SortExpression="razao_social">
                                           <ItemTemplate>
                                              <asp:Label ID="lblRazaoSocial" runat="server" Text='<%# Eval("razao_social") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="C.N.P.J" SortExpression="cnpj">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCnpj" runat="server" Text='<%# Eval("cnpj") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="C.P.F" SortExpression="cpf">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCpf" runat="server" Text='<%# Eval("cpf") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="R.G" SortExpression="rg">
                                           <ItemTemplate>
                                              <asp:Label ID="lblRg" runat="server" Text='<%# Eval("rg") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                                           <ItemTemplate>
                                              <asp:Label ID="lblEndereco" runat="server" Text='<%# Eval("endereco") %>' />
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
                                        <asp:TemplateField HeaderText="Cep" SortExpression="cep">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCep" runat="server" Text='<%# Eval("cep") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                           <ItemTemplate>
                                              <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Responsavel" SortExpression="responsavel">
                                           <ItemTemplate>
                                              <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("responsavel") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Telefone" SortExpression="telefone">
                                           <ItemTemplate>
                                              <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefone") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                        
                                     </Columns>
                                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                     <PagerSettings Position="Top" />
                                     <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Wrap="false" />
                                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                  </asp:GridView>                                                                     
                  
                  </td>
               </tr>
               </table>
       
       </center>    
    </div>
    </form>
</body>
</html>
