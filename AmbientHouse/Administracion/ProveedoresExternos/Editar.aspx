<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.ProveedoresExternos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../../Scripts/jquery-1.9.1.js"></script>--%>
    <script src="../../Scripts/jquery-1.9.1.min.js"></script>

    <script type="text/javascript">

        function fnAceptar(id) {

            var text = document.getElementById('ContentPlaceHolder2_TextBoxComentario' + id);

            $.ajax({
                type: "POST",
                url: "Editar.aspx/HelloWorld",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //alert("User has been added successfully.");
                    getDetails();
                    //getDetails(); //This method is to bind the added data into my HTML Table through Ajax call instead of page load  
                    // window.location.reload(); we can also use this to load window to show updated data  
                },
                failure: function (response) {
                    alert("User has been added successfully.(Error)");
                }
            });

            function OnSuccess(response) {
                alert(response.d);
            }
        }

        function getDetails() {

            $.ajax({
                type: "POST",
                url: "Editar.aspx/GetDatos",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    alert("User has been added successfully.");
                    //getDetails(); //This method is to bind the added data into my HTML Table through Ajax call instead of page load  
                    // window.location.reload(); we can also use this to load window to show updated data  
                },
                failure: function (response) {
                    alert("User has been added successfully.(Error)");
                }
            });

            function OnSuccess(response) {
                alert(response.d);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table id="TableTipoCatering" style="width: 100%;" runat="server">
    </table>
    <h3>Comentario Presupuesto</h3>
    <p>

        <asp:TextBox ID="TextBoxComentarioPresupuesto" runat="server" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>

    </p>
    <h3>Comentario Evento</h3>
    <p>

        <asp:TextBox ID="TextBoxComentarioEvento" runat="server" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>

    </p>
    <asp:UpdatePanel ID="UpdatePanelProveedores" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="contenedor">

                <asp:GridView ID="GridViewVentas" runat="server"
                    CssClass="table table-bordered bs-table"
                    AutoGenerateColumns="False"
                    CellPadding="4"
                    EmptyDataText="No se Encontraron Registros"
                    ForeColor="#333333"
                    GridLines="None"
                    Width="100%"
                    OnRowCommand="GridViewVentas_RowCommand"
                    OnRowDataBound="GridViewVentas_RowDataBound">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#ffffcc" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No hay Unidades agregadas al presupuesto!  
                    </EmptyDataTemplate>

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                        <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                        <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                         <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                        <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C0}" SortExpression="Costo" />
                        <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonEstado" runat="server" Height="30px" Width="30px" CommandName="Estado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Comentario Proveedor" ControlStyle-Width="200px" ControlStyle-Height="100px">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxComentarioProoveedor" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="100%"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Height="100px" Width="200px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            </div>
            <div>
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" CssClass="btn btn-default" OnClick="ButtonVolver_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
