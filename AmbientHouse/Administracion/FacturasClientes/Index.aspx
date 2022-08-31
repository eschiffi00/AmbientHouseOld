<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.FacturasClientes.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Facturas</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>Nro. Factura</td>
                    <td>
                        <asp:TextBox ID="TextBoxNroFactura" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Razon Social</td>
                    <td>
                        <asp:TextBox ID="TextBoxRazonSocial" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>CUIT/CUIL</td>
                    <td>
                        <asp:TextBox ID="TextBoxCuit" class="form-control" runat="server" MaxLength="13" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Nro. Presupuesto</td>
                    <td>
                        <asp:TextBox ID="TextBoxNroPresupuesto" class="form-control" runat="server"  Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Desde:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaDesde" class="form-control" runat="server" Width="200px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimientoDesde" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesde" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Hasta:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaHasta" class="form-control" runat="server" Width="200px"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimientoHasta" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaHasta" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Empresa:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListEmpresa" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True">
                            <asp:ListItem Value="0">&lt;Seleccione una Empresa&gt;</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Estado:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListEstados" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True">
                            <asp:ListItem Value="0">&lt;Seleccione un Estados&gt;</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />&nbsp;|&nbsp;
                        <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar Filtros" OnClick="ButtonLimpiar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelGrillaCheques" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Facturas" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>

                                <asp:GridView ID="GridViewFacturas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="100" AllowPaging="True" OnPageIndexChanging="GridViewFacturas_PageIndexChanging" OnRowCommand="GridViewFacturas_RowCommand" OnRowDataBound="GridViewFacturas_RowDataBound">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Facturas con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" HeaderStyle-Width="10px" /> 
            
                                          <asp:TemplateField ControlStyle-Width="250px" HeaderText="Empresa">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEmpresas" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="250px" />
                                           
                                        </asp:TemplateField>

                                        <asp:TemplateField   ControlStyle-Width="200px" HeaderText="Comprobante">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListTipoComprobantes" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="200" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura" SortExpression="NroFactura" />
                                           <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" />
                                        <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" />
                                        <asp:BoundField DataField="ClienteDescripcion" HeaderText="Razon Social" SortExpression="ClienteDescripcion" />
                                        <asp:BoundField DataField="Cuit" HeaderText="Cuit" />
                                        <asp:BoundField DataField="FechaStr" HeaderText="Fecha" SortExpression="FechaStr" />
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                <asp:Button ID="ButtonVer" runat="server" Text="Ver" class="btn btn-info" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>


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
        </div>
    </div>
</asp:Content>
