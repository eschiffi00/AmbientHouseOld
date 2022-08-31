<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Transferencias.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Transferencias</h3>
            <br />
        </div>
          <div class="panel-body">
            <table style="width: 100%;">
                 <tr>
                    <td>Nro. CUIT</td>
                    <td>
                        <asp:TextBox ID="TextBoxNroCuit" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Razon Social:</td>
                    <td>
                        <asp:TextBox ID="TextBoxRazonSocial" class="form-control" runat="server" Width="300px" AutoPostBack="True" ></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Nro. Transferencia</td>
                    <td>
                        <asp:TextBox ID="TextBoxNroTransferencia" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
               
                <tr>
                    <td>Fecha Transferencia:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFecha" class="form-control" runat="server" Width="200px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />&nbsp;|&nbsp;
                        
                              <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                        <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar Filtros" OnClick="ButtonLimpiar_Click"  />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelGrillaTransferencias" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">

                        <tr>
                            <td>&nbsp;</td>
                            <td>

                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>

                                <asp:GridView ID="GridViewTransferencias" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewTransferencias_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Transferencias con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="NroTransferencia" HeaderText="Nro Transferencia" SortExpression="NroTransferencia" />
                                        <asp:BoundField DataField="ClienteDescripcion" HeaderText="Cliente" SortExpression="ClienteDescripcion" />
                                        <asp:BoundField DataField="ProveedorDescripcion" HeaderText="Proveedor" SortExpression="ProveedorDescripcion" />
                                        <asp:BoundField DataField="ImporteStr" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="ImporteStr" />
                                        <asp:BoundField DataField="FechaTransferenciaStr"  HeaderText="Fecha Transferencia" SortExpression="FechaTransferenciaStr" />
                                       
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Transferencias/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                    </Columns>

                                </asp:GridView>


                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
