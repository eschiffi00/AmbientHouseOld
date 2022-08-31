<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="AgregarAmbientacion.aspx.cs" Inherits="AmbientHouse.Configuracion.Locaciones.AgregarAmbientacion" %>
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
                        <h3>Ambientacion Locacion</h3>
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
                                    <h3><asp:Label ID="LabelLocacion" runat="server" Text=""></asp:Label></h3>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Sector:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSectores" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSectores_SelectedIndexChanged">
                                
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>&nbsp;Proveedor Ambientacion:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%">
                                        <asp:ListItem Value="0">&lt;Seleccione un Proveedor&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregar" runat="server" OnClick="ButtonAgregar_Click"  class="btn btn-success" Text="Agregar" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitar_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                      <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewProveedores" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay  Impuestos con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>

                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                                    <asp:BoundField DataField="LocacionDescripcion" HeaderText="Locacion" SortExpression="LocacionDescripcion" />
                                                    <asp:BoundField DataField="SectorDescripcion" HeaderText="Sector" SortExpression="SectorDescripcion" />
                                                    <asp:BoundField DataField="SectorId" HeaderText="" SortExpression="SectorId" />
                                                    <asp:BoundField DataField="LocacionId" HeaderText="" SortExpression="LocacionId" />
                                                    <asp:BoundField DataField="ProveedorId" HeaderText="" SortExpression="ProveedorId" />

                                                    <asp:TemplateField>

                                                        <ItemTemplate>

                                                            <asp:CheckBox ID="CheckBoxQuitarImpuestos" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>




                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>

                                          <Triggers>
                                              <asp:AsyncPostBackTrigger ControlID="DropDownListSectores" EventName="SelectedIndexChanged" />
                                          </Triggers>

                                    </asp:UpdatePanel></td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
