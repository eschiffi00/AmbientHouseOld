<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Inicio.DegustacionDetalle.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Degustacion</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <h3>Segmento:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSegmentos" CssClass="form-control" runat="server" Width="100%" OnSelectedIndexChanged="DropDownListSegmentos_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanelComensales" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Panel ID="PanelSocial" runat="server">
                                                <div class="panel-heading">
                                                    <h3>Degustacion Social</h3>
                                                    <br />
                                                </div>
                                                <div class="panel-body">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3># Mesa *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNroMesaSoc" runat="server" CssClass="form-control"></asp:TextBox>
                                                                &nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3># Comensal *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNroComensalSoc" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Tipo de Evento *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTipoEvento" runat="server" CssClass="form-control" Width="100%">
                                                                </asp:DropDownList></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Nombre y Apellido *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNombreyApellidoSoc" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Telefono</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxTelefonoSoc" runat="server" CssClass="form-control" Width="70%"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Correo</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCorreoSoc" runat="server" CssClass="form-control" Width="70%"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Fecha Evento *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxFechaEventoSoc" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEventoSoc" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEventoSoc" TodaysDateFormat="" CssClass="black" />

                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Cantidad Invitados *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantInvitadosSoc" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                          <tr>
                                                            <td class="auto-style1">
                                                                <h3>Caracteristicas *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCaracteristicasSoc" runat="server" CssClass="form-control" Width="100%">
                                                                </asp:DropDownList></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                          <tr>
                                                            <td class="auto-style1">
                                                                <h3>Locacion *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListLocacionesSoc" runat="server" CssClass="form-control" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="auto-style1">
                                                                <h3>Comentario</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxComentarioSoc" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="50px"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="PanelCorporativo" runat="server">
                                                <div class="panel-heading">
                                                    <h3>Degustacion Corporativa</h3>
                                                    <br />
                                                </div>
                                                <div class="panel-body">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td class="auto-style1">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Empresa *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxEmpresa" runat="server" CssClass="form-control" Width="100%"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Nombre y Apellido</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNombreyApellidoCorp" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3># Mesa</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNroMesaCorp" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3># Comensal</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNroComensalCorp" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Fecha Evento *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxFechaEventoCorp" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEventoCorp" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEventoCorp" TodaysDateFormat="" CssClass="black" />

                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Cerrado/Por Cerrar *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListEstado" runat="server" CssClass="form-control">
                                                                    <asp:ListItem>Cerrado</asp:ListItem>
                                                                    <asp:ListItem>Por Cerrar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Cantidad Invitados *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantInvitadosCorp" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Caracteristicas *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCaracteristicasCorp" runat="server" CssClass="form-control" Width="100%">
                                                                </asp:DropDownList></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Locacion *</h3>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListLocacionesCorp" runat="server" CssClass="form-control" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Comentario</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxComentarioCorp" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="50px"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Telefono</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxTelefonoCorp" runat="server" CssClass="form-control" Width="70%"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <h3>Correo</h3>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCorreoCorp" runat="server" CssClass="form-control" Width="70%"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListSegmentos" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>



                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelMensaje" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                       </td>
                     
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click" class="btn btn-info" Text="Aceptar" ValidationGroup="Cliente" />
                        &nbsp;
                &nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Volver" />
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
