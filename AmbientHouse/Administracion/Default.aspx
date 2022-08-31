<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmbientHouse.Administracion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanelInicio" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <div class="panel panel-primary">
                            <div class="panel-heading">Buscador (Presupuestos/Eventos) </div>

                            <div class="panel-body">

                                <table style="width: 100%;">
                                    <tr>
                                        <td>NRO. Evento:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroEventoBuscador" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>NRO. Presupuesto:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroPresupuestoBuscador" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>FECHA EVENTO:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFechaEvento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEvento" TodaysDateFormat="" CssClass="black" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                                                        <tr>
                                        <td>Razon Social:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" Width="350px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     </tr>
                                                                        <tr>
                                        <td>Apellido y Nombre:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxApellidoNombre" runat="server" class="form-control" Width="350px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-primary" OnClick="ButtonBuscar_Click" Text="Buscar" />
                                            &nbsp;|&nbsp;&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />
                                            &nbsp;|&nbsp;
                                            <asp:Button ID="ButtonEventoGanado" runat="server" class="btn btn-success" OnClick="ButtonEventoGanado_Click" Text="Eventos Ganado" />
                                            &nbsp;|&nbsp;
                                            <asp:Button ID="ButtonEventosRealizados" runat="server" class="btn btn-danger" OnClick="ButtonEventosRealizados_Click" Text="Eventos Realizados" />
                                              &nbsp;|&nbsp;
                                            <asp:Button ID="ButtonEventosARevisar" runat="server" class="btn btn-info" Text="A Revisar" OnClick="ButtonEventosARevisar_Click" />
                                            &nbsp;|&nbsp;
                                            <asp:Button ID="ButtonLimpiar" runat="server" class="btn btn-default" OnClick="ButtonLimpiar_Click" Text="Limpiar Filtros de Busqueda" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                            </div>

                        </div>

                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanelBotones" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp; 
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>



                        <div class="panel-footer">
                            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewEventosGanados" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnRowDataBound="GridViewEventosGanados_RowDataBound" OnPageIndexChanging="GridViewEventosGanados_PageIndexChanging" OnRowCommand="GridViewEventosGanados_RowCommand">

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Evenntos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" ItemStyle-Width="10%" />
                                            <%-- <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="CUIT/CUIL" SortExpression="Cuit" />
                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                            <asp:BoundField DataField="Celular" HeaderText="Tel" SortExpression="Celular" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />--%>
                                            <asp:TemplateField ItemStyle-Width="50%">
                                                <ItemTemplate >
                                                    <asp:Panel ID="PanelDatosEvento" runat="server" GroupingText="Datos Evento">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>Cliente:
                                                                    <asp:TextBox ID="TextBoxCliente" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </td>
                                                                <td>Locacion:
                                                                     <asp:TextBox ID="TextBoxLocacion" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Ejecutivo:
                                                                    <asp:TextBox ID="TextBoxEjecutivo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>Fecha Evento:
                                                                     <asp:TextBox ID="TextBoxFechaEvento" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Cuit:
                                                                    <asp:TextBox ID="TextBoxCuit" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>Direccion:
                                                                     <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </td>
                                                                <td>Telefono:
                                                                    <asp:TextBox ID="TextBoxCelular" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                               <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Button ID="ButtonReservar" runat="server" class="btn btn-info" Text="Reservar" CommandName="Reservar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                    <asp:Button ID="ButtonConfirmar" runat="server" class="btn btn-primary" Text="Confirmar" CommandName="Confirmar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;|&nbsp;
                                                                    <asp:Button ID="ButtonVenderAdicionales" runat="server" class="btn btn-success" Text="Vender Adicionales" CommandName="VenderAdicionales" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;|&nbsp;
                                                                    <asp:Button ID="ButtonCargarSeguros" runat="server" class="btn btn-warning" Text="Contrato Proveedores" CommandName="CargarProveedoresExternos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;|&nbsp;
                                                                    <asp:Button ID="ButtonCargarComanda" runat="server" class="btn btn-danger" Text="Comanda" CommandName="Comanda" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;|&nbsp;
                                                                    <asp:Button ID="ButtonProvveedores" runat="server" class="btn btn-danger" Text="Proveedores" CommandName="Proveedores" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" ItemStyle-Width="10%" />


                                            <asp:TemplateField ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageDescuentos" runat="server" Text="Ver" ToolTip="Aplicar Ajustes (Descuentos/Incrementos) por Unidades de Negocio al Presupuesto." ImageUrl="~/Content/Imagenes/Ajuste.png" CommandName="Descuentos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                    <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ToolTip="Imprimir PDF del Presupuesto." ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                    <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ToolTip="Ver detalle del Presupuesto, modificar fecha y horas." ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />


                                                    <%--<asp:Button ID="ButtonCobranzas" runat="server" class="btn btn-default" Text="Cobranza" CommandName="Cobranza" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>

                                    <asp:GridView ID="GridViewRealizados" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewRealizados_PageIndexChanging" OnRowCommand="GridViewRealizados_RowCommand">

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#B40404" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                            <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="CUIT/CUIL" SortExpression="Cuit" />
                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                            <asp:BoundField DataField="Celular" HeaderText="Tel" SortExpression="Celular" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                    <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ToolTip="Ver detalle del Presupuesto, modificar fecha y horas." ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                    <asp:Button ID="ButtonVenderAdicionales" runat="server" class="btn btn-success" Text="Vender Adicionales" CommandName="VenderAdicionales" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>

                                      <asp:GridView ID="GridViewEventosRevisar" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" OnRowCommand="GridViewEventosRevisar_RowCommand" OnPageIndexChanging="GridViewEventosRevisar_PageIndexChanging">

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#33CEFF" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                            <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="CUIT/CUIL" SortExpression="Cuit" />
                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                            <asp:BoundField DataField="Celular" HeaderText="Tel" SortExpression="Celular" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                   
                                                    <asp:ImageButton ID="ButtonRevisar" runat="server" Text="Ver" ToolTip="Ver detalle del Presupuesto para Revisar" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ButtonEventoGanado" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ButtonEventosRealizados" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
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
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
