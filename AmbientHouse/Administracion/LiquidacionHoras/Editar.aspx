<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.LiquidacionHoras.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelLiquidacion" runat="server" UpdateMode="Conditional">
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
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Agregar/Editar Liquidacion<br />
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <h3>Descripcion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Fecha:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Nro. Presupuesto:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxPresupuesto" runat="server" class="form-control"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonGenerarLiquidacion" runat="server" class="btn btn-primary" Text="Generar Liquidacion" OnClick="ButtonGenerarLiquidacion_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>

                                </table>

                                <div class="panel-body">
                                    <asp:Panel ID="PanelAgregarEmpleados" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Servicio</td>
                                                <td>Puesto</td>
                                                <td>Categoria</td>
                                                <td>Empleado</td>
                                                <td>Hora Entrada</td>
                                                <td>Hora Salida</td>
                                                <td>&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td style="width: 10%;">
                                                    <asp:DropDownList ID="DropDownListSectorEmpresa" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSectorEmpresa_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:DropDownList ID="DropDownListTipoEmpleado" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoEmpleado_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:DropDownList ID="DropDownListTipoPago" runat="server" CssClass="form-control" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:DropDownList ID="DropDownListEmpleado" runat="server" CssClass="form-control" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:TextBox ID="TextBoxHoraEntrada" runat="server" CssClass="form-control" Width="100%" MaxLength="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="HoraEntradaRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraEntrada" Display="Dynamic" ErrorMessage="Hora Entrada es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraEntrada" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraEntrada" UserTimeFormat="TwentyFourHour" />
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:TextBox ID="TextBoxHoraSalida" runat="server" CssClass="form-control" Width="100%" MaxLength="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="HoraSalidaRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraSalida" Display="Dynamic" ErrorMessage="Hora Salida es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraSalida" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraSalida" UserTimeFormat="TwentyFourHour" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="ButtonAgregar" class="btn btn-success" runat="server" Text="Agregar Empleado" OnClick="ButtonAgregar_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <asp:GridView ID="GridViewDetalle" runat="server" CssClass="table table-bordered bs-table" 
                                            AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" 
                                            ForeColor="#333333" GridLines="None" Width="100%"
                                            OnRowDataBound="GridViewDetalle_RowDataBound" OnRowCommand="GridViewDetalle_RowCommand" >
                                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775"/>
                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#ffffcc" />
                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                            <EmptyDataTemplate>
                                                ¡No hay Personas agregadas!  
                                            </EmptyDataTemplate>
                                            <Columns>

                                                <asp:BoundField DataField="Id" HeaderText="#" SortExpression="Id" ItemStyle-Width="1%" >

                                                <ItemStyle Width="1%" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%" HeaderText="Servicio">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownListSectorEmpresaGrilla" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSectorEmpresaGrilla_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%" HeaderText="Puesto">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownListTipoEmpleadoGrilla" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoEmpleado_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%" HeaderText="Categoria">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownListTipoPagoGrilla" runat="server" CssClass="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="20%" HeaderText="Empleado">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DropDownListEmpleadoGrilla" runat="server" CssClass="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%" HeaderText="Hora Entrada">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBoxHoraEntradaGrilla" runat="server" CssClass="form-control" Width="100%" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="HoraEntradaRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraEntradaGrilla" Display="Dynamic" ErrorMessage="Hora Entrada es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraEntrada" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraEntradaGrilla" UserTimeFormat="TwentyFourHour" />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%" HeaderText="Hora Salida">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBoxHoraSalidaGrilla" runat="server" CssClass="form-control" Width="100%" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="HoraSalidaRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraSalidaGrilla" Display="Dynamic" ErrorMessage="Hora Salida es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraSalida" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraSalidaGrilla" UserTimeFormat="TwentyFourHour" />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" ItemStyle-Width="10%" >
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100%">
                                                    <ItemTemplate>
                                                        <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100%">
                                                    <ItemTemplate>
                                                        <asp:Button ID="ButtonQuitar" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100%" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>

                                            </Columns>

                                        </asp:GridView>
                                    </ContentTemplate>

                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonAgregar" EventName="Click" />
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
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

