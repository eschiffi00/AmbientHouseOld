 <%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Locaciones.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
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
                        Locaciones<br />
                    </div>
                      <div class="panel-body">

                        <table style="width: 100%;">
                            <tr>
                                <td>Locacion:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcionBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                    </div>
                </div>
                    <div class="panel-body">

                        <asp:Button ID="ButtonAgregarLocacion" runat="server" class="btn btn-info" Text="+ Agregar Locaciones" OnClick="ButtonAgregarLocacion_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />
                        <br />

                        <asp:UpdatePanel ID="UpdatePanelGrillaLocaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewLocaciones" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>


                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Locacion" SortExpression="Descripcion" />
                                         <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Zona" SortExpression="LocalidadDescripcion" />

                                          <asp:BoundField DataField="Cannon" HeaderText="Canon Catering"  DataFormatString="{0:C0}" SortExpression="Cannon" />
                                          <asp:BoundField DataField="CannonBarra" HeaderText="Canon Barra"  DataFormatString="{0:C0}" SortExpression="CannonBarra" />
                                          <asp:BoundField DataField="CannonAmbientacion" HeaderText="Canon Ambientacion"  DataFormatString="{0:C0}"  SortExpression="CannonAmbientacion" />
                                          <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina"  DataFormatString="{0:C0}"  SortExpression="UsoCocina" />


                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Locaciones/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                          <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Locaciones/AgregarTecnica.aspx?Id={0}" ControlStyle-CssClass="btn btn-default" DataNavigateUrlFields="Id" Text="Agregar Tecnica">
                                            <ControlStyle CssClass="btn btn-default" />
                                        </asp:HyperLinkField>

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Locaciones/AgregarAmbientacion.aspx?Id={0}" ControlStyle-CssClass="btn btn-default" DataNavigateUrlFields="Id" Text="Agregar Ambientacion">
                                            <ControlStyle CssClass="btn btn-default" />
                                        </asp:HyperLinkField>

<%--                                         <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Locaciones/IndexAdicionales.aspx?Id={0}"  ControlStyle-CssClass="btn btn-default" DataNavigateUrlFields="Id" Text="Agregar Adicionales">
                                            <ControlStyle CssClass="btn btn-default" />
                                        </asp:HyperLinkField>--%>

                                    </Columns>

                                </asp:GridView>

                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
   <%-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  Launch demo modal</button>

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>--%>


</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
