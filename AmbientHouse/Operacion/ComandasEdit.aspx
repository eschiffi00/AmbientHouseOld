<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ComandasEdit.aspx.cs" Inherits="AmbientHouse.Configuracion.AbmItems.ComandasEdit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
    <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	    rel="stylesheet" type="text/css" />
    
  <%--  <script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
	    type="text/javascript"></script>
    <script>--%>
        <script src="../../Scripts/MultiSelect.js" type="text/javascript"></script>
    <script>

        $(document).ready(function () {

            $('[id*=MultiselectItems]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true,
                //onDropdownHide: function (event) {
                //    __doPostBack();
                //}
            });
            $('[id*=MultiselectExperiencias]').multiselect({
                includeSelectAllOption: true,
                dropRight: true,
                enableFiltering: true,
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
                    if (index <= -1 || index > 10) {
                        $('[Id$=txtDescripcion]').addClass("active");
                        $('[Id$=txtDescripcion]').focus();
                    }
                }
            }

            
            //$("form input:checkbox").checked = false;
              
        });
       
        //Total out of range dialog
        function ShowratiosDialog() {
            $(function () {
                $('#ratiosDialog').dialog({
                    modal: true,
                    width: '200px',
                    resizable: false,
                    draggable: false,
                    close: function (event, ui) { $('body').find('#ratiosDialog').remove(); },
                    buttons: {
                        'OK': function () { $(this).dialog('close'); }
                    }
                })
            }).dialog("open");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    
    <!--#region divPpal -->
    <div runat="server" id="divPpal">
        <%--<asp:GridView ID="grdBebidas" CssClass="table table-striped table-bordered table-hover table-sm" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center columna-iconos-th">
                    <ItemStyle HorizontalAlign="Center" CssClass="verticalMiddle columna-iconos-td" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreItem"  runat="server"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center columna-iconos-th">
                    <ItemStyle HorizontalAlign="Center" CssClass="verticalMiddle columna-iconos-td" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCantidad"  runat="server"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="nohaydatos">No hay datos.</div>
            </EmptyDataTemplate>
        </asp:GridView>--%>
        <asp:Panel ID="pnlBebidas" runat="server" GroupingText="Bebidas">
                <asp:Repeater ID="repBebidas" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>

        <asp:Panel ID="pnlComida" runat="server" GroupingText="Comida">
            <asp:Panel ID="pnlBocados" runat="server" GroupingText="Bocados">
                <asp:Repeater ID="repBocados" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:Repeater>
            </asp:Panel>
            <asp:Panel ID="pnlIslas" runat="server" GroupingText="Islas">
                <asp:Repeater ID="repIslas" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:Repeater>
            </asp:Panel>
        </asp:Panel>


        

    </div>

    <!--#endregion divPpal -->
<%--    <div id="ratiosDialog" style="display: none;" title="Ratio Duplicado">
      <asp:Literal ID="dialog" runat="server" Text="" />
    </div>--%>
</asp:Content>
