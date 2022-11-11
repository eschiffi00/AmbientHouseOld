    <%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Inicio.Experiencias.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Tipo Catering</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaClientes" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewTpoCatering" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewTpoCatering_RowCommand">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />

                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />


                                        <asp:TemplateField>
                                            <ItemTemplate>

                                                <asp:ImageButton ID="ButtonVerExperiencia" runat="server" Text="Experiencia" ImageUrl="~/Content/Imagenes/Detalle.png" CommandName="Experiencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                            </ItemTemplate>
                                        </asp:TemplateField>

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
