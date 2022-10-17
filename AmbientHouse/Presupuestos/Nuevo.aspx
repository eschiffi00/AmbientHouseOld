<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Nuevo.aspx.cs" Inherits="AmbientHouse.Presupuestos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script> 
      $(document).ready(function () {
            $("#datetimepickerRemito").datetimepicker({
                timepicker: false,
                mask: true,
                format: 'd/m/Y',
            });
            $("#ddlClienteId").select2();
            $("select[id *= 'DropDownListLocaciones']").select2();


        });
    </script>
    <style type="text/css">
        .auto-style2 {
            height: 20px;
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
                <asp:UpdatePanel ID="UpdatePanelCotizador" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="PanelCotixador" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Evento</div>
                                <div class="panel-body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <h3>Cliente:</h3>
                                                <asp:Panel ID="PanelBuscarCliente" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td>Apellido y Nombre:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxApellidoBuscador" runat="server" Width="450px" class="form-control"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="LabelMensajeCliente" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>
                                                                <asp:Button ID="ButtonBuscarCliente" runat="server" Text="Buscar Clientes" class="btn btn-primary" OnClick="ButtonBuscarCliente_Click" />
                                                                <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar" OnClick="ButtonLimpiar_Click" />
                                                            </td>
                                                            <td class="auto-style3"></td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td class="auto-style3">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                                <asp:Panel ID="PanelListarClientes" runat="server">
                                                    <div class="panel panel-info">
                                                        <div class="panel-heading">Listado de Clientes</div>
                                                        <div class="panel-body">
                                                            <table style="width: 100%;">

                                                                <tr>
                                                                    <th>Seleccione un cliente:</th>
                                                                    <th>
                                                                        <asp:DropDownList ID="DropDownListClientesPipe" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListClientesPipe_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="TextBoxCliente" runat="server" ReadOnly="True" class="form-control" Width="300px" OnTextChanged="TextBoxCliente_TextChanged"></asp:TextBox>


                                                                    </th>
                                                                    <td>&nbsp;</td>
                                                                </tr>

                                                            </table>

                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <h3>Invitados:</h3>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Panel ID="PanelInvitados" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <th>Cant. de Mayores:</th>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantMayores" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="CantMayoresRequiredFieldValidator" runat="server" ControlToValidate="TextBoxCantMayores" Display="Dynamic" ErrorMessage="Cantidad de Invitados Mayores es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>

                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderCantInvitados" runat="server" TargetControlID="TextBoxCantMayores" Mask="9999" MaskType="Number" InputDirection="RightToLeft" />--%>

                                                            </td>
                                                            <td>Cant. de Adolescentes:</td>
                                                            <td></td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantAdolescentes" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderCantAdolecentes" runat="server" TargetControlID="TextBoxCantAdolescentes" Mask="9999" MaskType="Number" InputDirection="RightToLeft" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Cant. Menores de 3 años:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantMenores3" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderCantMenores3" runat="server" TargetControlID="TextBoxCantMenores3" Mask="9999" MaskType="Number" InputDirection="RightToLeft" />--%>
                                                            </td>
                                                            <td>Cant. entre 3 y 8 años:</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantEntre3y8" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderCantEntre3y8" runat="server" TargetControlID="TextBoxCantEntre3y8" Mask="9999" MaskType="Number" InputDirection="RightToLeft" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <br />
                                                <asp:Panel ID="PanelFechaEvento" runat="server" GroupingText="">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <th>&nbsp;</th>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <h3>Fecha Evento:</h3>
                                                                <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server"
                                                                    AutoPostBack="True"
                                                                    class="form-control"
                                                                    Width="700px"
                                                                    TextMode ="Date"
                                                                    Format="dd/MM/yyyy" 
                                                                    OnTextChanged="TextBoxFechaDesdeEvento_TextChanged" CssClass="black"></asp:TextBox>

                                                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesdeEvento" TodaysDateFormat="" CssClass="black" />--%>
                                                                <asp:RequiredFieldValidator ID="FechaEventoRequiredFieldValidator" runat="server" ControlToValidate="TextBoxFechaDesdeEvento" Display="Dynamic" ErrorMessage="Fecha Evento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>

                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="GridViewEventosReservadosConfirmados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Eventos Confirmados/Reservados con la fecha seleccionada!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ApellidoNombre" HeaderText="Cliente" SortExpression="ApellidoNombre" />
                                                                        <asp:BoundField DataField="CARACTERISTICA" HeaderText="Caracteristicas" SortExpression="CARACTERISTICA" />
                                                                        <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                                                        <asp:BoundField DataField="SECTOR" HeaderText="Sector" SortExpression="SECTOR" />
                                                                        <asp:BoundField DataField="JORNADA" HeaderText="Jornada" SortExpression="JORNADA" />
                                                                        <asp:BoundField DataField="HorarioEvento" HeaderText="Horario" SortExpression="HorarioEvento" />
                                                                        <asp:BoundField DataField="CantidadInicialInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInicialInvitados" />
                                                                        <asp:BoundField DataField="FechaEvento" DataFormatString="{0:d}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                                                        <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;
                                                   
                                                        <asp:Panel ID="PanelTipoEventos" runat="server">
                                                            <div class="panel-heading">
                                                                <h3>Datos del Evento</h3>
                                                            </div>
                                                            <div class="panel-body">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>Hora Inicio:<asp:TextBox ID="TextBoxHoraInicio" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraInicio" TargetControlID="TextBoxHoraInicio" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />

                                                                            <asp:RequiredFieldValidator ID="HoraInicioRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraInicio" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>Hora Fin:<asp:TextBox ID="TextBoxHoraFin" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="HoraFinRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraFin" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraFin" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraFin" UserTimeFormat="TwentyFourHour" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="LabelHoraInicio" runat="server" ForeColor="Red" Text="Hora Invalida"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="LabelHoraFin" runat="server" ForeColor="Red" Text="Hora Invalida"></asp:Label>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">Tipo de Evento:
                                                                            <asp:DropDownList ID="DropDownListTipoEvento" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListTipoEvento_SelectedIndexChanged" Width="100%">
                                                                            </asp:DropDownList>
                                                                            <asp:UpdatePanel ID="UpdatePanelTipoEventoOtro" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="TextBoxOtroTipoEvento" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Momento del Dia:<asp:DropDownList ID="DropDownListMomentodelDia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListMomentodelDia_SelectedIndexChanged" Width="100%">
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">Caracteristicas:<asp:DropDownList ID="DropDownListCaracteristicas" runat="server" Width="100%" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListCaracteristicas_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Jornada<asp:DropDownList ID="DropDownListJornadas" runat="server" Width="100%" AutoPostBack="True" class="form-control">
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">Segmentos:<asp:DropDownList ID="DropDownListSegmentos" runat="server" Width="100%" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListSegmentos_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">Locaciones:
                                                                            <asp:DropDownList ID="DropDownListLocaciones" runat="server" Width="100%" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListLocaciones_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanelSector" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="LabelSector" runat="server" Text="Sector:"></asp:Label>
                                                                                    <asp:DropDownList ID="DropDownListSectores" runat="server" Width="100%" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListSectores_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:UpdatePanel ID="UpdatePanelLocacionOut" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Panel ID="PanelLocacionOut" runat="server">
                                                                                        <table style="width: 100%;">
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>&nbsp;</td>

                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Locacion:</h4>
                                                                                                    <asp:DropDownList ID="DropDownListLocacionesOut" runat="server" AutoPostBack="True" class="form-control" Width="100%" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownListLocacionesOut_SelectedIndexChanged">
                                                                                                        <asp:ListItem Value="0">&lt;Seleccionar Locacion&gt;</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </td>

                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>

                                                                                                    <asp:TextBox ID="TextBoxOtroLocacion" runat="server" class="form-control" Width="100%"></asp:TextBox>


                                                                                                </td>

                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="DropDownListSectoresOut" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="DropDownListSectoresOut_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Direccion:</h4>
                                                                                                    <asp:TextBox ID="TextBoxDireccionLocacionOut" runat="server" class="form-control" Width="100%"></asp:TextBox>
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
                                                                                                    <h4>Localidad:</h4>
                                                                                                    <asp:DropDownList ID="DropDownListLocalidadOut" runat="server" class="form-control" Width="100%">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td></td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorPersona" runat="server" Text="Canon por Persona?" GroupName="Catering" OnCheckedChanged="RadioButtonCannonPorPersona_CheckedChanged" AutoPostBack="True" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorcentaje" runat="server" Text="Canon Porcentaje del Total?" GroupName="Catering" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonPorcentaje_CheckedChanged" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                     <asp:RadioButton ID="RadioButtonCannonAbsoluto" runat="server" Text="Canon Fijo del Total?" GroupName="Catering" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonAbsoluto_CheckedChanged" />

                                                                                                </td>
                                                                                                <td class="auto-style2"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Cannon Catering:</h4>
                                                                                                    <asp:TextBox ID="TextBoxCannonOut" runat="server" class="form-control" Width="150"></asp:TextBox></td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorPersonaBarra" runat="server" Text="Canon por Persona?" GroupName="Barra" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonPorPersonaBarra_CheckedChanged" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorcentajeBarra" runat="server" Text="Canon Porcentaje del Total?" GroupName="Barra" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonPorcentajeBarra_CheckedChanged" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                     <asp:RadioButton ID="RadioButtonCannonAbsolutoBarra" runat="server" Text="Canon Fijo del Total?" GroupName="Barra" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonAbsolutoBarra_CheckedChanged" /></td>
                                                                                                </td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Cannon Barra:</h4>
                                                                                                    <asp:TextBox ID="TextBoxCannonOutBarra" runat="server" class="form-control" Width="150"></asp:TextBox></td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorPersonaAmbientacion" runat="server" Text="Canon por Persona?" GroupName="Ambientacion" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonPorPersonaAmbientacion_CheckedChanged" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                    <asp:RadioButton ID="RadioButtonCannonPorcentajeAmbientacion" runat="server" Text="Canon Porcentaje del Total?" GroupName="Ambientacion" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonPorcentajeAmbientacion_CheckedChanged" />
                                                                                                    &nbsp;|&nbsp;
                                                                                                     <asp:RadioButton ID="RadioButtonCannonAbsolutoAmbientacion" runat="server" Text="Canon Fijo del Total?" GroupName="Ambientacion" AutoPostBack="True" OnCheckedChanged="RadioButtonCannonAbsolutoAmbientacion_CheckedChanged" /></td>
                                                                                                </td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Cannon Ambientacion:</h4>
                                                                                                    <asp:TextBox ID="TextBoxCannonOutAmbientacion" runat="server" class="form-control" Width="150"></asp:TextBox></td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <h4>Uso Cocina:</h4>
                                                                                                    <asp:TextBox ID="TextBoxUsoCocinaOUT" runat="server" class="form-control" Width="150"></asp:TextBox></td>
                                                                                                <td>&nbsp;</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>&nbsp;</td>
                                                                                                <td>
                                                                                                    <asp:Button ID="ButtonAgregarUbicacion" runat="server" class="btn btn-success" Text="Agregar Ubicacion Evento" ValidationGroup="Eventos" OnClick="ButtonAgregarUbicacion_Click" />
                                                                                                </td>

                                                                                                <td>&nbsp;</td>
                                                                                            </tr>

                                                                                        </table>

                                                                                    </asp:Panel>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:Label ID="LabelPrecioVentaSalon" runat="server" Text="Precio Venta:"></asp:Label>
                                                                            <asp:DropDownList ID="DropDownListPrecioSalon" runat="server" Width="100%" AppendDataBoundItems="True" AutoPostBack="True" class="form-control">
                                                                                <asp:ListItem Value="0.90">PL - 10%</asp:ListItem>
                                                                                <asp:ListItem Value="0.95">PL - 5%</asp:ListItem>
                                                                                <asp:ListItem Value="1">PL</asp:ListItem>
                                                                                <asp:ListItem Value="1.05">PL + 5%</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <%--<asp:Button ID="ButtonAgregarSalon" runat="server" class="btn btn-success" OnClick="ButtonAgregarSalon_Click" Text="Agregar Salon" ValidationGroup="Eventos" />--%>
                                                                            <asp:Button ID="ButtonAgregarSalon" runat="server" class="btn btn-success" Text="Agregar Salon" OnClick="ButtonAgregarSalon_Click" ValidationGroup="Eventos" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <asp:Panel ID="PanelArmarCotizacion" runat="server">
                                                                <div class="panel-heading">
                                                                    <h3>Armar Cotizacion</h3>
                                                                </div>
                                                                <div class="panel-body">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Unidad de Negocio:<asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocio_SelectedIndexChanged" Width="100%">
                                                                                <asp:ListItem Value="0">&lt;Seleccionar Unidad de Negocio&gt;</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td>Proveedor<asp:DropDownList ID="DropDownListProveedor" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListProveedor_SelectedIndexChanged" Width="100%">
                                                                                <asp:ListItem Value="null">&lt;Seleccionar un Proveedor&gt;</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Servicio<asp:DropDownList ID="DropDownListServicio" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" Width="100%">
                                                                                <asp:ListItem Value="0">&lt;Seleccionar un Producto&gt;</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td>Precio Venta<asp:DropDownList ID="DropDownListPrecios" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" Width="100%">
                                                                                <asp:ListItem Value="0">&lt;Seleccionar un Precio&gt;</asp:ListItem>
                                                                                <asp:ListItem Value="1.05">PL + 5%</asp:ListItem>
                                                                                <asp:ListItem Value="1">PL</asp:ListItem>
                                                                                <asp:ListItem Value="0.95">PL - 5%</asp:ListItem>
                                                                                <asp:ListItem Value="0.90">PL - 10%</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="LabelTipoLogistica" runat="server" Text="Tipo Logistica:"></asp:Label>
                                                                                <asp:DropDownList ID="DropDownListConceptoLogistica" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListConceptoLogistica_SelectedIndexChanged" Width="100%">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="LabelLogistica" runat="server" Text="Logistica:"></asp:Label>
                                                                                <asp:TextBox ID="TextBoxCostoLogistica" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="LabelCannon" runat="server" Text="Cannon:"></asp:Label>
                                                                                <asp:TextBox ID="TextBoxCostoCannonBarra" runat="server" class="form-control"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="LabelCantidadItemsOrganizacion" runat="server" Text="Cantidad:"></asp:Label>
                                                                                <asp:TextBox ID="TextBoxCantidadItemsOrganizacion" runat="server" class="form-control"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="PanelAmbientacionCorporativoInformal" runat="server">
                                                                <div class="panel-heading">
                                                                    <h3>Ambientacion Corporativa Informal</h3>
                                                                </div>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>Items de Ambientacion</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownListCIItemsAmbientacion" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>Cantidad de Paquetes</td>
                                                                        <td>
                                                                            <!--<asp:TextBox ID="TextBoxCICantidadPaquetesAmbientacion" runat="server" CssClass="form-control"></asp:TextBox>-->
                                                                            <asp:DropDownList ID="DropDownListCICantidadPaquetesAmbientacion" runat="server" CssClass="form-control">
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                <asp:ListItem>25</asp:ListItem>

                                                                            </asp:DropDownList>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>

                                                                    </tr>


                                                                    <div>
                                                                    </div>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="ButtonAgregarItem" runat="server" OnClick="ButtonAgregarItem_Click" class="btn btn-success" Text="Agregar al Presupuesto" Style="height: 26px" />
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
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <div class="panel-heading">
                                                                    <h3>Listado de Unidades Cotizadas</h3>
                                                                </div>
                                                                <div class="panel-body">

                                                                    <asp:GridView ID="GridViewVentas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewVentas_RowCommand" OnRowDataBound="GridViewVentas_RowDataBound">
                                                                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#ffffcc" />
                                                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                        <EmptyDataTemplate>
                                                                            ¡No hay Unidades agregadas al presupuesto!  
                                                                        </EmptyDataTemplate>

                                                                        <Columns>

                                                                            <asp:BoundField DataField="ProductoId" HeaderText="Item" SortExpression="ProductoId" />

                                                                            <asp:BoundField DataField="ValorSeleccionado" HeaderText="Cotizacion" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />
                                                                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                                            <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />

                                                                            <%-- <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />--%>

                                                                            <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                                                            <asp:BoundField DataField="Logistica" HeaderText="Logistica" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                                                            <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina" DataFormatString="{0:C0}" SortExpression="UsoCocina" />
                                                                            <asp:BoundField DataField="ValorIntermediario" HeaderText="Fee" DataFormatString="{0:C0}" SortExpression="ValorIntermediario" />
                                                                            <asp:BoundField DataField="ProveedorId" HeaderText="" SortExpression="ProveedorId" HeaderStyle-Width="0px" ItemStyle-Width="0px">
                                                                                <HeaderStyle Width="0px" />
                                                                                <ItemStyle Width="0px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="UnidadNegocioId" HeaderText="" SortExpression="UnidadNegocioId" HeaderStyle-Width="0px" ItemStyle-Width="0px">
                                                                                <HeaderStyle Width="0px" />
                                                                                <ItemStyle Width="0px" />
                                                                            </asp:BoundField>

                                                                            <asp:TemplateField HeaderStyle-Width="300px">
                                                                                <ItemTemplate>

                                                                                    <table style="width: 100%;">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="DropDownListPreciosItem" runat="server" CssClass="form-control" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" AppendDataBoundItems="true">
                                                                                                    <asp:ListItem Value="0">&lt;Precio&gt;</asp:ListItem>
                                                                                                    <asp:ListItem Value="1.05">PL + 5%</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">PL</asp:ListItem>
                                                                                                    <asp:ListItem Value="0.95">PL - 5%</asp:ListItem>
                                                                                                    <asp:ListItem Value="0.90">PL - 10%</asp:ListItem>
                                                                                                </asp:DropDownList></td>
                                                                                            <td>&nbsp;|&nbsp;
                                                                                                <asp:Button ID="ButtonCambiarPrecio" runat="server" Text="Cambiar" class="btn btn-warning" CommandName="CargarPrecios" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>

                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="300px" />
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="ButtonPresupuestarAdicionales" runat="server" Text="Cargar Adicionales" class="btn btn-info" CommandName="CargarAdicionales" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="ButtonQuitarItem" runat="server" Text="Quitar" class="btn btn-danger" CommandName="QuitarItem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>

                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>Total Presupuestado:<asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>PAX<asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="LabelRentaPorcentaje" runat="server" Text="% Rentabilidad Evento"></asp:Label>
                                                                <asp:TextBox ID="TextBoxRentaPorcentaje" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LabelRentaValor" runat="server" Text="$ Rentabilidad Evento"></asp:Label>
                                                                <asp:TextBox ID="TextBoxRentaValor" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="LabelRoyalty" runat="server" Text="Royalty"></asp:Label>
                                                                <asp:TextBox ID="TextBoxRoyalty" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>

                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Panel ID="PanelAdicionales" runat="server">
                                                                    <div class="panel-heading">
                                                                        <h3>Adicionales</h3>
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
                                                                                    <asp:DropDownList ID="DropDownListAdicionales" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="DropDownListAdicionales_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="0">&lt;Seleccionar un Producto&gt;</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>&nbsp;&nbsp;<asp:Button ID="ButtonAgregarAdicional" runat="server" class="btn btn-success" OnClick="ButtonAgregarAdicional_Click" Text="Agregar Adicional" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="LabelCantidadAdicional" runat="server" Text="Cantidad:"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" class="form-control"></asp:TextBox>
                                                                                </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:Label ID="LabelMensajeAdicionales" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Panel ID="PanelOrganizador" runat="server">
                                                                    <div class="panel-heading">
                                                                        <h3>Organizador</h3>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>Porcentaje Organizador:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="TextBoxPorcentajeOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" Width="100px"></asp:TextBox></td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Importe Organizador:</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="TextBoxImporteOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" Width="100px"></asp:TextBox>
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
                                                                                    <asp:Button ID="ButtonCalcularOrganizador" runat="server" class="btn btn-success" OnClick="ButtonCalcularOrganizador_Click" Text="Calcular" />&nbsp;|&nbsp;
                                                                                    <asp:Button ID="ButtonQuitarOrganizador" runat="server" class="btn btn-danger" Text="Quitar Organizador" OnClick="ButtonQuitarOrganizador_Click" />
                                                                                </td>
                                                                                <td>Total Organizador:<asp:TextBox ID="TextBoxTotalPorcOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:UpdatePanel ID="UpdatePanelComentario" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <h3>Comentario</h3>
                                                                        <asp:Panel ID="PanelComentario" runat="server" GroupingText="">

                                                                            <div class="panel panel-footer">
                                                                                <asp:TextBox ID="TextBoxComentarioEvento" runat="server" TextMode="MultiLine" class="form-control" Height="166px" MaxLength="2000" Width="100%"></asp:TextBox>

                                                                            </div>

                                                                        </asp:Panel>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonGuardar" runat="server" class="btn btn-info" OnClick="ButtonGuardar_Click" Text="Guardar Presupuesto" />&nbsp;|&nbsp;
                                                                <asp:Button ID="ButtonConfirmar" runat="server" class="btn btn-primary" Text="Confirmar Presupuesto" OnClick="ButtonConfirmar_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" /></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="PanelVisorPDF" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <iframe height="780px" src="PresupuestoCliente.ashx" width="100%"></iframe>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <iframe height="780px" src="CateringExperiencias.ashx" width="100%"></iframe>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="3">
                                        <iframe src="/RepExperiencias.aspx" style="width: 100%; height: 780px" width="100%"></iframe>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Panel ID="PanelNuevoEventoConfirmado" runat="server">
                                            <iframe id="Iframe1" src="PipeDrivePost.ashx" width="1px" height="1px"></iframe>
                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <div class="panel-footer">
                                            &nbsp;
                                    <asp:Button ID="ButtonSalir" runat="server" class="btn btn-primary" OnClick="ButtonSalir_Click" Text="Salir" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                        <asp:Panel ID="PanelMensaje" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Label ID="LabelMensaje" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#00cc00"></asp:Label></td>

                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonOk" runat="server" class="btn btn-primary" OnClick="ButtonOk_Click" Text="Ok!!!" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Panel ID="PanelNuevoNegocio" runat="server">
                                            <iframe id="PipeDrive" src="PipeDrivePost.ashx" width="1px" height="1px"></iframe>
                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                        </asp:Panel>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
