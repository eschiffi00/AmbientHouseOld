<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Cheques.Editar1" %>

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
                        Agregar/Editar Cheques<br />
                    </div>
                    <div class="panel-body">

                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <h4>Nro. Cheque:</h4>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroCheque" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorNroCheque" runat="server" ControlToValidate="TextBoxNroCheque" Display="Dynamic" 
                                         ErrorMessage="Nro Cheque es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Proveedor:</h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListProveedor" runat="server" class="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="null">&lt;Seleccionar un Proveedor&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Cliente:</h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCliente" runat="server" class="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="null">&lt;Seleccionar un Cliente&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Fecha Emision:</h4>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaEmision" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                     <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaEmision" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaEmision" CultureName="en-nz" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaEmision" runat="server" ControlToValidate="TextBoxFechaEmision" Display="Dynamic" 
                                         ErrorMessage="Fecha Emision es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Fecha Vencimiento:</h4>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                     <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaVencimiento" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaVencimiento" CultureName="en-nz" />
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaVencimineto" runat="server" ControlToValidate="TextBoxFechaVencimiento" Display="Dynamic" 
                                         ErrorMessage="Fecha Vencimiento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Importe:</h4>
                                </td>
                                <td>
                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                    <div class="float-left">
                                        <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidatorImporte" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" 
                                         ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Banco:</h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListBancos" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                                <tr>
                                <td>
                                    <h4>Cuenta:</h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCuentas" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h4>Observaciones:</h4>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxObservaciones" runat="server" class="form-control" Height="150px" MaxLength="2000" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    &nbsp;</td>
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
</asp:Content>
