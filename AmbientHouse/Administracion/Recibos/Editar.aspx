<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Recibos.Editar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
            width: 50%;
        }

        .auto-style3 {
            width: 50%;
        }
        .auto-style4 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanelRecibos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelRecibos" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Recibos
                                           
                    </div>

                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style4">Tipo Recibo</td>
                                <td>
                                     <asp:DropDownList ID="DropDownListTipoRecibo" runat="server" AutoPostBack="True" CssClass="form-control" Width="80%">
                                         <asp:ListItem Value="RC">Recibo Clientes</asp:ListItem>
                                         <asp:ListItem Value="RV">Recibo Vario</asp:ListItem>
                                    </asp:DropDownList></td>

                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>
                                    &nbsp;</td>

                            </tr>
                            <tr>
                                <td class="auto-style4">Nro Recibo:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroRecibo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NroReciboRequired" runat="server" ControlToValidate="TextBoxNroRecibo" Display="Dynamic" ErrorMessage="Nro. Recibo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Concepto</td>
                                <td>
                                    <asp:TextBox ID="TextBoxConcepto" runat="server" CssClass="form-control" MaxLength="500" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConceptoRequired" runat="server" ControlToValidate="TextBoxConcepto" Display="Dynamic" ErrorMessage="Concepto es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td class="auto-style4">Fecha Recibo:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaRecibo" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FechaReciboRequired" runat="server" ControlToValidate="TextBoxFechaRecibo" Display="Dynamic" ErrorMessage="Fecha Recibo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaRecibo" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaRecibo" TodaysDateFormat="" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Tipo Movimiento:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoMovimiento" runat="server" AutoPostBack="True" CssClass="form-control" Width="80%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Importe</td>
                                <td>
                                    <asp:TextBox ID="TextBoxImporte" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ImporteRequired" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Forma de Pago</td>
                                <td>

                                    <asp:DropDownList ID="DropDownListFormaPago" runat="server" CssClass="form-control" Width="60%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFormaPago_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td class="auto-style4">Cuenta</td>
                                <td>

                                    <asp:DropDownList ID="DropDownListCuentas" runat="server" CssClass="form-control" Width="60%" AutoPostBack="True" ></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1" colspan="2">
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
                                                            <td class="auto-style3">
                                                                <h4>Nro. Comprobante:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNroComprobanteTrans" runat="server" class="form-control"></asp:TextBox></td>

                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style3">
                                                                <h4>Fecha Comprobante</h4>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxFechaComprobanteTrans" runat="server" class="form-control"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="TextBoxFechaComprobanteTrans_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaComprobanteTrans" TodaysDateFormat="" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style3">
                                                                <h4>Banco Receptor</h4>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListBancoTransferencia" runat="server" class="form-control" Width="100%">
                                                                </asp:DropDownList>

                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style3">
                                                                <h4>Cargar Comprobante de Pago Transferencia:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:FileUpload ID="FileUploadComprobanteTransferencia" runat="server" />
                                                                &nbsp;</td>

                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListFormaPago" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Imputado a Proveedor:</td>
                                <td>
                                    <div style="float: left;">
                                        <asp:TextBox ID="TextBoxCuitProveedor" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                    </div>
                                    &nbsp;&nbsp;
                                    <div style="float: left;">
                                        <asp:Button ID="ButtonBuscarProveedor" runat="server" Text="Buscar Proveedor" class="btn btn-info" OnClick="ButtonBuscarProveedor_Click"  />
                                    </div>


                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelGrillaPresupuestoProveedor" runat="server" UpdateMode="Conditional">

                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">Imputado a Presupuesto:</td>
                                <td> <div style="float: left;">
                                        <asp:TextBox ID="TextBoxNroPresupuesto" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                    </div>
                                    &nbsp;&nbsp;
                                    <div style="float: left;">
                                        <asp:Button ID="ButtonBuscarPresupuesto" runat="server" Text="Buscar Presupuesto" class="btn btn-info" OnClick="ButtonBuscarPresupuesto_Click"  />
                                    </div>
</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Resultado" runat="server" With="100%"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                                    <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
