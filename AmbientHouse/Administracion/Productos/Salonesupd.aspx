<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Salonesupd.aspx.cs" Inherits="AmbientHouse.Configuracion.Productos.Salonesupd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
    <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	    rel="stylesheet" type="text/css" />
        <script src="../../Scripts/MultiSelect.js" type="text/javascript"></script>
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
    <script>
        //$(document).ready(function () {
            //Sys.Application.add_load(function () {
        function pageLoad() {
            $('[id*=DropDownListCantidadPersonas]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });

            $('[id*=DropDownListSector]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListAnio]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListMes]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListDia]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });
        }
            //});
            
        //});
        function multiselectformat() {
            $('[id*=DropDownListCantidadPersonas]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });

            $('[id*=DropDownListSector]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListAnio]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListMes]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });


            $('[id*=DropDownListDia]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true
            });
            console.log("funciona");
        }

    </script>

  

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
                                                <table class="tabladatos" style="width:600px ; display: table-caption; ">
                                                    <tr>
                                                        <td></td>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="LabelCantidadPersonas" runat="server" Text="Cantidad de Personas:"></asp:Label>
                                                                <div>
                                                                    
                                                                    <asp:ListBox ID="DropDownListCantidadPersonas" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelLocacion" runat="server" Text="Locaciones:"></asp:Label>
                                                                    <asp:DropDownList ID="DropDownListLocacion" runat="server" AppendDataBoundItems="True" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocacion_SelectedIndexChanged">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Locacion&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelSector" runat="server" Text="Sectores:"></asp:Label>
                                                                    <asp:ListBox ID="DropDownListSector" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelJornada" runat="server" Text="Jornadas:"></asp:Label>
                                                                    <asp:DropDownList ID="DropDownListJornada" runat="server" AppendDataBoundItems="True" class="form-control">
                                                                    <asp:ListItem Value="null">&lt;Seleccione una Jornada&gt;</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelAnio" runat="server" Text="Anio:"></asp:Label>
                                                                    <asp:ListBox ID="DropDownListAnio" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelMes" runat="server" Text="Mes:"></asp:Label>  
                                                                    <asp:ListBox ID="DropDownListMes" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelDia" runat="server" Text="Dia: "></asp:Label>
                                                                    <asp:ListBox ID="DropDownListDia" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="LabelEstados" runat="server" Text="Estado:"></asp:Label>
                                                                    <asp:DropDownList ID="DropDownListEstados" runat="server" class="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
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
