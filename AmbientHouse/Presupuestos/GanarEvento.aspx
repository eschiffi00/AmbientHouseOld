<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="GanarEvento.aspx.cs" Inherits="AmbientHouse.Presupuestos.GanarEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="panel panel-success">

        <div class="panel-heading">
            <h3>EVENTO GANADO
            </h3>
            <br />
        </div>
        <div class="panel-body">

            <table id="GrillaEventos" style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>

                </tr>
                <tr>
                    <td>
                        <h3>Nro Evento:</h3>
                    </td>
                    <td>
                        <asp:Label ID="LabelNroEvent" runat="server" Font-Bold="True" Width="100%"></asp:Label></td>

                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>

                </tr>
                <tr>
                    <td colspan="2">
                        <div class="panel-heading">
                            <h3>EVENTO GANADO
                            </h3>

                            <asp:GridView ID="GridViewPresupuestosaAprobar" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />

                                <Columns>

                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Contacto" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="TipoEvento" HeaderText="Tipo Evento" SortExpression="TipoEvento" />
                                    <asp:BoundField DataField="CARACTERISTICA" HeaderText="Caracteristicas" SortExpression="CARACTERISTICA" />
                                    <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                    <asp:BoundField DataField="SECTOR" HeaderText="Sector" SortExpression="SECTOR" />
                                    <asp:BoundField DataField="JORNADA" HeaderText="Jornada" SortExpression="JORNADA" />
                                    <asp:BoundField DataField="Momento" HeaderText="Momento" SortExpression="Momento" />
                                    <asp:BoundField DataField="Duracion" HeaderText="Duracion" SortExpression="Duracion" />
                                    <asp:BoundField DataField="CantidadInicialInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInicialInvitados" />
                                    <asp:BoundField DataField="CantidadInvitadosAdolecentes" HeaderText="Cant. Adolescentes" SortExpression="CantidadInvitadosAdolecentes" />
                                    <asp:BoundField DataField="CantidadInvitadosMenores3y8" HeaderText="Cant. entre 3 y 8" SortExpression="CantidadInvitadosMenores3y8" />
                                    <asp:BoundField DataField="CantidadInvitadosMenores3" HeaderText="Cant. menores de 3" SortExpression="CantidadInvitadosMenores3" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:d}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Presupuesto" SortExpression="PresupuestoId" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>

                </tr>
                <tr>
                    <td colspan="2">
                        <div class="panel-heading">
                            <h3>Items Vendidos
                            </h3>
                            <asp:GridView ID="GridViewVentas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Eventos Confirmados/Reservados con la fecha seleccionada!  
                                </EmptyDataTemplate>

                                <Columns>

                                    <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                    <asp:BoundField DataField="ProductoId" HeaderText="Item" SortExpression="ProductoId" />
                                    <asp:BoundField DataField="ServicioId" HeaderText="Servicio" SortExpression="ServicioId" />
                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                    <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" DataFormatString="{0:C0}" SortExpression="PrecioSeleccionado" />
                                    <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />
                                    <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                    <asp:BoundField DataField="Logistica" HeaderText="Logistica" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                    <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina" DataFormatString="{0:C0}" SortExpression="UsoCocina" />
                                    <asp:BoundField DataField="ValorIntermediario" HeaderText="Fee" DataFormatString="{0:C0}" SortExpression="ValorIntermediario" />
                                    <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />


                                </Columns>

                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Total Presupuesto:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>PAX:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>

                    </td>
                </tr>
            </table>

        </div>
        <div class="panel-body">
            <table id="ClienteBuscar" style="width: 100%;">
                <tr>
                    <td>CUIL/CUIT:
                                 
                    </td>
                    <td>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBoxBuscadorCuitCuil" runat="server" class="form-control" MaxLength="11"></asp:TextBox>
                        </div>
                        &nbsp;&nbsp;
                                    <div style="float: left;">
                                        <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info" OnClick="ButtonBuscar_Click" />
                                        <asp:Label ID="LabelErrorCuit" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF0066"></asp:Label>
                                    </div>
                    </td>

                </tr>

            </table>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
