<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Clientes.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanelClientes" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelCliente" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Formulario Alta de Cliente
                                           
                    </div>

                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="3">
                                                <asp:RadioButton ID="RadioButtonPersonaFisica" runat="server" AutoPostBack="True" Checked="True" GroupName="Persona" OnCheckedChanged="RadioButtonPersonaFisica_CheckedChanged" Text="Persona Fisica" />
                                                <asp:RadioButton ID="RadioButtonPersonaJuridica" runat="server" AutoPostBack="True" GroupName="Persona" OnCheckedChanged="RadioButtonPersonaJuridica_CheckedChanged" Text="Persona Juridica" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabelRazonSocial" runat="server" Text="Razon Social"></asp:Label>
                                                <asp:Label ID="LabelApellidoyNombre" runat="server" Text="Apellido y Nombre"></asp:Label>
                                                <asp:TextBox ID="TextBoxApellidoyNombre" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                            </td>
                                            <td>Domicilio<asp:TextBox ID="TextBoxDomicilio" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">:</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>CUIT/CUIL:<asp:TextBox ID="TextBoxCuilCuit" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>Condicion de IVA:<asp:DropDownList ID="DropDownListCondicionIva" runat="server" class="form-control">
                                            </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>

                                            <td>&nbsp;</td>
                                            <td>Tipo Cliente:<asp:DropDownList ID="DropDownListTipoCliente" runat="server" class="form-control">
                                                <asp:ListItem Value="S">Social</asp:ListItem>
                                                <asp:ListItem Value="C">Corporativo</asp:ListItem>
                                                <asp:ListItem Value="O">Organizador</asp:ListItem>
                                                <asp:ListItem Value="I">Intermediario</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>:</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <div class="panel-heading">Contactos Cliente</div>
                                    <div class="panel-body">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    Contacto de contratación:
                                                </td>
                                                <td>Correo:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCorreoContratacion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                </td>
                                                <td>Telefono:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTelContratacion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Contacto de administración:
                                                </td>
                                                <td>Correo</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCorreoAdministracion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreoAdministracion" runat="server" ControlToValidate="TextBoxCorreoAdministracion" Display="Dynamic" ErrorMessage="Correo Administracion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>Telefono</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTelAdministracion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelAdministracion" runat="server" ControlToValidate="TextBoxTelAdministracion" Display="Dynamic" ErrorMessage="Telefono Administracion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Contacto de tesorería / pagos:
                                                </td>
                                                <td>Correo:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCorreoTesoreria" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                </td>
                                                <td>Telefono</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTelTesoreria" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Contacto de Organizacion:
                                                </td>
                                                <td>Correo:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCorreoOrganizacion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreoOrganizacion" runat="server" ControlToValidate="TextBoxCorreoOrganizacion" Display="Dynamic" ErrorMessage="Correo Organizacion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>Telefono</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTelOrganizacion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelOrganizacion" runat="server" ControlToValidate="TextBoxTelOrganizacion" Display="Dynamic" ErrorMessage="Telefono Organizacion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" />
                                    </div>

                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
