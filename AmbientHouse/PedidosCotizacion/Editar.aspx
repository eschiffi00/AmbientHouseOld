<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.PedidosCotizacion.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }

        .auto-style2 {
            height: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                        Agregar/Editar Productos
                    </div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelProductos" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <h3>Unidad de Negocio:</h3>
                                        </td>
                                        <td>

                                            <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocio_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" Width="100%">
                                                <asp:ListItem Value="null">&lt;Seleccione una Unidad de Negocio&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                    </tr>

                                </table>
                                <asp:Panel ID="PanelLocacion" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Locaciones
                                        </div>
                                        <div class="panel-body">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Localidad:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListLocalidades" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="DropDownListLocalidades_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxTieneVerde" runat="server" Text="Tiene Verde" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxEstacionamiento" runat="server" Text="Estacionamiento" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"></td>
                                                    <td class="auto-style1"></td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxAireLibre" runat="server" Text="Aire Libre" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar Locaciones" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonBuscar_Click" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabelLocaciones" runat="server" Text="Locaciones:"></asp:Label></td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListLocaciones" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListLocaciones_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabelSectores" runat="server" Text="Sectores:"></asp:Label></td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListSectores" runat="server" class="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabelOtraLocacion" runat="server" Text="Otras Locaciones:"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxOtrasLocaciones" runat="server" class="form-control" Width="700px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabelOtroSector" runat="server" Text="Otras Sector:"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxOtroSector" runat="server" class="form-control" Width="700px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Fecha Evento:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server" AutoPostBack="True" class="form-control" Width="700px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesdeEvento" TodaysDateFormat="" CssClass="black" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Jornadas:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListJornadas" runat="server" class="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Cantidad Invitados:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxCantidadInvitados" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="PanelTecnica" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Tecnica
                                        </div>
                                        <div class="panel-body">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Locaciones:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListLocacionTecnica" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="DropDownListLocacionTecnica_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Sectores:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListSectorTecnica" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Fecha Evento:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxFechaEventoTecnica" runat="server" AutoPostBack="True" class="form-control" Width="700px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEventoTecnica" TodaysDateFormat="" CssClass="black" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Segmento:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListSegmentoTecnica" runat="server" class="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Tipo de Servicio:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListTipoServicioTecnica" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Cantidad Invitados:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxCantidadInvitadosTecnica" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                                    </td>

                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="PanelAmbientacion" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Ambientacion
                                        </div>
                                        <div class="panel-body">

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Locaciones:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListLocacionAmbientacion" runat="server" AutoPostBack="True" class="form-control" Width="100%" OnSelectedIndexChanged="DropDownListLocacionAmbientacion_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Sectores:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListSectorAmbientacion" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Segmento:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListSegmentosAmbientacion" runat="server" class="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Caracteristicas:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownListCaracteristicasAmbientacion" runat="server" class="form-control" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>

                                                </tr>
                                                <tr>
                                                    <td>Paquete:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxPaqueteAmbientacion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                    </td>

                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelCostos" runat="server">
                                    <table style="width: 100%;">
                                        <tr>

                                            <td>
                                                <h3>Costo:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" Width="200px" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCosto" runat="server" ControlToValidate="TextBoxCosto" Display="Dynamic" ErrorMessage="El Costo es requerido para generar el item." Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Productos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>


                                        </tr>
                                        <tr>

                                            <td>
                                                <h3>Margen:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxMargen" runat="server" Width="200px" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMargen" runat="server" ControlToValidate="TextBoxMargen" Display="Dynamic" ErrorMessage="El Margen es requerido para generar el item." Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Productos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>


                                        </tr>
                                        <tr>
                                            <td>Proveedores:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control" Width="100%" AppendDataBoundItems="true">
                                                      <asp:ListItem Value="null">&lt;Seleccione un Proveedor&gt;</asp:ListItem>
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
                                                <asp:Button ID="ButtonGenerarItem" runat="server" Text="Generar Item" ValidationGroup="Productos" class="btn btn-danger" OnClick="ButtonGenerarItem_Click" /></td>


                                        </tr>
                                    </table>
                                </asp:Panel>
                                <table style="width: 100%;">
                                    <tr>

                                        <td>
                                            <h3>Comentario:</h3>
                                        </td>

                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:TextBox ID="TextBoxComentario" runat="server" MaxLength="3000" TextMode="MultiLine" Height="300px" Width="100%" class="form-control"></asp:TextBox>
                                        </td>

                                    </tr>

                                </table>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
