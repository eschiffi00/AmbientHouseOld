<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.PagoProveedores.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    <link href="../../Content/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>


    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }

    </style>


    <script>
        var j = jQuery.noConflict();

        function ShowError(error) {
            var texto;
            switch (error) {
                case "1":
                    texto = 'El Monto a Pagar es mayor que el Costo';
                    break;
                case "2":
                    texto = 'El Monto a Pagar es distinto del Importe Saldo';
                    break;
            }
            j(function () {
                j('#dialog').dialog({
                    modal: true,
                    width: 'auto',
                    resizable: false,
                    draggable: false,
                    close: function (event, ui) { j('body').find('#dialog').remove(); },
                    closeText: "X",
                    show: "fade",
                    hide: "fade",
                    open: function () {
                        $(this).html(texto);
                    },
                    
                })
            });
            
            j("#dialog").dialog("open");
            j('#dialog').html(texto).dialog({});
            /*$("#dialog").html(texto);*/
        }
    </script>
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
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>


                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                              <h3>COMPROBANTES</h3>
                                            <asp:GridView ID="GridViewComprobantes" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                <Columns>
                                                    <asp:BoundField DataField="EmpresaRS" HeaderText="Empresa" SortExpression="EmpresaRS" />
                                                    <asp:BoundField DataField="TipoComprobanteDescripcion" HeaderText="Tipo Comprobante" SortExpression="TipoComprobanteDescripcion" />
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                                    <asp:BoundField DataField="NroComprobante" HeaderText="Nro Comprobante" SortExpression="NroComprobante" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" />
                                                    <asp:BoundField DataField="MontoFactura" HeaderText="Monto Factura $" SortExpression="MontoFactura" />

                                                </Columns>

                                            </asp:GridView>
                                            <asp:GridView ID="GridViewPresupuestos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                <Columns>
                                                    <asp:BoundField DataField="NroComprobante" HeaderText="Comprobante" />
                                                    <asp:BoundField DataField="NroPresupuesto" HeaderText="Presupuesto" Visible="false"/>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                                                    <asp:BoundField DataField="TipoMovimiento" HeaderText="CodTipoMovimiento" Visible="false"/>
                                                    <asp:BoundField DataField="TMDescripcion" HeaderText="Tipo de Movimiento"/>
                                                    <asp:BoundField DataField="Costo" HeaderText="Costo"/>
                                                    <asp:BoundField DataField="ValorImpuesto" HeaderText="Impuesto"/>
                                                    <asp:TemplateField HeaderText="Monto a Pagar">
                                                        <ItemTemplate>
                                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                                            <asp:TextBox id="MontoaPagar" runat="server" class="form-control" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <h3>NOTAS DE CREDITO</h3>
                                            <asp:GridView ID="GridViewNotasCredito" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay Notas de Credito" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" />
                                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="Importe" />

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
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            Nro. Orden de Pago:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroOrdenPago" runat="server" class="form-control" ReadOnly="true"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha:
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
                                        <td>
                                            Importe Saldo:
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
                                        <td>
                                            Importe Pagado:
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxImportePagado" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            Cuenta:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCuenta" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>


                                    <tr>
                                        <td>
                                            Forma de Pago:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListFormadePago" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                </table>
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
                                                    <asp:TextBox ID="TextBoxNroCheque" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNroCheques" runat="server" ControlToValidate="TextBoxNroCheque" Display="Dynamic" ErrorMessage="Nro. de Cheque es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>

                                                    <asp:Label ID="LabelChequeRepetido" runat="server" Text="En Nro. de Cheque ya esxiste en el sistema." ForeColor="#FF3300"></asp:Label>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Importe:</h4>
                                                </td>
                                                <td>
                                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                                    <div class="float-left">
                                                        <asp:TextBox ID="TextBoxImporteCheque" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorImporte" runat="server" ControlToValidate="TextBoxImporteCheque" Display="Dynamic" ErrorMessage="Importe de Cheque es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Fecha Emision:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaEmision" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaEmision_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmision" TodaysDateFormat="" />
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaEmision" runat="server" ControlToValidate="TextBoxFechaEmision" Display="Dynamic" ErrorMessage="Fecha Emision es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Fecha Vencimiento:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaVencimiento_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimiento" TodaysDateFormat="" />
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorVencimiento" runat="server" ControlToValidate="TextBoxFechaVencimiento" Display="Dynamic" ErrorMessage="Fecha Vencimiento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cheques"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Proveedor</h4>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control">
                                                    </asp:DropDownList></td>
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

                                        <asp:Button ID="ButtonAgregarCheques" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregarCheques_Click" ValidationGroup="Cheques" />
                                        &nbsp;|&nbsp;<asp:Button ID="ButtonQuitarCheques" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitarCheques_Click" />
                                        <br />
                                        <br />
                                        <br />
                                        <table style="width: 100%;">


                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:GridView ID="GridViewCheques" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#ffffcc" />
                                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                        <Columns>


                                                            <asp:BoundField DataField="NroCheque" HeaderText="Nro. Cheque" SortExpression="NroCheque" />
                                                            <asp:BoundField DataField="Importe" HeaderText="Importe" SortExpression="Importe" />

                                                            <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:dd/MM/yyyy}" SortExpression="FechaEmision" />
                                                            <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}" SortExpression="FechaVencimiento" />



                                                        </Columns>

                                                    </asp:GridView>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelTransferencia" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Transferencias
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <h4>CBU Proveedor:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCBU" runat="server" class="form-control" ReadOnly="true" Width="200px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1">
                                                    <h4>Nro. Comprobante:</h4>
                                                </td>
                                                <td class="auto-style1">
                                                    <asp:TextBox ID="TextBoxNroComprobanteTrans" runat="server" class="form-control"></asp:TextBox></td>
                                                <td class="auto-style1"></td>
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelRetenciones" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Retenciones
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <h4>Tipo Retencion</h4>
                                                </td>
                                                <td>


                                                    <asp:DropDownList ID="DropDownListTipoMoviminetos" runat="server">
                                                    </asp:DropDownList>


                                                    <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Nro. Certificado:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxNroCertificado" runat="server" class="form-control"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Importe</h4>
                                                </td>
                                                <td>
                                                    <div class="float-left">&nbsp;$&nbsp;</div>
                                                    <div class="float-left">
                                                        <asp:TextBox ID="TextBoxImporteRetencion" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    </div>
                                                    <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div id="dialog" style="display: none;" title="Monto Erroneo">
      <%--<p>
        El Monto a Pagar es mayor que el Costo
      </p>--%>
    </div>


</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
