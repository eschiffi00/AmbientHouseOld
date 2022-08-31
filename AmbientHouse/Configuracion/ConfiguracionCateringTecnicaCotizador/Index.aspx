<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.ConfiguracionCateringTecnicaCotizador.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Configuracion Catering/Tecnica para el Cotizador</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Configuracion Catering/Tecnica" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                        &nbsp;|&nbsp;
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
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

                        <div class="panel panel-primary">
                            <div class="panel-heading">Buscador (Configuracion/Eventos) </div>

                            <div class="panel-body">

                                <table style="width: 100%;">
                                    <tr>
                                        <td>Segmento:</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListSegmento" runat="server" AppendDataBoundItems="True" class="form-control">
                                                <asp:ListItem Value="null">&lt;Seleccione Segmento&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                       <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Caracteristica:</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCaracteristica" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                 <asp:ListItem Value="null">&lt;Seleccione Caracteristica&gt;</asp:ListItem>
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
                                        <td>Momento del Dia:</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListMomentoDelDia" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                 <asp:ListItem Value="null">&lt;Seleccione Momento del Dia&gt;</asp:ListItem>
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
                                        <td>Duracion:</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListDuracion" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                 <asp:ListItem Value="null">&lt;Seleccione Duracion&gt;</asp:ListItem>
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
                                        <td>&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </td>
                    <td>&nbsp;</td>

                </tr>


                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaConfigCateringTecnica" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <p>
                                    <asp:Button ID="ButtonSeleccionarTodos" class="btn btn-default" runat="server" Text="Seleccionar Todos" OnClick="ButtonSeleccionarTodos_Click" />&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonActivarSeleccionados" class="btn btn-success" runat="server" Text="Activar Seleccionados" OnClick="ButtonActivarSeleccionados_Click" />&nbsp;|&nbsp;
                                <asp:Button ID="ButtonDesactivarSeleccionados" class="btn btn-danger" runat="server" Text="Desactivar Seleccionados" OnClick="ButtonDesactivarSeleccionados_Click" />
                                </p>
                                <asp:GridView ID="GridViewConfigCateringTecnica" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxSeleccionar" runat="server" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SegmentoId" HeaderText="Seg. Id" SortExpression="SegmentoId" />
                                        <asp:BoundField DataField="SegmentoDescripcion" HeaderText="Seg. Descripcion" SortExpression="SegmentoDescripcion" />
                                        <asp:BoundField DataField="CaracteristicaId" HeaderText="Caract. Id" SortExpression="CaracteristicaId" />
                                        <asp:BoundField DataField="CaracteristicaDescripcion" HeaderText="Caract. Descripcion" SortExpression="CaracteristicaDescripcion" />
                                        <asp:BoundField DataField="MomentoDiaId" HeaderText="Momento Dia Id" SortExpression="MomentoDiaId" />
                                        <asp:BoundField DataField="MomentodelDiaDescripcion" HeaderText="Momento del Dia" SortExpression="MomentodelDiaDescripcion" />
                                        <asp:BoundField DataField="DuracionId" HeaderText="Duracion Id" SortExpression="DuracionId" />
                                        <asp:BoundField DataField="DuracionDescripcion" HeaderText="Duracion" SortExpression="DuracionDescripcion" />
                                        <asp:BoundField DataField="TipoCateringId" HeaderText="Tipo Catering Id" SortExpression="TipoCateringId" />
                                        <asp:BoundField DataField="TipoCateringDescripcion" HeaderText="Tip. Cat. Descripcion" SortExpression="TipoCateringDescripcion" />
                                        <asp:BoundField DataField="TipoServicioId" HeaderText="Tipo Servicio Id" SortExpression="TipoServicioId" />
                                        <asp:BoundField DataField="TipoServicioDescripcion" HeaderText="Tip. Serv. Descripcion" SortExpression="TipoServicioDescripcion" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelEstado" runat="server" Text='<%# EvaluarEstado(Eval("EstadoId")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ButtonBuscar" EventName="Click" />
                            </Triggers>

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
