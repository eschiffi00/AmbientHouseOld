<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Productos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Agregar/Editar Productos
                    </div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelProductos" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Descripcion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <h3>Unidad de Negocio:</h3>
                                        </td>
                                        <td>

                                            <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocio_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                                                <asp:ListItem Value="null">&lt;Seleccione una Unidad de Negocio&gt;</asp:ListItem>
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
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LabelTipoCatering" runat="server" Text="Experiencia de Catering:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListTipoCatering" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListTipoCatering_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelAdicionales" runat="server" Text="Adicionales:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListAdicional" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAdicional_SelectedIndexChanged">
                                            </asp:DropDownList>

                                            <asp:Label ID="LabelLocacion" runat="server" Text="Locaciones:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListLocacion" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocacion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelSector" runat="server" Text="Sectores:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListSector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSector_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelJornada" runat="server" Text="Jornadas:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListJornada" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListJornada_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelTipoServicio" runat="server" Text="Servicio:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListTipoServicio" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListTipoServicio_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelSegmento" runat="server" Text="Segmento:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListSegmento" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSegmento_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelCaracteristica" runat="server" Text="Caracteristica:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListCaracteristica" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListCaracteristica_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelBarra" runat="server" Text="Tipo Barra:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListTipoBarra" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListTipoBarra_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelCategorias" runat="server" Text="Packs:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListCategorias" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListCategorias_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelProveedores" runat="server" Text="Proveedores:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProveedores_SelectedIndexChanged">
                                            </asp:DropDownList>

                                            <asp:Label ID="LabelAnio" runat="server" Text="Anio:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListAnio" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAnio_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelMes" runat="server" Text="Mes:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListMes" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMes_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelDia" runat="server" Text="Dias:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListDias" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListDias_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelSemestre" runat="server" Text="Semestre:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListSemestre" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSemestre_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Primer Semestre</asp:ListItem>
                                                <asp:ListItem Value="2">Segundo Semestre</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:Label ID="LabelOrganizacion" runat="server" Text="Items Organizacion:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListItemsOrganizacion" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListItemsOrganizacion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="LabelCantidadPersonas" runat="server" Text="Cantidad de Personas:"></asp:Label>
                                            <asp:DropDownList ID="DropDownListCantidadPersonas" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListCantidadPersonas_SelectedIndexChanged">
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
                                        <td>
                                            <h3>Codigo Item:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCodigo" runat="server" class="form-control" ReadOnly="True" Width="300px"></asp:TextBox>
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
                                        <td>
                                            <h3>Precio:</h3>
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="DetalleRequiredPrecio" runat="server" ControlToValidate="TextBoxPrecio" Display="Dynamic" ErrorMessage="Precio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
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
                                        <td>
                                            <h3>Costo:</h3>
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;$&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxCosto" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="DetalleRequiredCosto" runat="server" ControlToValidate="TextBoxCosto" Display="Dynamic" ErrorMessage="Costo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
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
                                        <td>
                                            <h3>Royalty:</h3>
                                        </td>
                                        <td>
                                            <div class="float-left">&nbsp;%&nbsp;</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="TextBoxRoyalty" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoyalty" runat="server" ControlToValidate="TextBoxRoyalty" Display="Dynamic" ErrorMessage="Royalty es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
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
                                        <td>
                                            <h3>Fecha Vencimiento:</h3>
                                        </td>
                                        <td>

                                            <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimiento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimiento" TodaysDateFormat="" />

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
                                        <td>
                                            <h3>Perfil:</h3>
                                        </td>
                                        <td>

                                            <asp:DropDownList ID="DropDownListPerfil" runat="server" class="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="null">&lt;Seleccione un Perfil&gt;</asp:ListItem>
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
                                        <td colspan="4">
                                            <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
