<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReservarPresupuesto.aspx.cs" Inherits="AmbientHouse.Presupuestos.ReservarPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Panel ID="PanelEventoGanado" runat="server">

                    <div class="panel panel-success">

                        <div class="panel-heading">
                            <h3>EVENTO GANADO
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
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <h3>Datos Evento</h3>
                                        <asp:GridView ID="GridViewPresupuestosaAprobar" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#ffffcc" />
                                            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />

                                            <Columns>
                                                <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
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

                                                <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                                                <asp:BoundField DataField="ProductoId" HeaderText="Nro Item" SortExpression="ProductoId" />
                                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                                <asp:BoundField DataField="CantidadAdicional" HeaderText="Cant. Adicional" SortExpression="CantidadAdicional" />
                                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                                <asp:BoundField DataField="Comision" DataFormatString="{0:C0}" HeaderText="Comision" SortExpression="Comision" />
                                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                                <asp:BoundField DataField="Logistica" DataFormatString="{0:C0}" HeaderText="Logistica Costo" SortExpression="Logistica" />
                                                <asp:BoundField DataField="Cannon" DataFormatString="{0:C0}" HeaderText="Canon" SortExpression="Cannon" />
                                                <asp:BoundField DataField="UsoCocina" DataFormatString="{0:C0}" HeaderText="Uso Cocina" SortExpression="UsoCocina" />
                                                <asp:BoundField DataField="ValorIntermediario" DataFormatString="{0:C0}" HeaderText="Fee" SortExpression="ValorIntermediario" />
                                                <asp:BoundField DataField="Descuentos" DataFormatString="{0:C0}" HeaderText="Descuento" SortExpression="Descuentos" />
                                                <asp:BoundField DataField="Incremento" DataFormatString="{0:C0}" HeaderText="Incremento" SortExpression="Incremento" />
                                                <asp:BoundField DataField="CostoMesas" DataFormatString="{0:C0}" HeaderText="Costo Mesas" SortExpression="CostoMesas" />
                                                <asp:BoundField DataField="CostoSillas" DataFormatString="{0:C0}" HeaderText="Costo Sillas" SortExpression="CostoSillas" />
                                                <asp:BoundField DataField="PrecioMesas" DataFormatString="{0:C0}" HeaderText="Prec. Mesas" SortExpression="PrecioMesas" />
                                                <asp:BoundField DataField="PrecioSillas" DataFormatString="{0:C0}" HeaderText="Prec. Sillas" SortExpression="PrecioSillas" />
                                                <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                                                <asp:BoundField DataField="Costo" DataFormatString="{0:C0}" HeaderText="Costo" SortExpression="Costo" />
                                                <asp:BoundField DataField="NuevoValor" DataFormatString="{0:C0}" HeaderText="Precio" SortExpression="NuevoValor" />

                                            </Columns>
                                        </asp:GridView>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Total Presupuesto:</td>
                                    <td>&nbsp;<asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>Total Organizador:</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TextBoxTotalOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>PAX:</td>
                                    <td>&nbsp;<asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Renta:</td>
                                    <td>&nbsp;<asp:TextBox ID="TextBoxTotalRenta" runat="server" class="form-control" ReadOnly="True" Width="100%"></asp:TextBox>
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


                            </table>
                        </div>

                        <asp:Panel ID="PanelCliente" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    Formulario Alta de Cliente
                                           
                                </div>

                                <div class="panel-body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LabelRazonSocial" runat="server" Text="Razon Social"></asp:Label>
                                                            <asp:Label ID="LabelApellidoyNombre" runat="server" Text="Apellido y Nombre"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxApellidoyNombre" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                            <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Domicilio</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxDomicilio" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                        </td>
                                                        <td colspan="2">:</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Condicion de IVA:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListCondicionIva" runat="server" class="form-control" Width="300px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>CUIT/CUIL:</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxCuilCuit" runat="server" class="form-control"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Tipo Cliente:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListTipoCliente" runat="server" class="form-control">
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
                                                                <h3>Contacto de contratación:</h3>
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
                                                                <h3>Contacto de administración:</h3>
                                                            </td>
                                                            <td>Correo</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCorreoAdministracion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                            </td>
                                                            <td>Telefono</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxTelAdministracion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <h3>Contacto de tesorería / pagos:</h3>
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
                                                    </table>
                                                </div>
                                                <div>
                                                </div>

                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="PanelRequerimientoAprobacion" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-heading"></div>
                                <div class="panel-body">
                                    <table style="width: 100%;">

                                         <tr>
                                            <td>
                                                <h3>Tipo de Pago:</h3>
                                            </td>
                                            <td>
                                                  <asp:DropDownList ID="DropDownListTipoPago" runat="server" class="form-control" Width="300px" >
                                                      <asp:ListItem>Seña</asp:ListItem>
                                                      <asp:ListItem>Reserva</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Monto Seña/Reserva:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxMontoSenia" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Fecha Seña/Reserva:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFechaSenia" runat="server" class="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaSenia" TodaysDateFormat="" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Forma de Pago:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListFormadePago" runat="server" class="form-control" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Cuenta Destino Importe</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListCuenta" runat="server" class="form-control" Width="300px">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Empresa</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListEmpresas" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%">
                                                    <asp:ListItem Value="3">&lt;Seleccionar una Empresa&gt;</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Print Mail de Aprobacion:</h3>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="TextBoxArchivo" runat="server" class="form-control"></asp:TextBox>--%>
                                                <asp:Button ID="ButtonVerArchivoConfirmacion" runat="server" Text="Ver Archivo Confirmacion" class="btn btn-primary" OnClick="ButtonVerArchivoConfirmacion_Click" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Nro de Recibo:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroRecibo" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Nro de Factura:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroFactura" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td><%--<iframe height="780px" src="ComprobanteMail.ashx" width="100%"></iframe>--%></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">

                                                <asp:UpdatePanel ID="UpdatePanelFormasdePago" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="PanelCheques" runat="server">
                                                            <div class="panel-body">
                                                                <div class="panel-heading">
                                                                    Cheques
                                                                </div>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Nro. Cheque:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxNroCheque" runat="server" class="form-control"></asp:TextBox>

                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Fecha Emision:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxFechaEmision" runat="server" class="form-control"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="TextBoxFechaEmision_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmision" TodaysDateFormat="" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Fecha Vencimiento:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="TextBoxFechaVencimiento_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimiento" TodaysDateFormat="" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <h4>Banco:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownListBancos" runat="server" class="form-control">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Observaciones:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxObservaciones" runat="server" class="form-control" Height="150px" MaxLength="2000" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>

                                                                </table>
                                                        </asp:Panel>

                                                        <asp:Panel ID="PanelTransferencia" runat="server">
                                                            <div class="panel-body">
                                                                <div class="panel-heading">
                                                                    Transferencias
                                                                </div>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Nro. Comprobante:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxNroComprobanteTrans" runat="server" class="form-control"></asp:TextBox></td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Fecha Comprobante</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxFechaComprobanteTrans" runat="server" class="form-control"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="TextBoxFechaComprobanteTrans_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaComprobanteTrans" TodaysDateFormat="" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Cargar Comprobante de Pago Transferencia:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="ButtonVerArchivoTransferencia" runat="server" Text="Ver Archivo Transferencia" class="btn btn-primary" OnClick="ButtonVerArchivoTransferencia_Click" /></td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="DropDownListFormadePago" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>


                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>

                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="panel panel-footer">
                        Comentario:<asp:TextBox ID="TextBoxComentario" runat="server" class="form-control" Height="70px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </div>
                    <div>

                        <asp:Label ID="LabelMensajeError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF0066"></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-success" OnClick="ButtonAceptar_Click" Text="Aceptar" />
                        &nbsp;|&nbsp;
                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />
                    </div>

                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
