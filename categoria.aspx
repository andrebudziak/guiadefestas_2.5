<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="categoria.aspx.cs" Inherits="categoria" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
    <table border="0" cellpadding="0" cellspacing="0" style="width:400px;">
               <tr>
                   <td align="center" bgcolor="#FFCC66" >
                       <table border="0" cellpadding="0" cellspacing="0" style="width:400px;">
                           <tr>
                               <td align="left" height="30px">
                               
                                                      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                                          SelectMethod="ConsultaAnuncioTela" 
                                       TypeName="WebService" onselecting="ObjectDataSource1_Selecting">
                                                          <SelectParameters>
                                                              <asp:Parameter DefaultValue="1" Name="codigo_categoria" Type="Int32" />
                                                              <asp:Parameter DefaultValue="0" Name="nome_fantasia" Type="String" />
                                                              <asp:Parameter DefaultValue="0" Name="ordem" Type="String" />
                                                          </SelectParameters>
                                                      </asp:ObjectDataSource>
                                   
                                                      <table style="width:100%;">
                                                          <tr>
                                                              <td width="50%">
                                                                 <asp:Label ID="lblTituloCat" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                                                    Font-Size="14px" ForeColor="#FF6600"></asp:Label>  
                                                              
                                                              </td>
                                                              <td>
                                                              </td>
                                                              <td align="right" width="50%">
                                                                 <asp:DropDownList ID="ddlFiltro" runat="server" 
                                                                    AutoPostBack="True" Font-Names="Verdana" Font-Size="12px" ForeColor="#FF6600" 
                                                                    onselectedindexchanged="ddlFiltro_SelectedIndexChanged" 
                                                                    style="border-left-color: White; border-bottom-color: White; border-top-style: outset; border-top-color: White; border-right-style: outset; border-left-style: outset; border-right-color: White; border-bottom-style: outset">
                                                                    <asp:ListItem Value="0">Filtrar Anuncios por:</asp:ListItem>
                                                                    <asp:ListItem Value="nome_fantasia">NOME</asp:ListItem>
                                                                    <asp:ListItem Value="bairro">BAIRRO</asp:ListItem>
                                                                 </asp:DropDownList>                                                              
                                                             </td>
                                                          </tr>
                                                      </table>
                                   
                               </td>
                           </tr>
                       </table>
                  </td>
                 
               </tr>
               <tr>
                   <td align="center" style="width: 400px;">
               
                               <asp:DataList ID="dlAnunciante" runat="server" ShowFooter="False" 
                ShowHeader="False" onitemdatabound="dlAnunciante_ItemDataBound" Width="400px" 
                                   DataSourceID="ObjectDataSource1" BorderWidth="0px" CellPadding="0" 
                           onitemcommand="dlAnunciante_ItemCommand">
                                   <AlternatingItemStyle Font-Bold="False" Font-Italic="False" 
                                       Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                   <ItemTemplate>
                                        <cc1:Accordion ID="accAnunciante" runat="server" FadeTransitions="true"
                                        TransitionDuration="150" HeaderCssClass="accordionHeader" 
                                        ContentCssClass="accordionContent" 
               AutoSize="None" FramesPerSecond="40" 
                                        RequireOpenedPane="False" 
               SuppressHeaderPostbacks="True" Width="400px">
                                        <Panes>
                                            <cc1:AccordionPane ID="accAnuncio" runat="server">
                                            <Header> 
                                            </Header>
                                            <Content>
                                                  <table style="margin:0;padding:0;width:100%;" >
                                                   <tr>
                                                       <td align="left" style="margin:0;padding:0;width:140px;height:100px;" valign="middle">
                                                          <asp:HyperLink ID="aLogo" runat="server" Target="_blank" > 
                                                             <asp:ImageButton ID="btnImgLogo" CommandName="ContaClick" runat="server" Width="136px" Height="96px"  />
                                                          </asp:HyperLink>
                                                       </td>
                                                       <td style="margin:0;padding:0;width:220px;height:100px;" valign="middle" align="left">
                                                           <table>
                                                               <tr>
                                                                   <td class='TituloCinzaEscuro' align="left">
                                                                       <asp:Label ID="lblCodigoAnuncio" runat="server" Text="" Visible="false"></asp:Label>
                                                                       <asp:Label ID="lblNomeFantasia" runat="server" Text=""></asp:Label>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td class='TituloCinzaEscuro2' align="left" >
                                                                       <asp:Label ID="lblBairroCidade" runat="server" Text=""></asp:Label>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td class='TituloCinzaEscuro3' align="left" >
                                                                       <asp:Label ID="lblEndereco" runat="server" Text=""></asp:Label>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td class='TituloCinzaEscuro3' align="left" >
                                                                       <asp:Label ID="lblTelefone" runat="server" Text=""></asp:Label>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                              <td align="left">
                                                              <table style="width: 150px;" border="0" cellpadding="0" cellspacing="1">
                                                              <tr>
                                                                 <td align="left" width="50px" valign="bottom" >
                                                                    <asp:HyperLink ID="aOrkut" runat="server" Target="_blank"> 
                                                                       <img ID="imgOrkut" runat="server" alt="Acesse meu Orkut" width="51" height="17" src="/imagens/orkAtivo.jpg" style="border:0;" /> 
                                                                    </asp:HyperLink>
                                                                 </td>
                                                                 <td align="left" width="50px" valign="bottom">
                                                                    <asp:HyperLink ID="aFacebook" runat="server" Target="_blank" > 
                                                                       <img ID="imgFacebook" runat="server" alt="Acesse meu Facebook" width="51" height="17" src="imagens/facebAtivo.jpg" style="border:0;"  /> 
                                                                    </asp:HyperLink>
                                                                 </td>
                                                                 <td align="left" width="50px" valign="bottom">                                                            
                                                                    <asp:HyperLink ID="aTwitter" runat="server" Target="_blank"> 
                                                                       <img ID="imgTwitter" runat="server" alt="Acesse meu Facebook" width="51" height="17" src="imagens/twitAtivo.jpg" style="border:0;" /> 
                                                                    </asp:HyperLink>
                                                                 </td>
                                                              </tr>                                                             
                                                              </table>                                                                          
                                                              </td>
                                                               </tr>
                                                           </table>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                      <td align="center" colspan="3" valign="middle" style="margin:0;padding:0;height:50px;">
                                                          <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                                                              <tr>
                                                                 <td align="center" >                                         
                                                                    <h2>                
                                                                    <asp:HyperLink ID="aSite" runat="server" Target="_blank" >
                                                                       <asp:ImageButton ID="btnImgSite" CommandName="ContaClick" runat="server" ImageUrl="imagens/WEB.png"  />                                                               
                                                                    </asp:HyperLink>
                                                                    </h2>
                                                                 </td>
                                                                 <td align="center" >
                                                                    <asp:HyperLink ID="aEmail" runat="server" > 
                                                                       <img ID="imgEmail" runat="server" alt="Envie-nos um email" src="imagens/EMAIL.png" style="border:0;" />
                                                                    </asp:HyperLink>

                                                                 </td>
                                                              </tr>
                                                              <tr>
                                                                 <td colspan="3" style="vertical-align:middle; text-align:center;">
                                                                    <table style="margin:0;padding:0;width:100%;">
                                                                    <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblFacebook" runat="server"></asp:Label>
                                                                    &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTwitter" runat="server"></asp:Label>
                                                                    &nbsp;
                                                                    </td>
                                                                    <td>
                                                                    &nbsp;
                                                                        <asp:Label ID="lblGMais" runat="server"></asp:Label>
                                                                    </td>
                                                                    </tr></table>
                                                                 </td>
                                                              </tr>
                                                          </table>                                             
                                                      </td>
                                                   </tr>
                                                   <tr>
                                                      <td>
                                                                               
                                                      </td>
                                                   </tr>
                                               </table>
                                            </Content>
                                            </cc1:AccordionPane>          
                                            <cc1:AccordionPane ID="AccordionPane2" runat="server">
                                            <Header>Clique aqui para ver a Agenda de Festas</Header>
                                            <Content>
                                                <table style="width: 350px; " border="0" cellpadding="0" 
                                                    cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label2" runat="server" CssClass="TituloCinzaEscuro2" 
                                                                Text="Selecione um Mês para ver a agenda"></asp:Label>
                                                           <asp:Label ID="lblCodAnuncio" runat="server" Text="" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:DropDownList ID="ddlMes" runat="server" Width="340px" onselectedindexchanged="ddlMes_SelectedIndexChanged">
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label1" runat="server" CssClass="TituloCinzaEscuro2" 
                                                                Text="Descrição Festa(s) Agendada(s)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="100px" Width="340px" Wrap="false">
                                                                <asp:TextBox ID="txtInformacoes" TextMode="MultiLine" runat="server" 
                                                                    CssClass="TextoCinzaEscuro2" Width="500px" Height="200px"></asp:TextBox>
                                                                     
                                                            </asp:Panel>
                                                            <cc1:RoundedCornersExtender ID="Panel1_RoundedCornersExtender" runat="server" 
                                                                BorderColor="ActiveBorder" Enabled="True" TargetControlID="Panel1">
                                                            </cc1:RoundedCornersExtender>
                                                        </td>
                                                    </tr>
                                                    </table>

                                            </Content>                                           
                                            </cc1:AccordionPane>          
                                                

                                        </Panes>
                                        </cc1:Accordion>
                                        <table style="width: 400px;" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="bord-baixa" align="center" colspan="3" valign="middle" style="margin:0;padding:0; height:10px;">
                                                                               
                                                </td>
                                            </tr>
                                        </table>                                  


                                                         
                                       
                                   </ItemTemplate>
                               </asp:DataList>
                                                                   
                  </td>
                 
               </tr>
               </table>
               
                    
                    
                    
       </ContentTemplate>                          
    </asp:UpdatePanel>
               

</asp:Content>

