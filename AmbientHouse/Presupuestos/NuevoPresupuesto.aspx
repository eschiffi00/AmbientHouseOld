<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="NuevoPresupuesto.aspx.cs" Inherits="AmbientHouse.Presupuestos.NuevoPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 36px;
        }

        .auto-style4 {
            height: 20px;
        }

        .auto-style5 {
            width: 559px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table style="width: 100%;">
        <tr>
            <td></td>
        </tr>
        <tr>

            <td>
                <asp:UpdatePanel ID="UpdatePanelCabecera" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="PanelCabecera" runat="server" Height="100%">

                            <div class="panel panel-primary">
                                <div class="panel-heading"></div>
                                <div class="panel-body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <th>Cliente:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraCliente" runat="server" Text=""></asp:Label>
                                            </td>
                                            <th>Nro. Presupuesto:
                                            </th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraNroPresupuesto" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th>Nro. Evento:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraNroEvento" runat="server" Text=""></asp:Label></td>
                                            <th>Cant. Invitados:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraCantInvitados" runat="server" Text=""></asp:Label>
                                            </td>
                                            <th>Cant. entre 3 y 8:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraCantInvitadosentre3y8" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Fecha Evento:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraFechaEvento" runat="server" Text=""></asp:Label></td>
                                            <th>Cant. Adolecentes:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraCantInvitadosAdolecentes" runat="server"></asp:Label>
                                            </td>
                                            <th>Cant. menores de 3:</th>
                                            <td>
                                                <asp:Label ID="LabelCabeceraCantInvitadosmenores3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <th>Comentario Asignacion:</th>
                                            <td colspan="3" rowspan="2">
                                                <asp:TextBox ID="TextBoxCabeceraComentarioEvento" runat="server" class="form-control" Height="60px" MaxLength="2000" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <h3>Valor Total:</h3>
                                            </th>
                                            <td>
                                                <h3>
                                                    <asp:Label ID="LabelCabeceraValorTotal" runat="server" Text=""></asp:Label></h3>
                                            </td>
                                            <th>
                                                <h3>Precio por Persona (PAX):</h3>
                                            </th>
                                            <td>
                                                <h3>
                                                    <asp:Label ID="LabelCabeceraPrecioPAX" runat="server" Text=""></asp:Label></h3>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;<asp:Button ID="ButtonGuardar" runat="server" class="btn btn-primary" Text="Guardar" OnClick="ButtonGuardar_Click" />
                &nbsp;|&nbsp;<asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="ButtonCancelar_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanelErrores" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                Errores
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="PanelErrores" runat="server">
                                    <table style="width: 100%;">

                                        <tr>

                                            <td colspan="2">

                                                <asp:GridView ID="GridViewError" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#ffffcc" />
                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                    <Columns>

                                                        <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" SortExpression="Mensaje" />


                                                    </Columns>

                                                </asp:GridView>
                                            </td>

                                        </tr>

                                    </table>
                                </asp:Panel>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PanelClientes" runat="server">

                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Buscador</div>
                                    <div class="panel-body">
                                        <asp:Panel ID="Panel2" runat="server">
                                            <asp:UpdatePanel ID="UpdatePanelClientes" runat="server" UpdateMode="Conditional">

                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelBuscarCliente" runat="server">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Nro. de Cliente:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxNroClienteBuscador" runat="server" Width="450px" class="form-control"></asp:TextBox>
                                                                </td>
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
                                                                <td>Razon Social:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxRazonSocialBuscador" runat="server" Width="450px" class="form-control"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="DropDownListClientes" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListClientes_SelectedIndexChanged">
                                                                            </asp:DropDownList></th>
                                                                        <td>&nbsp;</td>
                                                                    </tr>

                                                                </table>

                                                            </div>
                                                        </div>
                                                    </asp:Panel>

                                                    <asp:Panel ID="PanelNuevoCliente" runat="server">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading">Nuevo Cliente</div>
                                                            <div class="panel-body">
                                                                <table style="width: 100%;">

                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <th>
                                                                            <asp:Label ID="LabelApellido" runat="server" Text="Nombre y Apellido"></asp:Label>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxApellido" runat="server" class="form-control" MaxLength="100"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="ApellidoRequired" runat="server" ControlToValidate="TextBoxApellido"
                                                                                Display="Dynamic" ErrorMessage="Apellido es requerido." SetFocusOnError="True" ValidationGroup="Cliente" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:Label ID="LabelApellido0" runat="server" Text="Razon Social"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" MaxLength="200"></asp:TextBox>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <th>
                                                                            <asp:Label ID="LabelMail" runat="server" Text="Correo "></asp:Label>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxMail" runat="server" class="form-control" Width="500px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="CorreoRequired" runat="server" ControlToValidate="TextBoxMail" Display="Dynamic" ErrorMessage="Correo es requerido." SetFocusOnError="True" ValidationGroup="Cliente" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <th>
                                                                            <asp:Label ID="LabelCelular" runat="server" Text="Telefono"></asp:Label>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBoxCelular" runat="server" class="form-control" Width="300px" MaxLength="50"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="TelefonoRequired" runat="server" ControlToValidate="TextBoxCelular" Display="Dynamic" ErrorMessage="Telefono Requerido" SetFocusOnError="True" ValidationGroup="Cliente" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="auto-style2">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style2">&nbsp;</td>
                                                                        <td class="auto-style2">&nbsp;</td>
                                                                        <td class="auto-style2">&nbsp;</td>
                                                                        <td class="auto-style2">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:Label ID="LabelComoLlego" runat="server" Text="Como Llego?"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownListComoLlego" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListComoLlego_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>

                                                                            <asp:Label ID="Label1" runat="server" Text="Otro:"></asp:Label>
                                                                            <asp:TextBox ID="TextBoxOtro" runat="server" Width="300px" class="form-control" MaxLength="50"></asp:TextBox>


                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:Label ID="LabelTipoCliente" runat="server" Text="Tipo Cliente"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownListTipoCliente" runat="server" AutoPostBack="True" class="form-control">
                                                                                <asp:ListItem Value="S">Social</asp:ListItem>
                                                                                <asp:ListItem Value="C">Corporativo</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>&nbsp;</td>
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
                                                                            <asp:Button ID="ButtonClienteGrabar" runat="server" class="btn btn-success" OnClick="ButtonClienteGrabar_Click" Text="Grabar Nuevo Cliente" ValidationGroup="Cliente" />
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>

                                                </ContentTemplate>

                                            </asp:UpdatePanel>

                                        </asp:Panel>




                                    </div>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>

                                <div class="panel panel-primary">
                                    <div class="panel-heading">Definir Cantidad de Invitados</div>
                                    <div class="panel-body">

                                        <asp:Panel ID="PanelInvitados" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <th class="auto-style6">Cant. de Mayores:</th>
                                                    <td class="auto-style6">
                                                        <asp:TextBox ID="TextBoxCantMayores" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style6">Cant. de Adolescentes:</td>
                                                    <td class="auto-style6"></td>
                                                    <td class="auto-style6">
                                                        <asp:TextBox ID="TextBoxCantAdolescentes" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Cant. Menores de 3 años:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxCantMenores3" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td>Cant. entre 3 y 8 años:</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxCantEntre3y8" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Fechas del Evento</div>
                                    <div class="panel-body">
                                        <asp:UpdatePanel ID="UpdatePanelGrillaEventosReservadosConfirmados" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="PanelFechaEvento" runat="server" GroupingText="">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <th>Fecha Evento:</th>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server" class="form-control" Width="700px" OnTextChanged="TextBoxFechaDesdeEvento_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" TargetControlID="TextBoxFechaDesdeEvento" Format="dd/MM/yyyy" DefaultView="Years" TodaysDateFormat="" />
                                                            </td>

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

                                                                <asp:GridView ID="GridViewEventosReservadosConfirmados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="GridViewEventosReservadosConfirmados_PageIndexChanging">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Eventos Confirmados/Reservados con la fecha seleccionada!  
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
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Comentario Evento y Asignacion de Ejecutivo</div>
                                    <div class="panel-body">
                                        <asp:UpdatePanel ID="UpdatePanelComentario" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel1" runat="server" GroupingText="">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBoxAsignarOtroEjecutivo" runat="server" Text="Asignar a otro Ejecutivo" OnCheckedChanged="CheckBoxAsignarOtroEjecutivo_CheckedChanged" AutoPostBack="True" />
                                                            </td>
                                                            <td>

                                                                <asp:DropDownList ID="DropDownListOtroEjecutivo" runat="server" class="form-control">
                                                                </asp:DropDownList>

                                                            </td>

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
                                                            <td>Comentario:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxComentarioEvento" runat="server" TextMode="MultiLine" class="form-control" Height="166px" MaxLength="2000" Width="700px"></asp:TextBox>
                                                            </td>
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
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonClienteAsignarOtroEjecutivo" runat="server" class="btn btn-info" Text="Asignar a Otro Ejecutivo!!!" OnClick="ButtonClienteAsignarOtroEjecutivo_Click" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <asp:Button ID="ButtonClienteSeleccionado" runat="server" class="btn btn-success" Text="Siguiente>>>" OnClick="ButtonClienteSeleccionado_Click" />
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


                </asp:Panel>
                <asp:Panel ID="PanelCotizador" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCotizadorSalones" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">Definir Tipo de Evento</div>
                                            <div class="panel-body">
                                                <asp:Panel ID="PanelTipoEventos" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Tipo de Evento:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTipoEvento" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoEvento_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:UpdatePanel ID="UpdatePanelTipoEventoOtro" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="TextBoxOtroTipoEvento" class="form-control" runat="server" Width="100%"></asp:TextBox>
                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>Jornada:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListJornadas" runat="server" AutoPostBack="True" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Locaciones:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListLocaciones" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocaciones_SelectedIndexChanged">
                                                                </asp:DropDownList>

                                                                <asp:UpdatePanel ID="UpdatePanelLocacionOtro" runat="server" UpdateMode="Conditional">

                                                                    <ContentTemplate>

                                                                        <asp:TextBox ID="TextBoxOtroLocacion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>

                                                            </td>
                                                            <td>&nbsp;</td>
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
                                                        <tr>
                                                            <td>Caracteristicas:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCaracteristicas" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCaracteristicas_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Duracion Evento:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListDuracionEvento" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDuracionEvento_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                            <td>
                                                                <asp:Label ID="LabelSector" runat="server" Text="Sector:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanelSector" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DropDownListSectores" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSectores_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>

                                                            </td>
                                                            <td>&nbsp;</td>
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
                                                        <tr>
                                                            <td>Segmentos:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListSegmentos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListSegmentos_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Momento del Dia:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListMomentodelDia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListMomentodelDia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;</td>
                                                            <td></td>
                                                            <td>

                                                                <asp:Button ID="ButtonCotizadorSalones" runat="server" class="btn btn-default" OnClick="ButtonCotizarSalon_Click" Text=" Cotizar Salon" />&nbsp;&nbsp;
                                                                <asp:Button ID="ButtonNoCotizadorSalones" runat="server" class="btn btn-danger" OnClick="ButtonNoCotizadorSalones_Click" Text=" No Cotizar Salon" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="panel-footer">


                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>Seleccionar tipo de Precio:<asp:DropDownList ID="DropDownListPreciosSalon" class="form-control" runat="server" Width="150px" OnSelectedIndexChanged="DropDownListPreciosSalon_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                        <td>Precio:<asp:TextBox ID="TextBoxPrecioSeleccionadoSalon" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Salon:<asp:TextBox ID="TextBoxCotizacionSalon" runat="server" class="form-control" Width="100px" AutoPostBack="True" OnTextChanged="TextBoxCotizacionSalon_TextChanged"></asp:TextBox></td>
                                                        <td class="auto-style5">Comision:<asp:TextBox ID="TextBoxComisionSalon" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LabelDescuentosSalon" runat="server" Text="Descuento:"></asp:Label>
                                                            <asp:TextBox ID="TextBoxDescuentosSalon" runat="server" class="form-control" Width="100px" OnTextChanged="TextBoxDescuentosSalon_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                        </td>

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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCotizadorCatering" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-info">
                                            <div class="panel-heading">
                                                Cotizar Catering
                                        
                                       
                                            </div>
                                            <div class="panel-body">
                                                <asp:Panel ID="PanelCateringPropio" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Seleccione Proveedor:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListProveedorCatering" runat="server" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td></td>
                                                            <td>&nbsp;&nbsp;&nbsp; Experiencia:</td>
                                                            <td>

                                                                <asp:DropDownList ID="DropDownListExperiencias" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListExperiencias_SelectedIndexChanged">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
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
                                                            <td>Concepto:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListConceptoLogisticaCatering" runat="server" AutoPostBack="True" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp; Localidades:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListLocalidadesLogisitcaCatering" runat="server" class="form-control">
                                                                </asp:DropDownList></td>
                                                            <td>&nbsp;&nbsp; Cant. Invitados:&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCantInvitadosLogisitcaCatering" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListCantInvitadosLogisitcaCatering_SelectedIndexChanged">
                                                                    <asp:ListItem>50</asp:ListItem>
                                                                    <asp:ListItem>75</asp:ListItem>
                                                                    <asp:ListItem>100</asp:ListItem>
                                                                    <asp:ListItem>125</asp:ListItem>
                                                                    <asp:ListItem>150</asp:ListItem>
                                                                    <asp:ListItem>175</asp:ListItem>
                                                                    <asp:ListItem>200</asp:ListItem>
                                                                    <asp:ListItem>225</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;&nbsp; Costo Logistica;</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxLogisticaCatering" runat="server" class="form-control" Width="100px"></asp:TextBox>
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
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Costo Canon P/Persona:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCanonCatering" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td colspan="3">
                                                                <asp:Button ID="ButtonCotizadorCatering" runat="server" class="btn btn-default" OnClick="ButtonCotizadorCatering_Click" Text=" Cotizar Catering" />
                                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonNoCotizarCatering" runat="server" class="btn btn-danger" OnClick="ButtonNoCotizarCatering_Click" Text=" No Cotizar Catering" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                            </div>
                                            <div class="panel-footer">

                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>Seleccionar tipo de Precio:<asp:DropDownList ID="DropDownListPreciosCatering" class="form-control" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPreciosCatering_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                        <td>Precio:<asp:TextBox ID="TextBoxPrecioSeleccionadoCatering" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Catering:<asp:TextBox ID="TextBoxCotizacionCatering" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                                        <td>Comision:<asp:TextBox ID="TextBoxComisionCatering" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LabelDescuentoCatering" runat="server" Text="Descuento:"></asp:Label>
                                                            <asp:TextBox ID="TextBoxDescuentoCatering" runat="server" class="form-control" Width="100px" AutoPostBack="True" OnTextChanged="TextBoxDescuentoCatering_TextChanged"></asp:TextBox>
                                                        </td>

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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCostoTecnica" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Cotizar Tecnica</div>
                                            <div class="panel-body">

                                                <asp:Panel ID="PanelTecnica" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelSeleccionProveedor" runat="server" Text="Seleccione Proveedor:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListProveedorTecnica" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProveedorTecnica_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelProveedorTecnicaOtra" runat="server" Text="Otra Tecnica:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxProveedorOtraTecnica" runat="server" class="form-control"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Tipo de Servicio:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTipoServicio" runat="server" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonCotizadorTecnica" runat="server" class="btn btn-default" OnClick="ButtonCotizadorTecnica_Click" Text=" Cotizar Tecnica" />&nbsp;&nbsp;
                                                                <asp:Button ID="ButtonNoCotizarTecnica" runat="server" class="btn btn-danger" Text=" No Cotizar Tecnica" OnClick="ButtonNoCotizarTecnica_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="panel-footer">

                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>Seleccionar tipo de Precio:<asp:DropDownList ID="DropDownListPreciosTecnica" class="form-control" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPreciosTecnica_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                        <td>Precio<asp:TextBox ID="TextBoxPrecioSeleccionadoTecnica" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Tecnica:<asp:TextBox ID="TextBoxCotizacionTecnica" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                                        <td>&nbsp;</td>

                                                        <td>Comision:<asp:TextBox ID="TextBoxComisionTecnica" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="LabelDescuentoTecnica" runat="server" Text="Descuento:"></asp:Label>
                                                            <asp:TextBox ID="TextBoxDescuentoTecnica" runat="server" class="form-control" Width="100px" AutoPostBack="True" OnTextChanged="TextBoxDescuentoTecnica_TextChanged"></asp:TextBox></td>

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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCotizarBarras" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Cotizar Barras</div>
                                            <div class="panel-body">
                                                <asp:Panel ID="PanelBarras" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Seleccione Proveedor</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListProveedorBarra" class="form-control" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>Tipo de Barra:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTipoBarra" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListTipoBarra_SelectedIndexChanged">
                                                                </asp:DropDownList>
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
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concepto:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListConceptoLogisticaBarra" runat="server" AutoPostBack="True" class="form-control">
                                                                </asp:DropDownList>
                                                                &nbsp;</td>
                                                            <td>&nbsp;&nbsp;&nbsp; Localidades:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListLocalidadesLogisitcaBarra" runat="server" AutoPostBack="True" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;&nbsp; Cant. Invitados:&nbsp;&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCantInvitadosLogisitcaBarras" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListCantInvitadosLogisitcaBarras_SelectedIndexChanged">
                                                                    <asp:ListItem>50</asp:ListItem>
                                                                    <asp:ListItem>75</asp:ListItem>
                                                                    <asp:ListItem>100</asp:ListItem>
                                                                    <asp:ListItem>125</asp:ListItem>
                                                                    <asp:ListItem>150</asp:ListItem>
                                                                    <asp:ListItem>175</asp:ListItem>
                                                                    <asp:ListItem>200</asp:ListItem>
                                                                    <asp:ListItem>225</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp; Costo Logistica:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxLogisticaBarras" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Costo Canon P/Persona:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCanonBarras" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonCotizadorBarra" runat="server" class="btn btn-default" OnClick="ButtonCotizadorBarra_Click" Text="Cotizar Barra" />&nbsp;&nbsp;
                                                                <asp:Button ID="ButtonNoCotizarBarra" runat="server" class="btn btn-danger" Text=" No Cotizar Barra" OnClick="ButtonNoCotizarBarra_Click" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="panel-footer">


                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>Seleccionar tipo de Precio:<asp:DropDownList ID="DropDownListPreciosBarras" class="form-control" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPreciosBarras_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                        <td>Precio<asp:TextBox ID="TextBoxPrecioSeleccionadoBarra" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Barra:<asp:TextBox ID="TextBoxCotizacionBarras" runat="server" class="form-control" Width="100px" OnTextChanged="TextBoxCotizacionBarras_TextChanged"></asp:TextBox></td>
                                                        <td>Comision:<asp:TextBox ID="TextBoxComisionBarras" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="LabelDescuentoBarra" runat="server" Text="Descuento:"></asp:Label>
                                                            <asp:TextBox ID="TextBoxDescuentoBarra" runat="server" class="form-control" Width="100px" AutoPostBack="True" OnTextChanged="TextBoxDescuentoBarra_TextChanged"></asp:TextBox></td>

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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCotizadorAmbientacion" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Cotizar Ambientacion</div>
                                            <div class="panel-body">
                                                <asp:Panel ID="PanelAmbientacion" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Proveedor:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListProveedoresAmbientacion" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListProveedoresAmbientacion_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>Packs:</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCategoria" runat="server" class="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td colspan="2">&nbsp;</td>
                                                        </tr>
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
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonCotizadorAmbientacion" runat="server" class="btn btn-default" OnClick="ButtonCotizadorAmbientacion_Click" Text="Cotizar Ambientacion" />&nbsp;&nbsp;
                                                                <asp:Button ID="ButtonNoCotizarAmbientacion" runat="server" class="btn btn-danger" Text=" No Cotizar Ambientacion" OnClick="ButtonNoCotizarAmbientacion_Click" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="panel-footer">

                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>Seleccionar tipo de Precio:<asp:DropDownList ID="DropDownListPreciosAmbientacion" class="form-control" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPreciosAmbientacion_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                        <td>Precio
                                                            <asp:TextBox ID="TextBoxPrecioSeleccionadoAmbientacion" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Ambientacion:<asp:TextBox ID="TextBoxCotizacionAmbientacion" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                                        <td>Comision:<asp:TextBox ID="TextBoxComisionAmbientacion" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="LabelDescuentoAmbientacion" runat="server" Text="Descuento:"></asp:Label>
                                                            <asp:TextBox ID="TextBoxDescuentoAmbientacion" runat="server" class="form-control" Width="100px" AutoPostBack="True" OnTextChanged="TextBoxDescuentoAmbientacion_TextChanged"></asp:TextBox></td>

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
                                <asp:Panel ID="PanelAjuste" runat="server">
                                    <div class="panel panel-info">
                                        <div class="panel-heading">Ajuste</div>
                                        <div class="panel-body">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>Descripcion:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxAjusteDescripcion" runat="server" class="form-control" Width="400px"></asp:TextBox>
                                                    </td>
                                                    <td>Precio:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxAjustePrecio" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
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
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
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
                                <asp:UpdatePanel ID="UpdatePanelAdicionales" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Cotizar Adicionales</div>
                                            <div class="panel-body">
                                                <asp:Panel ID="PanelAdicionales" runat="server">
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
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4"></td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">
                                                                <asp:Button ID="ButtonAdicionalesSalon" runat="server" class="btn btn-default" OnClick="ButtonAdicionalesSalon_Click" Text="Salon" />
                                                                &nbsp;&nbsp;
                                                                <asp:Button ID="ButtonAdicionalesCatering" runat="server" class="btn btn-default" OnClick="ButtonAdicionalesCatering_Click" Text="Catering" />
                                                                &nbsp;&nbsp;
                                                                <asp:Button ID="ButtonAdicionalesTecnica" runat="server" Text="Tecnica" class="btn btn-default" OnClick="ButtonAdicionalesTecnica_Click" />
                                                                &nbsp;&nbsp;
                                                                <asp:Button ID="ButtonAdicionalesBarras" runat="server" class="btn btn-default" OnClick="ButtonAdicionalesBarras_Click" Text="Barra" />
                                                                &nbsp;&nbsp;
                                                                <asp:Button ID="ButtonAdicionalesAmbientacion" runat="server" class="btn btn-default" Text="Ambientacion" OnClick="ButtonAdicionalesAmbientacion_Click" />

                                                            </td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4"></td>
                                                            <td class="auto-style4"></td>
                                                            <td class="auto-style4"></td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4" colspan="8">

                                                                <asp:GridView ID="GridViewAdicionalesSalon" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" OnRowDataBound="GridViewAdicionalesSalon_RowDataBound" PageSize="25" Width="100%" Caption="Adicionales Salon">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Locaciones con los parametros seleccionados!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                        <asp:TemplateField HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBoxSeleccionAdicional" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="RequiereCantidad" HeaderStyle-Width="0px" ItemStyle-ForeColor="White">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemStyle ForeColor="White" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>


                                                                <asp:GridView ID="GridViewCatering" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" PageSize="25" Width="100%" OnRowDataBound="GridViewCatering_RowDataBound" Caption="Adicionales Catering">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Locaciones con los parametros seleccionados!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                        <asp:TemplateField HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBoxSeleccionAdicional" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="RequiereCantidad" HeaderStyle-Width="0px" ItemStyle-ForeColor="White">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemStyle ForeColor="White" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>

                                                                <asp:GridView ID="GridViewTecnica" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" PageSize="25" Width="100%" OnRowDataBound="GridViewTecnica_RowDataBound" Caption="Adicionales Tecnica">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Locaciones con los parametros seleccionados!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                        <asp:TemplateField HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBoxSeleccionAdicional" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="RequiereCantidad" HeaderStyle-Width="0px" ItemStyle-ForeColor="White">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemStyle ForeColor="White" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>

                                                                <asp:GridView ID="GridViewBarra" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" PageSize="25" Width="100%" OnRowDataBound="GridViewBarra_RowDataBound" Caption="Adcionales Barra">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Locaciones con los parametros seleccionados!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                        <asp:TemplateField HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBoxSeleccionAdicional" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="RequiereCantidad" HeaderStyle-Width="0px" ItemStyle-ForeColor="White">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemStyle ForeColor="White" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>

                                                                <asp:GridView ID="GridViewAmbientacion" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" PageSize="25" Width="100%" Caption="Adicionales Ambientacion" OnRowDataBound="GridViewAmbientacion_RowDataBound">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Locaciones con los parametros seleccionados!&nbsp;&nbsp;
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                        <asp:TemplateField HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBoxSeleccionAdicional" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" Visible="False" Width="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="RequiereCantidad" HeaderStyle-Width="0px" ItemStyle-ForeColor="White">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemStyle ForeColor="White" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonCotizarAdicionales" runat="server" class="btn btn-default" OnClick="ButtonCotizarAdicionales_Click" Text="Agregar Adicional" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="panel-footer">


                                                <table style="width: 100%;">

                                                    <tr>

                                                        <td>&nbsp;</td>
                                                        <td colspan="3">


                                                            <asp:GridView ID="GridViewAdicionalesSeleccionados" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" PageSize="25" Width="100%" Caption="Adicionales Presupuesto">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                <EditRowStyle BackColor="#ffffcc" />
                                                                <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                <EmptyDataTemplate>
                                                                    ¡No hay Adicionales cargados!&nbsp;&nbsp;
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:BoundField DataField="AdicionalId" HeaderText="Nro. Item" SortExpression="AdicionalId" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                    <asp:BoundField DataField="PrecioPresupuesto" HeaderText="Precio" SortExpression="PrecioPresupuesto" />
                                                                      <asp:BoundField DataField="Comision" HeaderText="Comision" SortExpression="Comision" />
                                                                    <asp:TemplateField HeaderStyle-Width="40px">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBoxQuitarSeleccionAdicional" runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="40px" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:Button ID="ButtonQuitarAdicional" runat="server" class="btn btn-danger" Text="Quitar Adicional" OnClick="ButtonQuitarAdicional_Click" />
                                                        </td>
                                                        <td>&nbsp;</td>

                                                        <td>&nbsp;</td>

                                                    </tr>

                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>Valor Adicionales:<asp:TextBox ID="TextBoxCotizacionAdicionales" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>Comision:<asp:TextBox ID="TextBoxComisionAdicional" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                        </td>
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
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Panel ID="PanelComentarioAlPresupuesto" runat="server">
                                    <div class="panel panel-info">
                                        <div class="panel-heading">Comentario al Presupuesto (El mismo es visualizado en el Presupuesto por el Cliente)</div>

                                        <div class="panel-body">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxComentarioPresupuesto" runat="server" class="form-control" Width="100%" Height="60px" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
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
                            <td>&nbsp;</td>
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
                                <asp:Panel ID="PanelBotonera" runat="server">
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
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>

                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
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
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <div class="panel-footer">

                                    <asp:Button ID="ButtonSiguienteCotizador" runat="server" class="btn btn-success" Text="Siguiente>>>" OnClick="ButtonSiguienteCotizador_Click" />

                                    <asp:Button ID="ButtonConfirmar" runat="server" class="btn btn-primary" OnClick="ButtonConfirmar_Click" Text="Confirmar" />

                                </div>
                                ;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </asp:Panel>
                <asp:Panel ID="PanelFinanciacion" runat="server">

                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
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
                                <div class="panel panel-info">
                                    <div class="panel-heading">Financiacion</div>
                                    <div class="panel-body">
                                        <asp:UpdatePanel ID="UpdatePanelSeleccionDePago" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="PanelSeleccionDePago" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Forma de Pago;</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFormadePago" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Entrega;</td>
                                                            <td>

                                                                <asp:TextBox ID="TextBoxEntrega" runat="server" class="form-control" Width="400px"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelCantidadCuotas" runat="server" Text="Cantidad de Cuotas;"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantidadCuotas" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonGenerarFinanciacion" runat="server" class="btn btn-default" OnClick="ButtonGenerarFinanciacion_Click" Text="Generar Financiacion" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <div class="panel-footer">
                                    <asp:Button ID="ButtonAnteriorFinanciacion" runat="server" class="btn btn-success" OnClick="ButtonAnteriorFinanciacion_Click" Text="&lt;&lt;&lt;Anterior" />
                                    &nbsp;
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
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
                            <td>&nbsp;</td>
                            <td>

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
            </td>
            <%--<td rowspan="3">
                <asp:Panel ID="PanelResumen" runat="server" Height="100%">

                    <div class="panel panel-primary">
                        <div class="panel-heading">Resumen</div>
                        <div class="panel-body">
                        </div>
                    </div>
                </asp:Panel>
            </td>--%>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>









</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
