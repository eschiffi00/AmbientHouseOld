<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="AmbientHouse.Administracion.PagoProveedores.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 324px;
        }

        .auto-style2 {
            width: 382px;
        }

        .auto-style3 {
            width: 286px;
        }

        .auto-style4 {
            width: 390px;
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
                        Agregar/Editar Pago a Proveedores
                    </div>
                    <div class="panel-body">

                        <asp:UpdatePanel ID="UpdatePanelPagoProveedores" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table style="width: 100%;">

                                    <tr>

                                        <td>
                                            <h3>COMPROBANTES</h3>
                                            <asp:GridView ID="GridViewComprobantes" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                <Columns>
                                                    <asp:BoundField DataField="EmpresaRS" HeaderText="Empresa" SortExpression="EmpresaRS" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="TipoComprobanteDescripcion" HeaderText="Tipo Comprobante" SortExpression="TipoComprobanteDescripcion" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="NroComprobante" HeaderText="Nro Comprobante" SortExpression="NroComprobante" ItemStyle-Width="10%" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="MontoFactura" HeaderText="Monto Factura " SortExpression="MontoFactura" DataFormatString="{0:C0}" ItemStyle-Width="15%" />

                                                </Columns>

                                            </asp:GridView>
                                        </td>

                                    </tr>
                                </table>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 20%;"></td>
                                        <td style="width: 20%;"></td>
                                        <td style="width: 20%;"></td>
                                        <td style="width: 10%;"></td>
                                        <td style="width: 15%;">Total Facturas</td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="LabelTotalFacturas" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                        <td></td>
                                    </tr>
                                </table>
                                <table style="width: 100%;">
                                    <tr>

                                        <td>
                                            <h3>NOTAS DE CREDITO</h3>
                                            <asp:GridView ID="GridViewNotasCredito" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay Notas de Credito" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" ItemStyle-Width="40%" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" ItemStyle-Width="45%" />
                                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="Importe" ItemStyle-Width="15%" />

                                                </Columns>

                                            </asp:GridView>
                                        </td>

                                    </tr>

                                </table>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 40%;"></td>
                                        <td style="width: 45%;">Total Notas de Credito</td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="LabelTotalNotaCredito" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                    </tr>
                                </table>
                                <table style="width: 100%;">
                                    <tr>

                                        <td>
                                            <h3>PAGOS ANTERIORES</h3>
                                            <asp:GridView ID="GridViewPagosRealizados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Impuestos con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>

                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" ItemStyle-Width="10%" />
                                                    <asp:BoundField DataField="NroOrdenPago" HeaderText="Nro Orden Pago" SortExpression="NroOrdenPago" ItemStyle-Width="10%" />
                                                    <asp:BoundField DataField="CuentaNombre" HeaderText="Cuenta" SortExpression="CuentaNombre" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="FormaPagoDescripcion" HeaderText="Forma de Pago" SortExpression="FormaPagoDescripcion" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="NroCheque" HeaderText="Nro. Cheque" SortExpression="NroCheque" ItemStyle-Width="10%" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="Importe" ItemStyle-Width="15%" />

                                                </Columns>

                                            </asp:GridView>
                                        </td>

                                    </tr>

                                </table>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 10%;"></td>
                                        <td style="width: 10%;"></td>
                                        <td style="width: 20%;"></td>
                                        <td style="width: 20%;"></td>
                                        <td style="width: 10%;"></td>
                                        <td style="width: 15%;">Total Pagos</td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="LabelPagos" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                    </tr>
                                </table>

                                <asp:Panel ID="PanelOP" runat="server">
                                    <h3>ORDEN DE PAGO</h3>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>Fecha:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFecha" CultureName="en-nz" />
                                                <asp:RequiredFieldValidator ID="FechaRequired" runat="server" ControlToValidate="TextBoxFecha" Display="Dynamic" ErrorMessage="Fecha de pago es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Importe Saldo:
                                            </td>
                                            <td>
                                                <div class="float-left">&nbsp;$&nbsp;</div>
                                                <div class="float-left">
                                                    <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                            </td>
                                            <td></td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>Cuenta:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListCuenta" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>


                                        <tr>
                                            <td>Forma de Pago:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListFormadePago" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="PanelCheques" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Cheques
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style2">Nro. Cheque:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxNroCheque" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNroCheques" runat="server" ControlToValidate="TextBoxNroCheque" Display="Dynamic" ErrorMessage="Nro. de Cheque es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="LabelChequeRepetido" runat="server" ForeColor="#FF3300" Text="En Nro. de Cheque ya esxiste en el sistema."></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">Fecha Emision:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaEmision" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaEmision_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmision" TodaysDateFormat="" />
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaEmision" runat="server" ControlToValidate="TextBoxFechaEmision" Display="Dynamic" ErrorMessage="Fecha Emision es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">Fecha Vencimiento:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaVencimiento_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimiento" TodaysDateFormat="" />
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorVencimiento" runat="server" ControlToValidate="TextBoxFechaVencimiento" Display="Dynamic" ErrorMessage="Fecha Vencimiento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">Proveedor:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control">
                                                    </asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">Banco:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListBancos" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style2">Observaciones:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxObservaciones" runat="server" class="form-control" Height="150px" MaxLength="2000" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                        <asp:Button ID="ButtonAgregarCheque" runat="server" class="btn btn-success" Text="Agregar Pagos" ValidationGroup="Cheques" OnClick="ButtonAgregarCheque_Click"  />
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelTransferencia" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Transferencias
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style3">
                                                    <h4>CBU Proveedor:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCBU" runat="server" class="form-control" ReadOnly="true" Width="200px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style3">
                                                    <h4>Nro. Comprobante:</h4>
                                                </td>
                                                <td class="auto-style1">
                                                    <asp:TextBox ID="TextBoxNroComprobanteTrans" runat="server" class="form-control"></asp:TextBox></td>
                                                <td class="auto-style1"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <asp:Button ID="ButtonAgregarTransferencia" runat="server" class="btn btn-success" Text="Agregar Pagos" ValidationGroup="Items" OnClick="ButtonAgregarTransferencia_Click"  />
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelRetenciones" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Retenciones
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style4">
                                                    <h4>Tipo Retencion</h4>
                                                </td>
                                                <td>


                                                    <asp:DropDownList ID="DropDownListTipoMoviminetos" runat="server">
                                                    </asp:DropDownList>


                                                    <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">
                                                    <h4>Nro. Certificado:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxNroCertificado" runat="server" class="form-control"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <asp:Button ID="ButtonAgregarRetencion" runat="server" class="btn btn-success" Text="Agregar Pagos" ValidationGroup="Items" OnClick="ButtonAgregarRetencion_Click"  />

                                    </div>
                                </asp:Panel>
                                  <asp:Button ID="ButtonAgregarPagos" runat="server" class="btn btn-success" Text="Agregar Pagos" ValidationGroup="Items" OnClick="ButtonAgregarPagos_Click"    />

                                
                                <asp:Panel ID="PanelPagos" runat="server">
                                    <asp:GridView ID="GridViewPagos" runat="server" CssClass="table table-bordered bs-table"
                                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros"
                                        ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" OnRowCommand="GridViewPagos_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="#" SortExpression="Id" />
                                            <asp:BoundField DataField="FormadePagoDescripcion" HeaderText="Forma de Pago" SortExpression="FormadePagoDescripcion" />
                                            <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comprobante" SortExpression="NroCheque" />
                                            <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="Importe" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonQuitarItem" runat="server" Text="Quitar" class="btn btn-danger" CommandName="QuitarItem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>

                                </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar"  class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
