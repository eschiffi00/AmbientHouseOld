<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="GestionPorEvento.aspx.cs" Inherits="AmbientHouse.Presupuestos.GestionPorEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 475px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">


    <table style="width: 100%">
        <tr>
            <td>
                <asp:Panel ID="PanelGrillaEventos" runat="server">

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3>EVENTO NRO.
                            <asp:Label ID="LabelNroEvento" runat="server" Text=""></asp:Label></h3>
                            <br />
                        </div>
                        <div class="panel-body">
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Presupuesto" OnClick="ButtonNuevo_Click" />
                                        &nbsp;|&nbsp;    
                                        <asp:Button ID="ButtonEventoGanado" runat="server" class="btn btn-success" Text="Evento Ganado" OnClick="ButtonEventoGanado_Click" />
                                        &nbsp;|&nbsp;    
                                        <asp:Button ID="ButtonEventoPerdido" runat="server" class="btn btn-danger" Text="Evento Perdido" OnClick="ButtonEventoPerdido_Click" />
                                        &nbsp;|&nbsp;
                                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Label ID="LabelError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
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
                                        <div class="panel-footer">

                                            <asp:GridView ID="GridViewPresupuestos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnRowCommand="GridViewPresupuestos_RowCommand" OnRowDataBound="GridViewPresupuestos_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Costos con los parametros seleccionados!  
                                                </EmptyDataTemplate>

                                                <Columns>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>

                                                            <asp:CheckBox ID="CheckBoxSeleccionarEvento" runat="server" />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                                    <asp:BoundField DataField="CARACTERISTICA" HeaderText="Caracteristica" SortExpression="CARACTERISTICA" />
                                                    <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                                    <asp:BoundField DataField="TipoEvento" HeaderText="Tipo Evento" SortExpression="TipoEvento" />
                                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                                    <asp:BoundField DataField="CantidadInicialInvitados" HeaderText="Cant. Invitados" />
                                                    <asp:BoundField DataField="EstadoPresupuesto" HeaderText="Estados" />

                                                    <asp:TemplateField>
                                                        <ItemTemplate>

                                                            <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                            <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                            <asp:ImageButton ID="ImageDescuentos" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/Ajuste.png" CommandName="Descuentos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                            <asp:ImageButton ID="ImageRepresupuestar" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/refresh.png" CommandName="Represupuestar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/Nuevo.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Continuar Evento">
                                                        <ControlStyle CssClass="btn btn-info" />
                                                    </asp:HyperLinkField>

                                                </Columns>

                                            </asp:GridView>

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

                        </div>
                    </div>

                </asp:Panel>

            </td>
        </tr>

    </table>

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

                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="panel-footer">
                                            <h3>Datos Evento</h3>

                                            <asp:GridView ID="GridViewPresupuestosaAprobar" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
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
                                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Presupuesto" SortExpression="PresupuestoId" />

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
                                                    <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                                    <asp:BoundField DataField="ProductoId" HeaderText="Item" SortExpression="ProductoId" />
                                                    <asp:BoundField DataField="ServicioId" HeaderText="Servicio" SortExpression="ServicioId" />
                                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                    <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" DataFormatString="{0:C0}" SortExpression="PrecioSeleccionado" />
                                                     <asp:BoundField DataField="PrecioSillas" HeaderText="Precio Sillas" DataFormatString="{0:C0}" SortExpression="PrecioSillas" />
                                                     <asp:BoundField DataField="PrecioMesas" HeaderText="Precio Mesas" DataFormatString="{0:C0}" SortExpression="PrecioMesas" />
                                                    <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />

                                                    <%--<asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />--%>

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
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>

                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>

                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Total Presupuesto:
                                        <asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>PAX:<asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>

                                </tr>


                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>

                                </tr>
                                <tr>
                                    <td>CUIL/CUIT (sin guiones):
                                 
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
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>

                                                <asp:UpdatePanel ID="UpdatePanelClientes" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="RadioButtonPF" runat="server" AutoPostBack="True" Text="Persona Fisica" GroupName="Persona" OnCheckedChanged="RadioButtonPF_CheckedChanged" />
                                                                    <asp:RadioButton ID="RadioButtonPJ" runat="server" AutoPostBack="True" Text="Persona Juridica" GroupName="Persona" OnCheckedChanged="RadioButtonPJ_CheckedChanged" />
                                                                </td>
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
                                                                <td>CUIT/CUIL:<asp:TextBox ID="TextBoxCuilCuit" runat="server" class="form-control" MaxLength="11"></asp:TextBox>
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
                                                                <tr>
                                                                    <td>
                                                                        <h3>Contacto de Organizacion:</h3>
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
                                                        </div>
                                                    </ContentTemplate>

                                                </asp:UpdatePanel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>

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
                                            <td class="auto-style1">
                                                <h3>Monto Seña:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxMontoSenia" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <h3>Fecha Seña:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFechaSenia" runat="server" class="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaSenia" TodaysDateFormat="" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <h3>Forma de Pago:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListFormadePago" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <h3>&nbsp;</h3>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <h3>Print Mail de Aprobacion:</h3>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FileUploadComprobanteMailAprobacion" runat="server" onchange="showimagepreview(this)" />
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">&nbsp;</td>
                                            <td>&nbsp;</td>
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
                                                                            <h4>Banco Receptor</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownListBancoTransferencia" runat="server" class="form-control" Width="100%">
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <h4>Cargar Comprobante de Pago Transferencia:</h4>
                                                                        </td>
                                                                        <td>
                                                                            <asp:FileUpload ID="FileUploadComprobanteTransferencia" runat="server" />
                                                                            &nbsp;</td>
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
                        <asp:Button ID="ButtonAceptarGanado" runat="server" class="btn btn-success" OnClick="ButtonAceptarGanado_Click" Text="Aceptar" ValidationGroup="Items" />
                        &nbsp;|&nbsp;
                        <asp:Button ID="ButtonVolverGanado" runat="server" class="btn btn-default" OnClick="ButtonVolverGanado_Click" Text="Volver" />

                    </div>

                </asp:Panel>
            </td>
        </tr>
    </table>

    <table style="width: 100%">
        <tr>
            <td>
                <asp:Panel ID="PanelEventoPerdido" runat="server">

                    <div class="panel panel-danger">

                        <div class="panel-heading">
                            <h3>EVENTO PERDIDO
                            </h3>
                            <br />
                        </div>
                        <div class="panel-body">
                            <table style="width: 100%;">

                                <tr>

                                    <th>CLIENTE:<asp:TextBox ID="TextBoxClientePerdido" runat="server" class="form-control" ReadOnly="True" Width="400px"></asp:TextBox>
                                    </th>

                                </tr>

                                <tr>

                                    <th>NRO EVENTO
                                        <asp:TextBox ID="TextBoxNroEventoPerdido" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                    </th>

                                </tr>

                                <tr>

                                    <td>Comentario<asp:TextBox ID="TextBoxComentarioPerdidos" runat="server" class="form-control" Height="70px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxComentarioPerdidos" Display="Dynamic" ErrorMessage="Comentario es Obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                    </td>

                                </tr>
                                <tr>


                                    <td></td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Button ID="ButtonAceptarPerido" runat="server" class="btn btn-danger" OnClick="ButtonAceptarPerido_Click" Text="Perder Evento" ValidationGroup="Items" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonVolverPerdido" runat="server" class="btn btn-default" OnClick="ButtonVolverPerdido_Click" Text="Volver" />
                                    </td>

                                </tr>
                            </table>

                        </div>
                    </div>

                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
