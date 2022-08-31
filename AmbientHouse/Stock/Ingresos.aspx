<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Ingresos.aspx.cs" Inherits="AmbientHouse.Stock.Ingresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanelIngresoEgreso" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>


                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Ingreso/Egreso Productos<br />
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
                                            <h3>Ingrese Codigo de Barras:</h3>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="TextBoxCodigoBarra" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="TextBoxCodigoBarra_TextChanged" ></asp:TextBox>
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
                                            <h3>Producto:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListProductos" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProductos_SelectedIndexChanged">
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
                                            <h3>Unidad Presentacion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxUnidadPresentacion" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
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
                                            <h3>Existencia Actual:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxExistenciaActual" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
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
                                            <h3>Cantidad:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCantidadExistente" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCantidad" runat="server" ControlToValidate="TextBoxCantidadExistente" Display="Dynamic" ErrorMessage="Debe Ingresar un Valor." Font-Bold="True" ForeColor="#FF3300" ValidationGroup="Existencia"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td><h3>Tipo Movimiento:</h3></td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListTipoIngreso" runat="server" AutoPostBack="True" CssClass="form-control" Width="100%">
                                                <asp:ListItem>ENTRADA</asp:ListItem>
                                                <asp:ListItem>SALIDA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Existencia" OnClick="ButtonAceptar_Click" class="btn btn-danger" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
