<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teste.aspx.cs" Inherits="teste" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>
       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"></cc1:ToolkitScriptManager>

                                        <cc1:Accordion ID="accAnunciante" runat="server" FadeTransitions="true"
                                        TransitionDuration="250" HeaderCssClass="accordionHeader" 
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
                                        <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="bord-baixa" align="center" colspan="3" valign="middle" style="margin:0;padding:0; height:10px;">
                                                                               
                                                </td>
                                            </tr>
                                        </table>                                  


       </center>   
    </div>
    </form>
</body>
</html>
