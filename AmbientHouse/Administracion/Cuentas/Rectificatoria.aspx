<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Rectificatoria.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Rectificatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelRectificatoria" runat="server" UpdateMode="Conditional">
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
                                Rectificar Caja<br />
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
                                            <h3>Cuenta:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCuenta" runat="server" class="form-control" ReadOnly="true" Width="100%"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Saldo:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSaldo" runat="server" class="form-control" ReadOnly="true" Width="100%"></asp:TextBox>
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
                                            <h3>Movimiento:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListMovimiento" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownListMovimiento_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem>DEBITO</asp:ListItem>
                                                <asp:ListItem>CREDITO</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                   
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                   
                                    <tr>
                                        <td class="auto-style1" colspan="3">
                                            <asp:Panel ID="PanelPresupuestos" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="width:50%">
                                                            <h3>Nro Presupuesto:</h3>
                                                        </td>
                                                        <td> <asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control" Width="30%"></asp:TextBox></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                         <td style="width:50%">
                                                            <h3>Centro de Costo:</h3></td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListCentrodeCosto"  CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>
                                                 
                                                </table>
                                            </asp:Panel>
                                        </td>
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
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
