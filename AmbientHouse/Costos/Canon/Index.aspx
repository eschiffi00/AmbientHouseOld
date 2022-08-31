<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Costos.Canon.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Costos Cannon</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Lista de Precios Cannon" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaCostoCannon" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewCostoCannon" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewCostoCannon_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Costos con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="SegmentoId" HeaderText="Segmento Id" SortExpression="SegmentoId" />
                                        <asp:BoundField DataField="SegmentoDescripcion" HeaderText="Segmento" SortExpression="SegmentoDescripcion" />
                                        <asp:BoundField DataField="CaracteristicaId" HeaderText="Caracteristica Id" SortExpression="CaracteristicaId" />
                                        <asp:BoundField DataField="CaracteristicaDescripcion" HeaderText="Caracteristica" SortExpression="CaracteristicaDescripcion" />
                                        <asp:BoundField DataField="TipoCateringId" HeaderText="Tipo Catering Id" SortExpression="TipoCateringId" />
                                        <asp:BoundField DataField="TipoCateringDescripcion" HeaderText="Tipo Catering" SortExpression="TipoCateringDescripcion" />
                                        <asp:BoundField DataField="CanonInterno" HeaderText="Cannon Interno" SortExpression="CanonInterno" />
                                        <asp:BoundField DataField="CanonExterno" HeaderText="Cannon Externo" SortExpression="CanonExterno" />
                                        <%-- <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina" SortExpression="UsoCocina" />--%>

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Costos/Canon/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
