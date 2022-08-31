<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Costos.Tecnica.Editar" %>

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
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Actualizar Precios/Costos Experiencias de Tecnica<br />
                    </div>
                    <div class="panel-body">


                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td><h3>Proveedores:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                            <tr>
                                <td><h3>Anio:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAnio" runat="server" class="form-control">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                            </tr>
                                <tr>
                                    <td>
                                        <h3>Buscar Archivo</h3>
                                    </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
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
                                    <h3>Celda Inicio; Ej. A2</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxInicio" runat="server" class="form-control" Width="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="InicioRequired" runat="server" ControlToValidate="TextBoxInicio" Display="Dynamic" ErrorMessage="Celda de Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Celda Fin: Ej. J115</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFin" runat="server" class="form-control" Width="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FinRequired" runat="server" ControlToValidate="TextBoxFin" Display="Dynamic" ErrorMessage="Celda de Fin es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Leer Excel" ValidationGroup="Aceptar" OnClick="ButtonAceptar_Click" />&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonImportar" runat="server" class="btn btn-warning" Text="Importar Excel al Sistema" OnClick="ButtonImportar_Click" />&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                        </table>

                    </div>

                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelGrillaCostoTecnica" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewCostoTecnica" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>


                                         <asp:BoundField DataField="TipoServicioDescripcion" HeaderText="Experiencia" SortExpression="TipoServicioDescripcion" />
                                        <asp:BoundField DataField="SegmentoDescripcion" HeaderText="Segmento" SortExpression="SegmentoDescripcion" />
                                        <asp:BoundField DataField="ProveedorDescripcion" HeaderText="Proveedor" SortExpression="ProveedorDescripcion" />
                                        <asp:BoundField DataField="Anio" HeaderText="Anio" SortExpression="Anio" />
                                        <asp:BoundField DataField="Mes" HeaderText="Mes" SortExpression="Mes" />
                                        <asp:BoundField DataField="Dia" HeaderText="Dia" SortExpression="Dia" />
                                        <asp:BoundField DataField="Costo" HeaderText="Costo $" SortExpression="Costo" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio $" SortExpression="Precio" />
                                        <asp:BoundField DataField="ValorMas5PorCiento" HeaderText="Pl + 5 $" SortExpression="ValorMas5PorCiento" />
                                        <asp:BoundField DataField="ValorMenos5PorCiento" HeaderText="Pl - 5 $" SortExpression="ValorMenos5PorCiento" />
                                        <asp:BoundField DataField="ValorMenos10PorCiento" HeaderText="Pl - 10 $" SortExpression="ValorMenos10PorCiento" />

                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
