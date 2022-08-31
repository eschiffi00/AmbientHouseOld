<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Egreso.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Egreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 316px;
        }

        .auto-style4 {
            width: 313px;
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
                <asp:UpdatePanel ID="UpdatePanelEgreso" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Egresos
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Cuenta:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCuenta" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Fecha Comprobante:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />--%>
                                               <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFecha" CultureName="en-nz" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="TextBoxFecha" Display="Dynamic"
                                                ErrorMessage="Fecha es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items">

                                            </asp:RequiredFieldValidator>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Proveedor:</h3>
                                        </td>
                                        <td>
                                            <ajaxToolkit:ComboBox ID="ComboBoxProveedor" runat="server" Width="400px"
                                                AutoPostBack="False"
                                                DropDownStyle="Simple"
                                                AutoCompleteMode="Suggest"
                                                CaseSensitive="False"
                                                CssClass=""
                                                ItemInsertLocation="Append">
                                            </ajaxToolkit:ComboBox>
                                        </td>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Nro. Comprobante:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroComprobante" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TextBoxNroComprobante" Display="Dynamic"
                                                ErrorMessage="Nro de Comprobante es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items">

                                            </asp:RequiredFieldValidator>
                                            <asp:Label ID="LabelErrorNroComprobante" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Concepto:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxConcepto" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="TextBoxConcepto" Display="Dynamic"
                                                ErrorMessage="Concepto es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items">

                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Importe:</h3>
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxImporte" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorImporte" runat="server"
                                                ControlToValidate="TextBoxImporte" Display="Dynamic"
                                                ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Items">

                                            </asp:RequiredFieldValidator>

                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <h3>Centro de Costo:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCentroCosto" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
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
                                        <td class="auto-style3">
                                            <h3>Nro de Presupuesto (Si Corresponde):</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control" Width="10%"></asp:TextBox>
                                            <asp:Button ID="ButtonVerificar" runat="server" Text="Verificar" CssClass="btn btn-success" OnClick="ButtonVerificar_Click" />
                                            <asp:Label ID="LabelVerificado" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
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
                                        <td colspan="4">
                                            <asp:Panel ID="PanelImpuestos" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>Tipo de Impuesto:</h3>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListTipoImpuesto" CssClass="form-control" AppendDataBoundItems="true" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoImpuesto_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">&lt;Sin Impuestos&gt;</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>Valor Impuesto:</h3>
                                                        </td>
                                                        <td>
                                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                                            <div class="float-left">
                                                                <asp:TextBox ID="TextBoxValorImpuesto" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>IIBB CABA</h3>
                                                        </td>
                                                        <td>
                                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                                            <div class="float-left">
                                                                <asp:TextBox ID="TextBoxIIBBCABA" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>IIBB ARBA</h3>
                                                        </td>
                                                        <td>
                                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                                            <div class="float-left">
                                                                <asp:TextBox ID="TextBoxIIBBARBA" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>Percepcion IVA</h3>
                                                        </td>
                                                        <td>
                                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                                            <div class="float-left">
                                                                <asp:TextBox ID="TextBoxPercepcionIVA" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style4">
                                                            <h3>Empresa</h3>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListEmpresa" CssClass="form-control" AppendDataBoundItems="true" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoImpuesto_SelectedIndexChanged">
                                                                <asp:ListItem Value="3">&lt;Sin Empresa&gt;</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                &nbsp;
                <asp:Button ID="ButtonAceptaryContinuar" runat="server" Text="Aceptar y Continuar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptaryContinuar_Click" />
                &nbsp;
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
