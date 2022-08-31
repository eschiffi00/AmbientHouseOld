<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.ItemDetalle.Editar" %>

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
                <asp:UpdatePanel ID="UpdatePanelEditar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Agregar/Editar Items<br />
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Descripcion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="400px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Tipo Catering:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipoCatering" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoCatering_SelectedIndexChanged"></asp:DropDownList>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Items Experiencia:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlItems" runat="server" class="form-control"></asp:DropDownList>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-outline-primary" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
