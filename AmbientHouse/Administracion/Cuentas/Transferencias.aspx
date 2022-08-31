<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Transferencias.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Transferencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 314px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelTransferencias" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


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
                                Transferencias entre Cajas<br />
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
                                            <h3>Cuenta Origen:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCuentaOrigen" runat="server" class="form-control" ReadOnly="true" Width="100%"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Importe:</h3>
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorImporte" runat="server"
                                                ControlToValidate="TextBoxImporte" Display="Dynamic"
                                                ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items"> </asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Concepto:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxConcepto" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TextBoxConcepto" Display="Dynamic"
                                                ErrorMessage="Concepto es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items"> </asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Tipo Movimiento:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListTipoMovimiento" CssClass="form-control" runat="server">
                                            </asp:DropDownList>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Cuenta Destino:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCuentaDestino" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownListCuentaDestino_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>
                                                <asp:Label ID="LabelValorCambio" runat="server" Text="Valor Cambio:"></asp:Label></h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxTipoCambio" runat="server" class="form-control" Width="100%"></asp:TextBox>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar Transferencia" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
