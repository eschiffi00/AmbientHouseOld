<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ItemsBrowse.aspx.cs" Inherits="AmbientHouse.Configuracion.AbmItems.ItemsBrowse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Css/NuevaArc.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/resizecolumns/jquery.resizableColumns.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/resizecolumns/jquery.resizableColumns.min.js" type="text/javascript"></script>--%>
    

    <script>
        //var j = jQuery.noConflict();

        //function ShowError(error) {
        //    var texto;
        //    switch (error) {
        //        case "1":
        //            texto = 'El Monto a Pagar es mayor que el Costo';
        //            break;
        //        case "2":
        //            texto = 'El Monto a Pagar es distinto del Importe Saldo';
        //            break;
        //    }
        //    j(function () {
        //        j('#dialog').dialog({
        //            modal: true,
        //            width: 'auto',
        //            resizable: false,
        //            draggable: false,
        //            close: function (event, ui) { j('body').find('#dialog').remove(); },
        //            closeText: "X",
        //            show: "fade",
        //            hide: "fade",
        //            open: function () {
        //                $(this).html(texto);
        //            },

        //        })
        //    });

        //    j("#dialog").dialog("open");
        //    j('#dialog').html(texto).dialog({});
        //    /*$("#dialog").html(texto);*/
        //}
        function ConfirmaBorrado(e) {
            //o = document.getElementById(e.id);
            anchor = "#" + e.id;
            if ($(anchor).attr("disabled") == "disabled") return false;
            resp = confirm('¿Está seguro de borrar este Producto?');
            if (resp == true) {
                //$(anchor).text("Borrando...");
                $(anchor).attr("disabled", "disabled");
                $(anchor).prenventDefault();
                return true;
            }
            else return false;
        }
        $(function () {
            $("table").resizableColumns();
        });
        $(document).ready(function () {
            
            if ($("#searchpanelstate").val() == "invisible") $("#searchpanel").addClass('invisible');
            else $("#searchpanel").removeClass('invisible');

            $(".searchicon").click(function (event) {
                if ($("#searchpanel").hasClass("invisible")) {
                    $("#searchpanel").removeClass('invisible');
                    $("#searchpanelstate").val("visible");
                }
                else {
                    $("#searchpanel").addClass('invisible');
                    $("#searchpanelstate").val("invisible");
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
        <asp:TextBox runat="server" ID="searchpanelstate" Text="invisible" CssClass="invisible" ClientIDMode="Static"></asp:TextBox>
    <div class="row">
        <div class="col-8">
            <h4 class="ml-3 mb-4">Listado de Productos &nbsp;
                <%--<i class="fa fa-search searchicon faborde"></i>
                <asp:LinkButton CssClass="LnkBtnExportar" runat="server" ID="btnExportar" OnClick="btnExportar_Click"><i class="fa fa-download exporticon faborde" title="Exportar Productos"></i></asp:LinkButton>--%>
            </h4>
        </div>
        
        <div class="col-4 text-right">
            <asp:Button ID="btnNuevoProducto" Text="Nuevo Producto" runat="server" CssClass="btn btnblack btn-primary" OnClick="btnNuevoItems_Click" />
        </div>
    </div>
    <div id="searchpanel" class="row invisible mb-2">
        <div class="col-3">
            <asp:TextBox runat="server" ID="txtBuscar" TextMode="Search" CssClass="form-control" placeholder="Codigo, Nombre, R.Social" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" />
        </div>
        <div class="col-3">
        </div>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grdItems" CssClass="table table-bordered table-hover table-sm" runat="server" AutoGenerateColumns="false" onrowcommand="grdItems_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center columna-iconos-th header-black">
                    <ItemStyle HorizontalAlign="Center" CssClass="verticalMiddle columna-iconos-td" />
                    <ItemTemplate>
                        <%--<div class="d-flex justify-content-between w-75 text-center mr-1">--%>
                        <div class="columna-iconos-gridview">
                            <div>
                                <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="false" CommandName="CommandNameDelete" Text="" ToolTip="Borrar Item" CssClass="ml-2 mr-2" OnClientClick="return ConfirmaBorrado(this);"><i class="fa fa-trash" ></i></asp:LinkButton>
                            </div>
                            <div>
                                <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="false" CommandName="CommandNameEdit" Text="" ToolTip="Modificar" CssClass="ml-2 mr-2" ><i class="fa fa-pencil" ></i></asp:LinkButton>
                            </div>
                            <%--<div>
                                <asp:LinkButton ID="LinkButtonTarifa" runat="server" CausesValidation="False" CommandName="CommandNameTarifa" Text="" ToolTip="Tarifas" CssClass="mr-2"><i class="fa fa-usd" ></i></asp:LinkButton>
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" SortExpression="Id" HeaderStyle-CssClass="header-black" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="CategoriaItemId" HeaderText="Categoria" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="CategoriaDescripcion" HeaderText="Categoria" Visible="true" HeaderStyle-CssClass="header-black" />
                <asp:BoundField DataField="NombreFantasiaId" HeaderText="NombreFantasiaId" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="NombreFantasia" HeaderText="Nombre Fantasía" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="CuentaId" HeaderText="CuentaId" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="CuentaDescripcion" HeaderText="Cuenta" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Costo" HeaderText="Costo" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Margen" HeaderText="Margen" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Precio" HeaderText="Precio" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="DepositoId" HeaderText="Stock" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Unidad" HeaderText="Unidad" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" Visible="false" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="Estado" HeaderText="Habilitado" Visible="true" HeaderStyle-CssClass="header-black"/>
                <asp:BoundField DataField="TipoItem" HeaderText="Tipo Item" Visible="false" HeaderStyle-CssClass="header-black"/>
                

               
              
            </Columns>
            <EmptyDataTemplate>
                <div class="nohaydatos">No hay datos.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <%--<div id="dialog" style="display: none;" title="Eliminar">--%>
      <%--<p>
        El Monto a Pagar es mayor que el Costo
      </p>--%>
    <%--</div>--%>
</asp:Content>

