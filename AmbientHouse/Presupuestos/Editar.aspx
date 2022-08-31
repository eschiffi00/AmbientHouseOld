<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Presupuestos.Editar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel-heading">
        <h3>EVENTO
        </h3>
        <br />
    </div>
    <div class="panel-body">
        <table style="width: 100%;">

            <tr>
                <td>NRO EVENTO:
                </td>
                <td>
                    <h4>
                        <asp:Label ID="LabelNroEvent" runat="server" Font-Bold="True" Width="400px"></asp:Label></h4>
                </td>

            </tr>


            <tr>
                <td colspan="2">
                    <h3>Datos Evento</h3>
                    <div class="panel-footer">
                        <asp:GridView ID="GridViewPresupuestos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            </Columns>
                        </asp:GridView>
                        <h3>Listado de Unidades Cotizadas</h3>
                        <asp:GridView ID="GridViewVentas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Eventos Confirmados/Reservados con la fecha seleccionada!  
                            </EmptyDataTemplate>

                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" Checked="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />

                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />

                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />
                                <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />

                            </Columns>



                        </asp:GridView>
                    </div>
                </td>

            </tr>

            <tr>
                <td>Total Presupuesto:&nbsp;
                    <asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                </td>
                <td>PAX<asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                </td>

            </tr>



        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
