<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Transferencias.Editar" %>
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
                        Agregar/Editar Transferencias
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                             <tr>
                                <td>
                                    <h3>Razon Social:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" Width="50%" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxRazonSocial" Display="Dynamic" ErrorMessage="Razon Social es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                           <tr>
                                <td>
                                    <h3>Banco:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListBanco" CssClass="form-control" runat="server"></asp:DropDownList>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td>
                                    <h3>Nro Transferencia:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroTransferencia" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CodigoRequired" runat="server" ControlToValidate="TextBoxNroTransferencia" Display="Dynamic" ErrorMessage="Nro. Transferencia es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Importe:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Fecha Transferencia:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxFecha" Display="Dynamic" ErrorMessage="Fecha Transferencia es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
