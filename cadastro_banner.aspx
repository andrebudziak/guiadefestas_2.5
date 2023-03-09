<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro_banner.aspx.cs" Inherits="cadastro_banner" %>

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
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <ContentTemplate>
                      
                      
                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                          <tr>
                              <td>
                  
                                               &nbsp;</td>
                              <td>
                  
                                               &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td align="left">
                                  <asp:Button ID="btnAnuncioCategoria" runat="server" CssClass="BotaoSubmit" 
                                      onclick="btnAnuncioCategoria_Click" Text="Categoria Banner" />
                                  <cc1:ModalPopupExtender ID="btnAnuncioCategoria_ModalPopupExtender" 
                                      runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnFechar" 
                                      Drag="True" DynamicServicePath="" Enabled="True" OnOkScript="onOk()" 
                                      PopupControlID="pnAnuncioCategoria" TargetControlID="btnAnuncioCategoria">
                                  </cc1:ModalPopupExtender>
                                  <asp:Button ID="btnExportaExcel" runat="server" CssClass="BotaoSubmit" 
                                      onclick="btnExportaExcel_Click" Text="Exporta para Excel" />
                              </td>
                              <td align="left">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td align="center" colspan="3">
                                  <asp:Panel ID="pnAnuncioCategoria" runat="server" BackColor="White" 
                                   Height="300px" Width="600px">
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
                                                   height="230px" marginheight="0" marginwidth="0" scrolling="auto" 
                                                   width="600px">
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
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:GridView ID="grdDados" runat="server" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                  Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                  Width="800px" AutoGenerateColumns="False" 
                                   onrowcommand="grdDados_RowCommand" onrowcreated="grdDados_RowCreated" 
                                   ShowFooter="True" onrowdeleting="grdDados_RowDeleting" AllowPaging="True" 
                                   onrowediting="grdDados_RowEditing" 
                                   onrowcancelingedit="grdDados_RowCancelingEdit" >
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
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
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtCodigo" runat="server" Width="20px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Anunciante">
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" Width="250px" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_cliente")%>'
                                                   DataSourceID="ObjectDataSource3">                                                   
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" Width="250px" 
                                                  DataTextField="nome_fantasia" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource3">
                                               </asp:DropDownList>
                                           </FooterTemplate>                                           
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlCliente" runat="server" Enabled="false" Width="250px"
                                                  DataTextField="nome_fantasia" DataValueField="codigo" SelectedValue='<%# Bind("codigo_cliente")%>'
                                                   DataSourceID="ObjectDataSource3">                                                   
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="150px" Text='<%# Bind("descricao") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("descricao") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtDescricao" runat="server" Width="150px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                
                                       <asp:TemplateField HeaderText="Local">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBanner" runat="server" Text='<%# Bind("local") %>'></asp:Label>
                                           </ItemTemplate>
                                           <EditItemTemplate>
                                               <asp:DropDownList ID="ddlLocalBanner" runat="server" 
                                                  DataTextField="descricao" DataValueField="codigo" SelectedValue='<%# Eval("codigo_local_banner")%>'
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>
                                           </EditItemTemplate>
                                           <FooterTemplate>
                                               <asp:DropDownList ID="ddlLocalBanner" runat="server" 
                                                  DataTextField="descricao" DataValueField="codigo"
                                                   DataSourceID="ObjectDataSource2">
                                               </asp:DropDownList>                                           
                                           </FooterTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Largura" SortExpression="largura">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtLargura" runat="server" Width="50px" Text='<%# Bind("largura") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblLargura" runat="server" Text='<%# Eval("largura") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtLargura" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Altura" SortExpression="altura">
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtAltura" runat="server" Width="50px" Text='<%# Bind("altura") %>' />
                                           </EditItemTemplate>
                                           <ItemTemplate>
                                              <asp:Label ID="lblAltura" runat="server" Text='<%# Eval("altura") %>' />
                                           </ItemTemplate>
                                           <FooterTemplate>
                                              <asp:TextBox ID="txtAltura" runat="server" Width="50px" />
                                           </FooterTemplate>
                                        </asp:TemplateField>                                       
                                       <asp:TemplateField HeaderText="Status">
                                          <ItemTemplate>
                                             <asp:DropDownList ID="ddlStatus" Width="65px" runat="server" SelectedValue='<%# Bind("status")%>' Enabled="false" >
                                                <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Inativo"></asp:ListItem>
                                             </asp:DropDownList>
                                          </ItemTemplate>
                                             <EditItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" Width="65px" runat="server" SelectedValue='<%# Bind("status")%>' >
                                                   <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                                   <asp:ListItem Value="0" Text="Inativo"></asp:ListItem>
                                                </asp:DropDownList>
                                             </EditItemTemplate>
                                             <FooterTemplate>
                                                <asp:DropDownList ID="ddlStatus" Width="65px" runat="server"  >
                                                   <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                                   <asp:ListItem Value="0" Text="Inativo"></asp:ListItem>
                                                </asp:DropDownList>                                             
                                             </FooterTemplate>
                                       </asp:TemplateField>    
                                                                        
                                   </Columns>
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#CCCCCC" Font-Names="Arial" Font-Size="11px" />
                                   <AlternatingRowStyle BackColor="White" />
                               </asp:GridView>
                               <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                               <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="ExcluirBanner" 
                                   InsertMethod="IncluirBanner" SelectMethod="ConsultaBanner" 
                                   TypeName="WebService" UpdateMethod="IncluirBanner" 
                                   ondeleting="ObjectDataSource1_Deleting" 
                                   oninserting="ObjectDataSource1_Inserting" 
                                   onselected="ObjectDataSource1_Selected" 
                                   onupdating="ObjectDataSource1_Updating">
                                   <DeleteParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                   </DeleteParameters>
                                   <UpdateParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="posicaoBanner" Type="Int32" />
                                       <asp:Parameter Name="largura" Type="Int32" />
                                       <asp:Parameter Name="altura" Type="Int32" />
                                       <asp:Parameter Name="status" Type="Int32" />
                                   </UpdateParameters>
                                   <SelectParameters>
                                       <asp:Parameter DefaultValue="0" Name="codigo_banner" Type="Int32" />
                                   </SelectParameters>
                                   <InsertParameters>
                                       <asp:Parameter Name="codigo" Type="Int32" />
                                       <asp:Parameter Name="codigo_cliente" Type="Int32" />
                                       <asp:Parameter Name="descricao" Type="String" />
                                       <asp:Parameter Name="posicaoBanner" Type="Int32" />
                                       <asp:Parameter Name="largura" Type="Int32" />
                                       <asp:Parameter Name="altura" Type="Int32" />
                                       <asp:Parameter Name="status" Type="Int32" />
                                   </InsertParameters>
                               </asp:ObjectDataSource>
                               <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                   SelectMethod="ConsultaLocalBanner" TypeName="WebService">
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
               <tr>
                  <td>
                        <asp:GridView ID="grdRelBanner" runat="server" CellPadding="4" DataSourceID="ObjectDataSource1" 
                                  Font-Names="Arial" Font-Size="11px" ForeColor="#333333" GridLines="Horizontal" 
                                  Width="800px" AutoGenerateColumns="False"                                    
                                   ShowFooter="True" onrowdeleting="grdDados_RowDeleting" >
                                   <PagerSettings Position="Top" />
                                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                   <Columns>                                      
                                        <asp:TemplateField HeaderText="Codigo" SortExpression="codigo">
                                           <ItemTemplate>
                                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                           <ItemTemplate>
                                              <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("descricao") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                
                                       <asp:TemplateField HeaderText="Local">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBanner" runat="server" Text='<%# Bind("local") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Largura" SortExpression="largura">
                                           <ItemTemplate>
                                              <asp:Label ID="lblLargura" runat="server" Text='<%# Eval("largura") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Altura" SortExpression="altura">
                                           <ItemTemplate>
                                              <asp:Label ID="lblAltura" runat="server" Text='<%# Eval("altura") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>                                       
                                       <asp:TemplateField HeaderText="Status">
                                          <ItemTemplate>
                                             <asp:Label ID="Label2" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                          </ItemTemplate>
                                       </asp:TemplateField>                                                                            
                                   </Columns>
                                   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                   <EditRowStyle BackColor="#CCCCCC" Font-Names="Arial" Font-Size="11px" />
                                   <AlternatingRowStyle BackColor="White" />
                               </asp:GridView>                  
                  </td>
               </tr>
           
           </table>
       
       </center>    
    </div>
    </form>
</body>
</html>
