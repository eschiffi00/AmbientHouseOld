<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.NotaCreditos.Editar" %>
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
                        Agregar/Editar Notas de Credito<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td><h3>Nro Comprobante:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroComprobante" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                   
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td><h3>Importe:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" 
                                        ControlToValidate="TextBoxImporte" Display="Dynamic" 
                                        ErrorMessage="Importe es requerido." 
                                        ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td><h3>Fecha:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control"></asp:TextBox>
                                      <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />
                                </td>
                                <td></td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info"  />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
