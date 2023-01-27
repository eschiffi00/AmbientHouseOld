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
            $(document).ready(function () {
                //$(".titulo").click(function () {
                    
                //    $(this).closest(".panel").find(".panelbody").slideToggle();  
                //});
                $(".titulo").click(function () {
                    
                    var $panelBody = $(this).closest(".panel").find(".panelbody");
                    $panelBody.slideToggle();
                    if ($panelBody.find(".subtitulo").length > 0) {
                        $panelBody.find(".subtitulo").slideToggle();
                    }
                });
                $(".superTitulo").click(function () {

                    $(".panelbody").slideToggle();

                });
                $(".subtitulo").click(function () {

                    $(this).nextUntil(".subtitulo:has(h5)").slideToggle();

                });

            });
            
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
    <h1 class="superTitulo">Edicion de Comanda</h1>
    <br />

    <!--#region divPpal -->
     <asp:Panel ID="pnlGral" CssClass="panel" runat="server" data-toggle="collapse">
        <h3 class ="titulo" >Datos Generales</h3>
            <div class="panelbody">
                <div class="data-container">
                    <div class="data-row">
                        <span class="data-title">PresupuestoId:</span>
                        <asp:Label ID="lblPresupuestoId" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Fecha Evento:</span>
                        <asp:Label ID="lblFechaEvento" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Locacion:</span>
                        <asp:Label ID="lblLocacion" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Horario Llegada:</span>
                        <asp:Label ID="lblHorarioLlegada" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Horario Inicio:</span>
                        <asp:Label ID="lblHorarioInicio" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Horario Fin:</span>
                        <asp:Label ID="lblHorarioFin" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Tipo de Evento:</span>
                        <asp:Label ID="lblTipoEvento" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Tipo de Experiencia:</span>
                        <asp:Label ID="lblTipoExperiencia" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Duracion:</span>
                        <asp:Label ID="lblDuracion" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Empresa:</span>
                        <asp:Label ID="lblEmpresa" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Organizador:</span>
                        <asp:Label ID="lblOrganizador" runat="server" Text=""  CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Maitre:</span>
                        <asp:Label ID="lblMaitre" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Coordinador:</span>
                        <asp:Label ID="lblCoordinador" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">JefeProducto:</span>
                        <asp:Label ID="lblJefeProducto" runat="server" Text=""  CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Adultos:</span>
                        <asp:Label ID="lblAdultos" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Menores de 3:</span>
                        <asp:Label ID="lblMenores3" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Menores entre 3 y 8:</span>
                        <asp:Label ID="lblMenores3y8" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Adolescentes:</span>
                        <asp:Label ID="lblAdolescentes" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                    <div class="data-row">
                        <span class="data-title">Estado:</span>
                        <asp:Label ID="lblEstado" runat="server" Text="" CssClass="data-value"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:Panel>
    <hr class="separador" />
    <div runat="server" id="divPpal">
        <asp:Panel ID="pnlBebidas" CssClass="panel" runat="server" data-toggle="collapse">
            <h3 class ="titulo" >Bebidas</h3>
            <div class="panelbody">
                <asp:Repeater ID="repBebidas" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:Panel>
        <hr class="separador" />
        <asp:Panel ID="pnlRecepcion" class="panel" runat="server" data-toggle="collapse">
            <h3 class ="titulo" >Recepcion</h3>
            <div class="panelbody"> 
                <asp:Panel ID="pnlBocados" CssClass="panel" runat="server"  data-toggle="collapse">
                    <h4 class ="titulo" >Bocados</h4>
                    <div class="panelbody">
                        <asp:Repeater ID="repBocados" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </asp:Panel>
                <hr class="separador" />
                <asp:Panel ID="pnlIslas" runat="server" CssClass="panel"  data-toggle="collapse">
                    <h4 class ="titulo" >Islas</h4>
                    <div class="panelbody">
                        <asp:Repeater ID="repIslas" runat="server" OnItemDataBound="repIslas_ItemDataBound">
                    <ItemTemplate>
                        <div class="subtitulo">
                            <asp:PlaceHolder ID="phSubtitulo" runat="server"></asp:PlaceHolder>
                        </div>
                        <div class="subbody">
                            <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:HiddenField ID="hfIsla" runat="server" Value='<%# Eval("Titulo") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </asp:Panel>
            </div>
        </asp:Panel>
        <hr class="separador" />
        <asp:Panel ID="pnlPrincipal" runat="server" CssClass="panel"  data-toggle="collapse">
            <h3 class ="titulo" >Plato Principal</h3>
            <div class="panelbody">    
                <asp:Repeater ID="repPrincipales" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
            </asp:Repeater>
            </div>
        </asp:Panel>
        <hr class="separador" />
        <asp:Panel ID="pnlBrindis" runat="server" CssClass="panel"  data-toggle="collapse">
            <h3 class ="titulo" >Brindis</h3>
            <div class="panelbody">
                <asp:Repeater ID="repBrindis" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                            </div>                            
                        </td>
                        
                        <td>
                            <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
    </asp:Repeater>
            </div>
        </asp:Panel>
        <hr class="separador" />
        <asp:Panel ID="pnlDulce" runat="server" CssClass="panel"  data-toggle="collapse">
            <h3 class ="titulo" >Mesa Dulce</h3>
            <div class="panelbody">    
                <asp:Repeater ID="repDulce" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
            </asp:Repeater>
            </div>
        </asp:Panel>      
        <hr class="separador" />
        <asp:Panel ID="pnlFinFiesta" runat="server" CssClass="panel"  data-toggle="collapse">
            <h3 class ="titulo" >Fin de Fiesta</h3>
            <div class="panelbody">    
                <asp:Repeater ID="repFinFiesta" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
            </asp:Repeater>
            </div>
        </asp:Panel>  
        <hr class="separador" />
         <asp:Panel ID="pnlPostre" runat="server" CssClass="panel"  data-toggle="collapse">
             <h3 class ="titulo" >Postre</h3>
             <div class="panelbody">   
                <asp:Repeater ID="repPostre" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 500px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                                        <asp:HiddenField ID="hfCommon" runat="server" Value='<%# Eval("Clave") %>'/>
                                        <asp:HiddenField ID="hfCommon2" runat="server" Value='<%# Eval("ItemId") %>'/>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </div>                            
                                </td>
                               
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server" Style="width:80px" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
            </asp:Repeater>
             </div>
        </asp:Panel>  

    </div>
    <hr class="separador" />
    <div class="form-group row">
        <label for="btnSubmit" class="col-sm-2 col-form-label text-sm-left text-md-right"></label>
        <div class="col-sm-4">
            <a href="~/Operacion/ComandasBrowse.aspx" rel="stylesheet" class="btn btncancel mt-1"  runat="server">Cancelar</a>
            <asp:Button Text="Guardar" runat="server" ID="btnSubmit" ClientIDMode="Static" CssClass="btn btnsubmit mt-1" OnClick="btnSubmit_Click" />
        </div>
    </div>

    <!--#endregion divPpal -->
<%--    <div id="ratiosDialog" style="display: none;" title="Ratio Duplicado">
      <asp:Literal ID="dialog" runat="server" Text="" />
    </div>--%>
</asp:Content>
