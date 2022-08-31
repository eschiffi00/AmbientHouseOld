<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.ConfiguracionCateringTecnicaCotizador.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Configurar Catering/Tecnica Cotizador<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Segmento:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSegmentos" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Caracteristica:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCaracteristicas" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Momento del Dia:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListMomentosdeDia" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Duracion Evento:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListDuracionEvento" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Tipo Catering:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoCatering" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Tipo Servicio:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoServicio" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregar_Click" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitar_Click" />
                                     &nbsp;&nbsp;<asp:Label ID="LabelMensaje" runat="server" Font-Bold="True" ForeColor="#3333FF"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>



                    </div>

                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanelGrillaConfiguracion" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewConfiguracion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <asp:TemplateField>

                                            <ItemTemplate>

                                                <asp:CheckBox ID="CheckBoxQuitar" runat="server" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:BoundField DataField="SegmentoId" HeaderText="Seg. Id" SortExpression="SegmentoId" />
                                        <asp:BoundField DataField="TipoServicioDescripcion" HeaderText="Seg. Descripcion" SortExpression="TipoServicioDescripcion" />
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



                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" /></td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
