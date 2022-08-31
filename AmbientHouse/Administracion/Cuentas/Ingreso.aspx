<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Ingreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Ingresos
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="PanelPagoClientes" runat="server">
                            <asp:UpdatePanel ID="UpdatePanelIngresos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>


                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <h3>Cuenta</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCuenta" ReadOnly="true" Width="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <h3>Fecha Pago</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFechaPago" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaPago" CultureName="en-nz" />
                                                <asp:RequiredFieldValidator ID="FechaPagoRequired" runat="server" ControlToValidate="TextBoxFechaPago" Display="Dynamic" ErrorMessage="Fecha de Pago es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                               <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaPago" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaPago" TodaysDateFormat="" />--%>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Nro Presupuesto</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control" Width="100px"></asp:TextBox>

                                                <asp:Button ID="ButtonVerificar" runat="server" Text="Verificar" CssClass="btn btn-success" OnClick="ButtonVerificar_Click" />
                                                <asp:Label ID="LabelVerificado" runat="server" Text="Label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNroPresupuesto" Display="Dynamic" ErrorMessage="Nro de Presupuesto es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Nro Recibo</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroRecibo" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Tipo Pago</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTipoPago" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoPago_SelectedIndexChanged">
                                                    <asp:ListItem Value="null">&lt;Seleccionar&gt;</asp:ListItem>
                                                    <asp:ListItem>Reserva</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Tipo Movimiento</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTipoMoviemiento" CssClass="form-control" runat="server"></asp:DropDownList>

                                            </td>
                                        </tr>

                                       

                                        <tr>
                                            <td>
                                                <h3>Importe</h3>
                                            </td>
                                            <td class="auto-style1">
                                                  <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="ImporteRequired" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Concepto</h3>
                                            </td>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="TextBoxConcepto" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConceptoRequired" runat="server" ControlToValidate="TextBoxConcepto" Display="Dynamic" ErrorMessage="Concepto es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>


                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
