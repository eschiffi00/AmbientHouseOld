<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Cobranzas.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Datos de Cliente</h3>
                        <br />
                    </div>
                    <div class="panel-body">
                    </div>
                </div>
            </td>

        </tr>


        <tr>
            <td></td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Detalle Unidades Vendidas</h3>
                        <br />
                    </div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelCotizador" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:GridView ID="GridViewVentasConRenta" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewVentasConRenta_RowDataBound" OnRowCommand="GridViewVentasConRenta_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Unidades agregadas al presupuesto!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />


                                        <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                        <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />

                                        <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                        <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                        <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                        <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                        <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />
                                        <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina" DataFormatString="{0:C0}" SortExpression="UsoCocina" />
                                        <asp:BoundField DataField="ValorIntermediario" HeaderText="Intermediario" DataFormatString="{0:C0}" SortExpression="ValorIntermediario" />
                                        <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />
                                        <asp:BoundField DataField="NuevoValor" HeaderText="Precio Nuevo" DataFormatString="{0:C0}" SortExpression="NuevoValor" />
                                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C0}" SortExpression="Costo" />

                                        <asp:BoundField DataField="Descuentos" HeaderText="Descuento $" DataFormatString="{0:C0}" />
                                        <asp:BoundField DataField="Incremento" HeaderText="Incremento $" DataFormatString="{0:C0}" />



                                    </Columns>
                                </asp:GridView>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

        </tr>

    </table>

    <div class="panel panel-primary">

        <div class="panel-body">

            <table style="width: 100%;">
                <tr>
                    <td>
                        <h3>Total Presupuesto:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Total Fee:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTotalFee" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Total Organizador:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxOrganizador" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Impuestos Musicales</h3>
                    </td>
                    <td>
                        <h4>SADAIC:</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSADAIC" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <h4>ADICAPIF:</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxADICAPIF" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>

    <div class="panel panel-warning">
        <div class="panel-heading">
            <h3>PAGOS REALIZADOS</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Nuevo Pago" class="btn btn-info" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaPagos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewPagos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Pagos para el Evento.!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>

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
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td>Saldo Evento:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxSaldoEvento" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Saldo Cliente:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxCliente" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>

