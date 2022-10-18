<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Tecnica.aspx.cs" Inherits="AmbientHouse.Administracion.Costos.Tecnica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

<script src="<%=ResolveUrl("~")%>Scripts/umd/popper.min.js"></script>
<link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
	rel="stylesheet" type="text/css" />
<script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
	type="text/javascript"></script>
	
    <script>
	$(document).ready(function () {
        $('[id*=MultiSelectDia]').multiselect({
			includeSelectAllOption: true,
			dropRight: true
        });
        $('[id*=MultiSelectMes]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
            
        });
        $('[id*=MultiSelectAnual]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
        });
        $('[id*=MultiSelectServicios]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
        });
    });
    function pageLoad() {
        $('[id*=MultiSelectDia]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
        });
        $('[id*=MultiSelectMes]').multiselect({
            includeSelectAllOption: true,
            dropRight: true

        });
        $('[id*=MultiSelectAnual]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
        });
        $('[id*=MultiSelectServicios]').multiselect({
            includeSelectAllOption: true,
            dropRight: true
        });
    }

    </script>

    <asp:UpdatePanel ID="UpdatePanelTecnica" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Actualizar Costo Tecnica<br />
                            </div>
                            <div class="panel-body">

                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Locacion:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListLocacion" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocacion_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Sector:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListSector" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <h3>Servicio:</h3>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="MultiSelectServicios" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                        </td>
                                        <td></td>
                                    </tr> 
                                    <tr>
                                        <td>
                                            <h3>Segmento:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListSegmentos" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Proveedores:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListProveedores" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Año:</h3>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="MultiSelectAnual" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Mes:</h3>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="MultiSelectMes" runat="server" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Dia:</h3>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="MultiSelectDia" runat="server" SelectionMode="Multiple" class="form-control" ></asp:ListBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Costo:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCosto" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="DetalleRequiredCosto" runat="server" ControlToValidate="TextBoxCosto" Display="Dynamic" ErrorMessage="Costo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Precio:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrecio" runat="server" ControlToValidate="TextBoxPrecio" Display="Dynamic" ErrorMessage="Precio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Royalty:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxRoyalty" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoyalty" runat="server" ControlToValidate="TextBoxRoyalty" Display="Dynamic" ErrorMessage="Royalty es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                      <tr>
                                        <td colspan="3">
                                             <asp:UpdatePanel ID="UpdatePanelGrillaProductos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewProductos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Productos con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                       
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                        <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" />
                                        <asp:BoundField DataField="Margen" HeaderText="Margen" SortExpression="Margen" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                                     
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                                        </td>
                                        
                                    </tr>
                                      <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-outline-primary" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
