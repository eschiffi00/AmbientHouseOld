<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Recibos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Recibos</h3>
            <br />
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelGrillaRecibos" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">

                        <tr>
                            <td>&nbsp;</td>
                            <td>

                                <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Recibo" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>

                                <asp:GridView ID="GridViewRecibos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Recibos con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                       <%-- <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="NroRecibo" HeaderText="Nro Recibo" SortExpression="NroRecibo" />
                                        <asp:BoundField DataField="Importe" HeaderText="Importe" SortExpression="Importe" />
                                       
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Recibos/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
