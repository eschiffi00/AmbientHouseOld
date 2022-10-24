<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="RatiosEdit.aspx.cs" Inherits="WebApplication.app.ItemsNS.RatiosEdit"%>
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
            // seteo como multiselect al listbox
            GroupDropdownlist();
            $('[id*=MultiselectCategorias]').multiselect({
                enableClickableOptGroups: true,
                enableCollapsibleOptGroups: true,
                enableFiltering: true
            });
            $('[id*=MultiselectItems]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true,
                onDropdownHide: function (event) {
                    __doPostBack();//__doPostBack($(event.target).parent().children('#DropDownList_ExportCountry').attr('id'), '')
                }
            });
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
            <h4 runat="server" id="h4Titulo" class="ml-3 mb-4">Modificación de Ratios</h4>
        </div>

         <div class="form-group row" id="MultiItems">
            <label for="MultiselectItems" class="col-sm-2 col-form-label text-sm-left text-md-right">Items</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectItems" runat="server" SelectionMode="Multiple"  OnSelectedIndexChanged="MultiselectItems_SelectedIndexChanged" TabIndex="1" class="form-control" ></asp:ListBox>
            </div>
        </div>

        <div class="form-group row" id="categorias">
            <label for="MultiselectCategorias" class="col-sm-2 col-form-label text-sm-left text-md-right">Categoria</label>
            <div class="col-sm-4">
                <asp:ListBox ID="MultiselectCategorias" runat="server" SelectionMode="Multiple" TabIndex="2" class="form-control"></asp:ListBox>
            </div>
        </div>

         <div class="form-group row" id="Dependencia">
            <label for="ddlDependencia" class="col-sm-2 col-form-label text-sm-left text-md-right">Tipo de Ratio</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlDependencia" ClientIDMode="Static" TabIndex="3" CssClass="form-control mt-1" AutoPostBack="true" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                    <asp:ListItem Text="PAX" Value="1" Selected="True" />
                    <asp:ListItem Text="ITEM" Value="2" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row" id="Detalle">
            <label for="txtDetalle" class="col-sm-2 col-form-label text-sm-left text-md-right">Detalle Ratio</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtDetalle" TabIndex="4" CssClass="form-control" required="required" />        
            </div>
        </div>
        <div class="form-group row" id="Valor">
            <label for="txtValor" class="col-sm-2 col-form-label text-sm-left text-md-right">Valor Ratio</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtValor" TabIndex="5" CssClass="form-control" required="required" />        
            </div>
        </div>
        <div class="form-group row" id="Tope">
            <label for="txtTope" class="col-sm-2 col-form-label text-sm-left text-md-right">Tope</label>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtTope" TabIndex="5" CssClass="form-control" required="required" />        
            </div>
        </div>

        <div class="form-group row" id="Menores">
            <label for="chkMenores" class="col-sm-2 col-form-label text-sm-left text-md-right">Ratio para Menores</label>
            <div class="col-sm-6">
               <asp:CheckBox ID="chkMenores" runat="server" class="form-check" Checked="False" TabIndex="6" />        
            </div>
        </div>

        <div class="form-group row" id="Adicional">
            <label for="chkAdicional" class="col-sm-2 col-form-label text-sm-left text-md-right">Es Adicional al Ratio?</label>
            <div class="col-sm-6">
               <asp:CheckBox ID="chkAdicional" runat="server" class="form-check" Checked="False"  TabIndex="7"  />        
            </div>
        </div>

        <div class="form-group row">
            <label for="ddlEstado" class="col-sm-2 col-form-label text-sm-left text-md-right">Estado</label>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" ID="ddlEstado" TabIndex="8" ClientIDMode="Static" CssClass="form-control mt-1">
                    <asp:ListItem Text="Habilitado" Value="36" Selected="True" />
                    <asp:ListItem Text="Deshabilitado" Value="37" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label for="btnSubmit" class="col-sm-2 col-form-label text-sm-left text-md-right"></label>
            <div class="col-sm-4">
                <a href="../../Configuracion/AbmItems/ItemsBrowse.aspx" rel="stylesheet" class="btn btncancel mt-1" tabindex="8" runat="server">Cancelar</a>
                <asp:Button Text="Crear Item" runat="server" ID="btnSubmit" ClientIDMode="Static" TabIndex="9" CssClass="btn btnsubmit mt-1" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </div>
    <!--#endregion divPpal -->
</asp:Content>
