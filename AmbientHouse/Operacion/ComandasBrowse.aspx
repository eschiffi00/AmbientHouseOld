﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ComandasBrowse.aspx.cs" Inherits="AmbientHouse.Configuracion.AbmItems.ComandasBrowse"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Css/NuevaArc.css" rel="stylesheet" type="text/css" />
        <script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
    <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	    rel="stylesheet" type="text/css" />
        <script src="../../Scripts/MultiSelect.js" type="text/javascript"></script>
      <script>

        $(document).ready(function () {
            // seteo como multiselect al listbox
            GroupDropdownlist();
            $('[id*=MultiselectExperiencias]').multiselect({
                enableClickableOptGroups: true,
                enableCollapsibleOptGroups: true,
                enableFiltering: true
            });
            //$('[id*=MultiselectItems]').multiselect({
            //    includeSelectAllOption: true,
            //    dropRight: true,
            //    enableFiltering: true
            //});
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
            <h4 class="ml-3 mb-4">Listado de Comandas &nbsp;
               
            </h4>
        </div>
       <%-- <div class="form-group row" id="MultiItems">
            <label for="MultiselectItems" class="col-sm-2 col-form-label text-sm-left text-md-right">Items</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectItems" runat="server" SelectionMode="Multiple" TabIndex="1" class="form-control" ></asp:ListBox>
            </div>
        </div>--%>
        <%--<div class="form-group row" id="MultiExperiencias">
            <label for="MultiselectExperiencias" class="col-sm-2 col-form-label text-sm-left text-md-right">Experiencia/Barra</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectExperiencias" runat="server" SelectionMode="Multiple" TabIndex="2" class="form-control"></asp:ListBox>
            </div>
        </div>--%>
        <%--<div class="contenedorbtn form-group row">
            <div class="col-4 text-right">
                <asp:Button ID="btnFiltrar" Text="Filtrar" runat="server" CssClass="btn btnblack btn-primary" OnClick="btnFiltrar_Click" />
            </div>
        </div>--%>
    </div>
    <br />
    <div class="table-responsive">
        <asp:GridView ID="grdComandas" CssClass="table table-striped table-bordered table-hover table-sm" runat="server" AutoGenerateColumns="false" onrowcommand="grdComandas_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center columna-iconos-th">
                    <ItemStyle HorizontalAlign="Center" CssClass="verticalMiddle columna-iconos-td" />
                    <ItemTemplate>
                        <div class="columna-iconos-gridview">
                            <div>
                                <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="false" CommandName="CommandNameDelete" Text="" ToolTip="Borrar Item" CssClass="ml-2 mr-2" OnClientClick="return ConfirmaBorrado(this);"><i class="fa fa-trash" ></i></asp:LinkButton>
                            </div>
                            <div>
                                <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="false" CommandName="CommandNameEdit" Text="" ToolTip="Modificar" CssClass="ml-2 mr-2" ><i class="fa fa-pencil" ></i></asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" SortExpression="Id" />
                <asp:BoundField DataField="PresupuestoId" HeaderText="Presupuesto" Visible="true" />
                <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" Visible="true" />
                <asp:BoundField DataField="Locacion" HeaderText="Locacion" Visible="true" />
                <asp:BoundField DataField="HorarioLlegada" HeaderText="Horario Llegada" Visible="true" />
                <asp:BoundField DataField="HorarioInicio" HeaderText="Horario Inicio" Visible="true" />
                <asp:BoundField DataField="HorarioFin" HeaderText="Horario Fin" Visible="true" />
                <asp:BoundField DataField="TipoEvento" HeaderText="Tipo Evento" Visible="true" /> 
                <asp:BoundField DataField="TipoExperiencia" HeaderText="Tipo Experiencia" Visible="true" />
                <asp:BoundField DataField="Duracion" HeaderText="Duracion" Visible="true" />
                <asp:BoundField DataField="Empresa" HeaderText="Empresa" Visible="true" />
                <asp:BoundField DataField="Organizador" HeaderText="Organizador" Visible="true" />
                <asp:BoundField DataField="Maitre" HeaderText="Maitre" Visible="false" />
                <asp:BoundField DataField="Coordinador" HeaderText="Coordinador" Visible="false" /> 
                <asp:BoundField DataField="JefeProducto" HeaderText="Jefe Producto" Visible="false" />
                <asp:BoundField DataField="Adultos" HeaderText="Adultos" Visible="true" />
                <asp:BoundField DataField="Menores3" HeaderText="Menores de 3" Visible="true" />
                <asp:BoundField DataField="Menores3y8" HeaderText="Menores entre 3 y 8" Visible="true" />
                <asp:BoundField DataField="Adolescentes" HeaderText="Adolescentes" Visible="true" />
                <asp:BoundField DataField="EstadoId" HeaderText="EstadoId" Visible="false" /> 
                <%--<asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true" />--%> 
                
            </Columns>
            <EmptyDataTemplate>
                <div class="nohaydatos">No hay datos.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>

