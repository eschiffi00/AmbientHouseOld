<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Organizador.Degustacion.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
       <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Degustacion</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                  <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Fecha Degustacion:</h3>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxFechaDegustacion" runat="server" Width="300px"  class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDegustacion" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDegustacion" TodaysDateFormat="" CssClass="black" />

                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="FechaDegustacionRequired" runat="server" ControlToValidate="TextBoxFechaDegustacion" Display="Dynamic" ErrorMessage="Fecha Degustacion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        <h3>Hora Inicio Corporativo:</h3>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxHoraCorporativo" runat="server" Width="100px"  class="form-control"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraCorporativo" TargetControlID="TextBoxHoraCorporativo" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="HorarioCorporativoRequired" runat="server" ControlToValidate="TextBoxHoraCorporativo" Display="Dynamic" ErrorMessage="Horario Corporativo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Hora Inicio Social:</h3>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxHoraSocial" runat="server" Width="100px"  class="form-control"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraSocial" TargetControlID="TextBoxHoraSocial" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />

                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="HorarioSocialRequired" runat="server" ControlToValidate="TextBoxHoraSocial" Display="Dynamic" ErrorMessage="Horario Social es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
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
                                        <asp:DropDownList ID="DropDownListLocaciones" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>

                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                       
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click"  class="btn btn-info" Text="Aceptar" ValidationGroup="Cliente" />
                        &nbsp;
                &nbsp;<asp:Button ID="ButtonVolver" runat="server"  class="btn btn-outline-primaryt" OnClick="ButtonVolver_Click" Text="Volver" />
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
