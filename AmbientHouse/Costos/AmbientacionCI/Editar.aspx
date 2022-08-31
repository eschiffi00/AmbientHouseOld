<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Costos.AmbientacionCI.Editar" %>

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
                        Agregar/Editar Costos/Precios Experiencias de Ambientacion<br />
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
                                    <h3>Paquetes:</h3>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="DropDownListPaquetes" runat="server" class="form-control" >
                                       
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Proveedor:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control">
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Semestre:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSemestre" runat="server" class="form-control" >
                                        <asp:ListItem Value="1">Primer Semestre</asp:ListItem>
                                        <asp:ListItem Value="2">Segundo Semestre</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Anio:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxAnio" runat="server"  class="form-control" Width="150px" ></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="yyyy" TargetControlID="TextBoxAnio" TodaysDateFormat="yyyy" CssClass="black" DaysModeTitleFormat="yyyy" />
                                   <asp:RequiredFieldValidator ID="AnioRequired" runat="server" ControlToValidate="TextBoxAnio" Display="Dynamic" ErrorMessage="Anio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td>
                                    <h3>Rango de Personas:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxRangoPersonas" runat="server"  class="form-control" Width="150px" ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RangoRequired" runat="server" ControlToValidate="TextBoxRangoPersonas" Display="Dynamic" ErrorMessage="Rango Personas es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td>
                                    <h3>Costo Flete:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCostoFlete" runat="server"  class="form-control" Width="150px" ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="CostoFleteRequired" runat="server" ControlToValidate="TextBoxCostoFlete" Display="Dynamic" ErrorMessage="Costo Flete es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td>
                                    <h3>Costo:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCosto" runat="server"  class="form-control" Width="150px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CostoRequired" runat="server" ControlToValidate="TextBoxCosto" Display="Dynamic" ErrorMessage="Costo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td>
                                    <h3>Precio:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPrecio" runat="server"  class="form-control" Width="150px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PrecioRequired" runat="server" ControlToValidate="TextBoxPrecio" Display="Dynamic" ErrorMessage="Precio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
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
