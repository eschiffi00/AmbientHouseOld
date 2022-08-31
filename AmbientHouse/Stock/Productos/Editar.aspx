<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Stock.Productos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-sm">
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
                                    Agregar/Editar Productos<br />
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
                                                <h3>Rubro:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListRubros" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListRubros_SelectedIndexChanged">
                                                </asp:DropDownList>
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
                                                <h3>Codigo:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCodigo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Codigo de Barra:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCodigoBarra" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
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
                                                <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Unidad:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListUnidad" runat="server" CssClass="form-control" Width="100%">
                                                </asp:DropDownList>
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
                                                <h3>Unidad Presentacion:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListPresentacion" runat="server" CssClass="form-control" Width="100%">
                                                </asp:DropDownList>
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
                                                <h3>Establer Cantidad Minima:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCantidadNominal" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Cantidad Existente:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCantidadExistente" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Costo:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" class="form-control"></asp:TextBox></td>
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
                            <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-secondary" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>

        </div>
    </div>



    <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../Boostrap4/js/popper.min.js"></script>
    <script src="../../Boostrap4/js/bootstrap.min.js"></script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>

