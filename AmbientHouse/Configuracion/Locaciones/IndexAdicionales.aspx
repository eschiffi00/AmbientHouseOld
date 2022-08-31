<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="IndexAdicionales.aspx.cs" Inherits="AmbientHouse.Configuracion.Locaciones.IndexAdicionales" %>
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
                       
                        <h3><asp:Label ID="LabelLocacion" runat="server"></asp:Label></h3> <br />
                    </div>
                    <div class="panel-body">

                        <asp:Button ID="ButtonAgregarLocacion" runat="server" class="btn btn-info" Text="+ Agregar Adicionales Locacion" OnClick="ButtonAgregarLocacion_Click" />
                        &nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default"  Text="Volver" OnClick="ButtonVolver_Click" />
                        <br />

                        <asp:UpdatePanel ID="UpdatePanelGrillaAdicionalesSalon" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewAdicionalesSalon" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Adicionales para esta Locacion!  
                                    </EmptyDataTemplate>

                                    <Columns>


                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Locacion" SortExpression="Descripcion" />



                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Locaciones/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

 
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
