<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Costos.Salones.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Precio/Costo Salones</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Lista de Precios Salones" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                
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
                        <asp:UpdatePanel ID="UpdatePanelGrillaPrecioSalones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewPrecioSalones" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewPrecioSalones_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="LocacionId" HeaderText="Locacion" SortExpression="LocacionId" />
                                        <asp:BoundField DataField="CantidadInvitados" HeaderText="Cant. Personas" SortExpression="CantidadInvitados" />
                                        <asp:BoundField DataField="Costo" HeaderText="Costo $" SortExpression="Costo" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio $" SortExpression="Precio" />
                                        <asp:BoundField DataField="ValorMas5PorCiento" HeaderText="Pl + 5 $" SortExpression="ValorMas5PorCiento" />
                                        <asp:BoundField DataField="ValorMenos5PorCiento" HeaderText="Pl - 5 $" SortExpression="ValorMenos5PorCiento" />
                                        <asp:BoundField DataField="ValorMenos10PorCiento" HeaderText="Pl - 10 $" SortExpression="ValorMenos10PorCiento" />


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
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
