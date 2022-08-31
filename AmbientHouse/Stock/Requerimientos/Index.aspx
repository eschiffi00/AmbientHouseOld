<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Stock.Requerimientos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-sm">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Requerimientos</h3>
                        <br />
                    </div>

                </div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanelGrillaRequerimientos" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="width: 100%;">

                                <tr>
                                    <td>&nbsp;</td>
                                    <td>

                                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Requerimiento" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-secondary" Text="Volver" OnClick="ButtonVolver_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>

                                    <td>

                                        <asp:GridView ID="GridViewRequerimientos" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewRequerimientos_PageIndexChanging">
                                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#ffffcc" />
                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                            <EmptyDataTemplate>
                                                ¡No hay Requerimientos pendientes!  
                                            </EmptyDataTemplate>
                                            <Columns>

                                                <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha Requerimiento" SortExpression="Fecha" />
                                                <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="EstadoDescripcion" />

                                                <asp:HyperLinkField DataNavigateUrlFormatString="~/Stock/Requerimiento/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-dark" DataNavigateUrlFields="Id" Text="Editar">
                                                    <ControlStyle CssClass="btn btn-info" />
                                                </asp:HyperLinkField>

                                            </Columns>

                                        </asp:GridView>


                                    </td>
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
                </div>

            </div>
        </div>

    </div>
    <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../Boostrap4/js/popper.min.js"></script>
    <script src="../../Boostrap4/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
