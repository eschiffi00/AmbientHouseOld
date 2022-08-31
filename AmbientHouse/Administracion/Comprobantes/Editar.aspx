<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Comprobantes.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 1472px;
        }

        .auto-style2 {
            width: 35%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
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
                        Agregar/Editar Comprobantes
                    </div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelComprobante" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="PanelEncabezadoComprobante" runat="server" GroupingText="Encabezado Comprobante">

                                    <table style="width: 100%;">

                                        <tr>
                                            <td>
                                                <h3>Fecha Comprobante:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFecha" CultureName="en-nz" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFecha" runat="server" ControlToValidate="TextBoxFecha" Display="Dynamic" ErrorMessage="Fecha es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                <asp:Label ID="LabelErrorFechaComprobante" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Proveedor:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListProveedores" runat="server" AppendDataBoundItems="True" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProveedores_SelectedIndexChanged">
                                                    <asp:ListItem Value="null">&lt;Seleccionar un Proveedor&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>


                                        <tr>
                                            <td>
                                                <h3>Tipo Comprobante:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTipoComprobantes" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListTipoComprobantes_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                          <tr>
                                            <td>
                                                <h3>Punto de Venta:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxPuntoVenta" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPtoVenta" runat="server" ControlToValidate="TextBoxPuntoVenta" Display="Dynamic" ErrorMessage="Punto de Venta es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Nro Comprobante:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroComprobante" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxNroComprobante" Display="Dynamic" ErrorMessage="Nro. Comprobante es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                <asp:Label ID="LabelErrorNroComprobante" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                       

                                        <tr>
                                            <td>
                                                <h3>Tipo de Pago:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTipoPago" runat="server" AppendDataBoundItems="True" class="form-control" >
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Empresa:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListEmpresa" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListEmpresa_SelectedIndexChanged">
                                                    <asp:ListItem Value="3">&lt;Seleccionar una Empresa&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <h3>
                                                    <asp:Label ID="LabelCuenta" runat="server" Text="Cuenta:"></asp:Label></h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListCuentas" runat="server" AutoPostBack="True" class="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                   
                                    </table>


                                    <asp:Panel ID="PanelImpuestos" runat="server" GroupingText="Impuestos">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style2">
                                                    <h3>IIBB CABA</h3>
                                                </td>
                                                <td>
                                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                                    <div class="float-left">
                                                        <asp:TextBox ID="TextBoxIIBBCABA" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <h3>IIBB ARBA</h3>
                                                </td>
                                                <td>
                                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                                    <div class="float-left">
                                                        <asp:TextBox ID="TextBoxIIBBARBA" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                                    </div>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <h3>Percepcion IVA:</h3>
                                                </td>
                                                <td>
                                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                                    <div class="float-left">
                                                        <asp:TextBox ID="TextBoxPercepcionIva" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                                    </div>
                                                </td>

                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <table style="width: 100%;">

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="width: 20%;">
                                                <h3>Total Factura</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxTotalFactura" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>


                                <asp:Panel ID="PanelDetalleComprobante" runat="server" GroupingText="Detalle Comprobante">
                                    <table style="width: 100%;">

                                        <tr>
                                            <td>

                                                <h3>Tipo Movimiento:</h3>
                                            </td>
                                            <td>
                                                <ajaxToolkit:ComboBox ID="ComboTipoMovimiento" runat="server" Width="400px"
                                                    AutoPostBack="False"
                                                    DropDownStyle="Simple"
                                                    AutoCompleteMode="Suggest"
                                                    CaseSensitive="False"
                                                    CssClass=""
                                                    ItemInsertLocation="Append">
                                                </ajaxToolkit:ComboBox>

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Centro de Costo: </h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListCentrosCosto" runat="server" class="form-control" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="null">&lt;Seleccionar un Centro de Costo&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="LabelCCREquerido" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red">Centro de Costo es Requerido.</asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Descripcion:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDescripcionItem" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="DetalleRequired2" runat="server" ControlToValidate="TextBoxDescripcionItem" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="AgregarItem"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Tipo de IVA:</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListImpuestos" runat="server" class="form-control">
                                                    <asp:ListItem Value="null">&lt;Seleccionar un Tipo de IVA&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Precio Unitario:</h3>
                                            </td>
                                            <td>
                                                <div class="float-left">&nbsp;$&nbsp;</div>
                                                <div class="float-left">
                                                    <asp:TextBox ID="TextBoxImporteItem" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="DetalleRequired1" runat="server" ControlToValidate="TextBoxImporteItem" Display="Dynamic" ErrorMessage="Precio Unitario es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="AgregarItem"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Cantidad:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCantidadItem" runat="server" class="form-control" Width="100px"></asp:TextBox>

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <h3>Impuesto Interno:</h3>
                                            </td>
                                            <td>
                                                <div class="float-left">&nbsp;$&nbsp;</div>
                                                <div class="float-left">
                                                    <asp:TextBox ID="TextBoxImpuestoInterno" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Nro de Presupuesto (Si Corresponde):</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                <asp:Button ID="ButtonVerificar" runat="server" Text="Verificar" CssClass="btn btn-success" OnClick="ButtonVerificar_Click" />
                                                <asp:Label ID="LabelVerificado" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Unidad de Negocio (Si Corresponde):</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" class="form-control" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="null">&lt;Seleccione Unidad Negocio&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <h3>Degustacion (Si Corresponde):</h3>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListDegustacion" runat="server" class="form-control" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="null">&lt;Seleccione Degustacion&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>

                                                <asp:Button ID="ButtonAgregarItem" runat="server" class="btn btn-success" Text="Agregar Item" OnClick="ButtonAgregarItem_Click" ValidationGroup="AgregarItem" />&nbsp;&nbsp;
                                                                <asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar Item" OnClick="ButtonQuitar_Click" /></td>
                                            <td>
                                                <h3>&nbsp;</h3>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <h3>Total Detalle</h3>
                                            </td>
                                            <td colspan="2">

                                                <asp:TextBox ID="TextBoxTotalItem" runat="server" class="form-control"></asp:TextBox>

                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>



                                        <tr>
                                            <td colspan="3">
                                                <asp:UpdatePanel ID="UpdatePanelGrillaDetalle" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridViewDetalle" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#ffffcc" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <EmptyDataTemplate>
                                                                ¡No hay  Items agregados al detalle del Comprobante!  
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxQuitarItem" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                <asp:BoundField DataField="CentroCostoDescripcion" HeaderText="CC." SortExpression="CentroCostoDescripcion" />
                                                                <asp:BoundField DataField="TipoMovimientoCodigo" HeaderText="Cuenta" SortExpression="TipoMovimientoCodigo" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                <asp:BoundField DataField="PresupuestoId" HeaderText="Nro Presupuesto" SortExpression="PresupuestoId" />
                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                <asp:BoundField DataField="Importe" HeaderText="Importe" SortExpression="Importe" />
                                                                <asp:BoundField DataField="ValorImpuesto" HeaderText="Importe Imp." SortExpression="ValorImpuesto" />
                                                                <asp:BoundField DataField="ValorImpuestoInterno" HeaderText="Importe Imp. Int." SortExpression="ValorImpuestoInterno" />

                                                            </Columns>

                                                        </asp:GridView>
                                                    </ContentTemplate>

                                                </asp:UpdatePanel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DropDownListTipoPago" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonRevisar" runat="server" Text="Revisar" class="btn btn-primary" OnClick="ButtonRevisar_Click" />
                &nbsp;|&nbsp;
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                &nbsp;|&nbsp;
                <asp:Button ID="ButtonAceptaryContinuar" runat="server" Text="Aceptar y Continuar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptaryContinuar_Click" Visible="true" />
                &nbsp;|&nbsp;
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
