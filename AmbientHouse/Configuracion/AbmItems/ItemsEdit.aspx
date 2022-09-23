<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ItemsEdit.aspx.cs" Inherits="WebApplication.app.ItemsNS.ItemsEdit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
    <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	    rel="stylesheet" type="text/css" />
    
 <%--   <script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
	    type="text/javascript"></script>
    <script>--%>
        <script src="../../Scripts/MultiSelect.js" type="text/javascript"></script>
    <script>

        $(document).ready(function () {
            GroupDropdownlist();
            $('[id*=MultiselectCategorias]').multiselect({
                enableClickableOptGroups: true,
                enableCollapsibleOptGroups: true,
                enableFiltering: true
            });
            //document.addEventListener("keydown", function (event) {
            //    if (event.which == 9 && (document.activeElement.tabIndex == 9 || document.activeElement.tabIndex == -1 )) {
            //        //document.activeElement.tabIndex = 1;
            //        $('[tabindex=1]').activeElement = true;
            //    }
            //});
            document.addEventListener("keydown", function (event) {
                if (event.which == 9 ) {
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

            
            $("form input:checkbox").checked = false;
            //var multi = $('[id$=MultiselectCategorias]')[0];
            ////$('[id*=MultiselectCategorias]')[0].each(function () {
            ////    $(this).attr('checked', false);
            ////});
            //for (var i = 0; i < multi.length; i++) {
            //    console.log(i);
            //    if (multi[i].tagName == 'OPTION') {
            //        multi[i].prop('checked', false);
            //    }
                
            //}
              
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
                for (var x = 0; x < grpItems.length; x++)
                {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    
    <!--#region divPpal -->
    <div runat="server" id="divPpal">
        <div class="row">
            <h4 runat="server" id="h4Titulo" class="ml-3 mb-4">Modificación de Items</h4>
        </div>

        <div class="form-group row">
            <label for="txtDescripcion" class="col-sm-2 col-form-label text-sm-left text-md-right">Descripcion</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TabIndex="1" placeholder="Descripcion del Producto" required="required" />
                <div class="invalid-feedback">Debe ingresar una descripcion para el Item</div>
            </div>
        </div>

        <div class="form-group row" id="categorias">
            <label for="MultiselectCategorias" class="col-sm-2 col-form-label text-sm-left text-md-right">Categoria</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectCategorias" runat="server" SelectionMode="Multiple" TabIndex="2" class="form-control"></asp:ListBox>
            </div>
        </div>


        <div class="form-group row" id="cuentas">
            <label for="ddlCuenta" class="col-sm-2 col-form-label text-sm-left text-md-right">Cuenta Contable</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlCuenta" ClientIDMode="Static" TabIndex="3" CssClass="form-control mt-1"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row" id="costo">
            <label for="txtCosto" class="col-sm-2 col-form-label text-sm-left text-md-right">Costo</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtCosto" TabIndex="4" CssClass="form-control" placeholder="Ingrese el Costo" required="required" />        
            </div>
        </div>
        <div class="form-group row"  id="margen">
            <label for="txtMargen" class="col-sm-2 col-form-label text-sm-left text-md-right">Margen</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtMargen" TabIndex="5" CssClass="form-control" placeholder="Ingrese el Margen" required="required" />        
            </div>
        </div>
        <div class="form-group row"  id="precio">
            <label for="txtPrecio" class="col-sm-2 col-form-label text-sm-left text-md-right">Precio</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtPrecio" TabIndex="6" CssClass="form-control" placeholder="Ingrese el Precio" required="required" />        
            </div>
        </div>
     <%--   <div class="form-group row">
            <label for="ddlUnidad" class="col-sm-2 col-form-label text-sm-left text-md-right">Unidad</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlUnidad" TabIndex="6" ClientIDMode="Static" CssClass="form-control mt-1"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label for="txtCantidad" class="col-sm-2 col-form-label text-sm-left text-md-right">Cantidad</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtCantidad" TabIndex="7" CssClass="form-control" placeholder="Ingrese el Stock" required="required" />        
            </div>
        </div>--%>
        <div class="form-group row">
            <label for="ddlEstado" class="col-sm-2 col-form-label text-sm-left text-md-right">Estado</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlEstado" TabIndex="7" ClientIDMode="Static" CssClass="form-control mt-1">
                    <asp:ListItem Text="Habilitado" Value="36" Selected="True" />
                    <asp:ListItem Text="Deshabilitado" Value="37" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label for="btnSubmit" class="col-sm-2 col-form-label text-sm-left text-md-right"></label>
            <div class="col-sm-4">
                <a href="../../Configuracion/ItemsBrowse.aspx" rel="stylesheet" class="btn btncancel mt-1" tabindex="8" runat="server">Cancelar</a>
                <asp:Button Text="Crear Item" runat="server" ID="btnSubmit" ClientIDMode="Static" TabIndex="9" CssClass="btn btnsubmit mt-1" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </div>
    <!--#endregion divPpal -->
</asp:Content>
