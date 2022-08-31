<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Impuestos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Impuestos</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Impuesto" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                         &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click"  />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaImpuestos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewImpuestos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewImpuestos_PageIndexChanging" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Impuestos con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                            <asp:BoundField DataField="Porcentaje" HeaderText="%" SortExpression="Porcentaje" />

                                           <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Impuestos/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar" >
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                    </Columns>
                              
                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
