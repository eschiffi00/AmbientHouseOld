<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Organizador.EventosRealizados.Index" %>
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
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-primary" OnClick="ButtonBuscar_Click" Text="Buscar" />&nbsp;|&nbsp;
                                            <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />
                                        </td>
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



                        <div class="panel-footer">
                            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    
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
                                                    <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ButtonBuscar" EventName="Click" />
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
