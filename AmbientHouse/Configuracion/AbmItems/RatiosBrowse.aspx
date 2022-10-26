<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="RatiosBrowse.aspx.cs" Inherits="WebApplication.app.ItemsNS.RatiosBrowse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Css/NuevaArc.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/resizecolumns/jquery.resizableColumns.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/resizecolumns/jquery.resizableColumns.min.js" type="text/javascript"></script>--%>
        <script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
    <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	    rel="stylesheet" type="text/css" />
    
 <%--   <script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
	    type="text/javascript"></script>
    <script>--%>
        <script src="../../Scripts/MultiSelect.js" type="text/javascript"></script>
      <script>

        $(document).ready(function () {
            // seteo como multiselect al listbox
            GroupDropdownlist();
            $('[id*=MultiselectCategorias]').multiselect({
                enableClickableOptGroups: true,
                enableCollapsibleOptGroups: true,
                enableFiltering: true
            }); $('[id*=MultiselectItems]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true,
                onDropdownHide: function (event) {
                    __doPostBack();//__doPostBack($(event.target).parent().children('#DropDownList_ExportCountry').attr('id'), '')
                }
            });
            document.addEventListener("keydown", function (event) {
                if (event.which == 9) {
                    focusNextElement();
                }
            });
            function focusNextElement() {
                //add all elements we want to include in our selection
                var focussableElements = '[tabindex]:not([disabled]):not([tabindex="-1"])';
                if (document.activeElement && document.activeElement.form) {
                    var focussable = Array.prototype.filter.call(document.activeElement.form.querySelectorAll(focussableElements),
                        function (element) {
                            //check for visibility while always include the current activeElement 
                            return element.offsetWidth > 0 || element.offsetHeight > 0 || element === document.activeElement
                        });
                    var index = focussable.indexOf(document.activeElement);
                    if (index <= -1 || index > 8) {
                        $('[Id$=txtDescripcion]').addClass("active");
                        $('[Id$=txtDescripcion]').focus();
                    }
                }
            }


            //$("form input:checkbox").checked = false;

        });

        function GroupDropdownlist() {
            var selectControl = $('[id*=MultiselectCategorias]');
            var groups = [];
            $(selectControl).find('option').each(function () {
                groups.push($(this).attr('data-group'));
            });
            var uniqueGroup = groups.filter(function (itm, i, a) {
                return i == a.indexOf(itm);
            });
            for (var i = 0; i < uniqueGroup.length; i++) {

                var Group = jQuery('<optgroup/>', {
                    label: uniqueGroup[i]
                }).appendTo(selectControl);
                var grpItems = $(selectControl).find('option[data-group="' + uniqueGroup[i] + '"]');
                for (var x = 0; x < grpItems.length; x++) {
                    var item = grpItems[x];
                    if (item.text != uniqueGroup[i]) {
                        //item.appendTo(Group);
                        Group.append(item);
                    } else {
                        grpItems[x].remove();
                    }
                }
            }
        }

      </script>
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
    <div class="row" style ="display:Block">
        <div class="col-8">
            <h4 class="ml-3 mb-4">Listado de Ratios &nbsp;
                <%--<i class="fa fa-search searchicon faborde"></i>
                <asp:LinkButton CssClass="LnkBtnExportar" runat="server" ID="btnExportar" OnClick="btnExportar_Click"><i class="fa fa-download exporticon faborde" title="Exportar Productos"></i></asp:LinkButton>--%>
            </h4>
        </div>
        <div class="form-group row" id="MultiItems">
            <label for="MultiselectItems" class="col-sm-2 col-form-label text-sm-left text-md-right">Items</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectItems" runat="server" SelectionMode="Multiple" OnSelectedIndexChanged="MultiselectItems_SelectedIndexChanged" TabIndex="1" class="form-control" ></asp:ListBox>
            </div>
        </div>

        <div class="form-group row" id="MultiCategorias">
            <label for="MultiselectCategorias" class="col-sm-2 col-form-label text-sm-left text-md-right">Categorias</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectCategorias" runat="server" SelectionMode="Multiple" TabIndex="2" class="form-control"></asp:ListBox>
            </div>
        </div>
        <div class="contenedorbtn form-group row">
            <div class="col-4 text-right">
                <asp:Button ID="btnFiltrar" Text="Filtrar" runat="server" CssClass="btn btnblack btn-primary" OnClick="btnFiltrar_Click" />
            </div>
            <div class="col-4 text-right">
                <asp:Button ID="btnNuevoRatio" Text="Nuevo Producto" runat="server" CssClass="btn btnblack btn-primary" OnClick="btnNuevoRatio_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="table-responsive">
        <asp:GridView ID="grdRatios" CssClass="table table-striped table-bordered table-hover table-sm" runat="server" AutoGenerateColumns="false" onrowcommand="grdRatios_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center columna-iconos-th">
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
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" SortExpression="Id" />
                <asp:BoundField DataField="ItemId" HeaderText="Detalle" Visible="false" />
                <asp:BoundField DataField="ItemDetalle" HeaderText="Item" Visible="true" />
                <asp:BoundField DataField="CategoriaId" HeaderText="CategoriaId" Visible="false" />
                <asp:BoundField DataField="CategoriaDetalle" HeaderText="Categoria Detalle" Visible="true" />
                <asp:BoundField DataField="TipoRatio" HeaderText="Tipo Ratio" Visible="true" />
                <asp:BoundField DataField="DetalleTipo" HeaderText="Detalle Ratio" Visible="true" />
                <asp:BoundField DataField="ValorRatio" HeaderText="Valor Ratio" Visible="true" />
                <asp:BoundField DataField="TopeRatio" HeaderText="Tope Ratio" Visible="true" />
                <asp:BoundField DataField="Menores" HeaderText="Tiene Menores" Visible="true" />
                <asp:BoundField DataField="AdicionalRatio" HeaderText="Es Adicional" Visible="true" />       
                <asp:BoundField DataField="EstadoId" HeaderText="EstadoId" Visible="false" />       
                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true" />       
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

