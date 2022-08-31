<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="EditarValoresAnuales.aspx.cs" Inherits="AmbientHouse.Costos.Salones.EditarValoresAnuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                        Agregar/Editar Precios Salones<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Anio:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAnio" runat="server" class="form-control" >
                                         
                                    </asp:DropDownList>
                                   
                                </td>
                                <td></td>
                            </tr>
                              <tr>
                                <td><h3>Locacion:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListLocaciones" runat="server" class="form-control" >
                                         
                                    </asp:DropDownList>
                                  </td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td><h3>Precio:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control" MaxLength="13" Width="200px"></asp:TextBox>
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
                                    <h2><asp:Label ID="LabelMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></h2>
                                </td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items"  class="btn btn-info" OnClick="ButtonAceptar_Click"   />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver"  class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
