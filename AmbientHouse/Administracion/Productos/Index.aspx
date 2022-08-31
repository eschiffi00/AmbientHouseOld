<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Productos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .accordion {
            width: 200px;
        }

        .accordionHeader {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #2E4d7B;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionHeaderSelected {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionContent {
            background-color: #D3DEEF;
            border: 1px dashed #2F4F4F;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
        }
    </style>

  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Productos</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Productos" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <ajaxToolkit:Accordion
                            ID="MyAccordion"
                            runat="Server"
                            SelectedIndex="0"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordion"
                            AutoSize="None"
                            FadeTransitions="true"
                            TransitionDuration="250"
                            FramesPerSecond="40"
                            RequireOpenedPane="false"
                            SuppressHeaderPostbacks="true" Width="100%" Height="379px">


                            <Panes>
                                <ajaxToolkit:AccordionPane runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent">
                                    <Header>
                                        <h3>Filtros</h3>
                                    </Header>
                                    <Content>
                                        <asp:UpdatePanel ID="UpdatePanelFiltros" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                            <h3>Unidad de Negocio:</h3>
                                                            <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocio_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="LabelTipoCatering" runat="server" Text="Experiencia de Catering:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListTipoCatering" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Tipo Catering&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelAdicional" runat="server" Text="Adicional:"></asp:Label>

                                                         
                                                                   <asp:DropDownList ID="DropDownListAdicional" AppendDataBoundItems="True" class="form-control" AutoPostBack="True" runat="server"  OnSelectedIndexChanged="DropDownListAdicional_SelectedIndexChanged" >
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Adicional&gt;</asp:ListItem>
                                                                </asp:DropDownList>

                                                                <asp:Label ID="LabelOrganizacion" runat="server" Text="Items Organizacion:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListOrganizacion" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Item de Organizacion&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelCantidadPersonas" runat="server" Text="Cantidad de Personas:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListCantidadPersonas" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione la Cantidad Invitados&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelLocacion" runat="server" Text="Locaciones:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListLocacion" runat="server" AppendDataBoundItems="True" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocacion_SelectedIndexChanged">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Locacion&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelSector" runat="server" Text="Sectores:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListSector" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Sector&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelJornada" runat="server" Text="Jornadas:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListJornada" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Jornada&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelTipoServicio" runat="server" Text="Servicio:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListTipoServicio" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Tipo Servicio&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelSegmento" runat="server" Text="Segmento:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListSegmento" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Segmento&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelCaracteristica" runat="server" Text="Caracteristica:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListCaracteristica" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Caracteristica&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelBarra" runat="server" Text="Tipo Barra:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListTipoBarra" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Tipo Barra&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelCategorias" runat="server" Text="Packs:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListCategorias" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Categoria&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelProveedores" runat="server" Text="Proveedores:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListProveedores" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Proveedor&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelAnio" runat="server" Text="Anio:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListAnio" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Anio&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelMes" runat="server" Text="Mes:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListMes" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Mes&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelSemestre" runat="server" Text="Semestre:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListSemestre" runat="server" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Semestre&gt;</asp:ListItem>
                                                                    <asp:ListItem Value="1">Primer Semestre</asp:ListItem>
                                                                    <asp:ListItem Value="2">Segundo Semestre</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelDia" runat="server" Text="Dia:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListDia" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Dia&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="LabelEstados" runat="server" Text="Estado:"></asp:Label>
                                                                <asp:DropDownList ID="DropDownListEstados" runat="server" class="form-control">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <asp:Button ID="ButtonInactivar" runat="server" class="btn btn-default" Text="Inactivar Seleccion" OnClick="ButtonInactivar_Click" />

                                                                <asp:Button ID="ButtonActivar" runat="server" class="btn btn-danger" Text="Activar Seleccion" OnClick="ButtonActivar_Click" />
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
                                                                <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-primary" OnClick="ButtonBuscar_Click" Text="Buscar" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
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
                                                </table>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </Content>

                                </ajaxToolkit:AccordionPane>

                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent">
                                    <Header>
                                        <h3>Actualizacion de Precios/Costos</h3>
                                    </Header>
                                    <Content>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RadioButton ID="RadioButtonValor" runat="server" Text="Valor Absoluto" GroupName="1" Checked="true" />
                                                    <asp:RadioButton ID="RadioButtonPorcentaje" runat="server" Text="Porcentaje" GroupName="1" /></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Costo</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxCosto" runat="server" class="form-control"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Margen (SIEMPRE ES PORCENTAJE)</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxMargen" runat="server" class="form-control"></asp:TextBox>

                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Precio</td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control"></asp:TextBox>

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

                                                    <asp:Button ID="ButtonActualizar" runat="server" class="btn btn-primary" Text="Actualizar" OnClick="ButtonActualizar_Click" />

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>

                                    </Content>
                                </ajaxToolkit:AccordionPane>

                            </Panes>

                        </ajaxToolkit:Accordion>
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
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdateProgress ID="UpdateProgressGrilla" runat="server">
                            <ProgressTemplate>
                                <div style="text-align: center">
                                    <img src="../../Content/Imagenes/loading.gif" style="text-align: center" />
                                </div>
                            </ProgressTemplate>

                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanelGrillaProductos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewProductos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="GridViewProductos_PageIndexChanging" PageSize="200" OnRowDataBound="GridViewProductos_RowDataBound" OnRowCommand="GridViewProductos_RowCommand">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Productos con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="Unidad de Negocio" SortExpression="UnidadNegocioDescripcion" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Costo $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Margen %" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxMargen" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Precio $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Estado" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Fecha Item" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimiento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Productos/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
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

        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
