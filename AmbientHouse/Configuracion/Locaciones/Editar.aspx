<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Locaciones.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 56px;
        }

        .auto-style2 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanelLocaciones" runat="server" UpdateMode="Conditional">
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
                                Agregar/Editar Locaciones<br />
                            </div>
                            <div class="panel-body">


                                <table style="width: 100%;">
                                    <tr>
                                        <td>&nbsp;</td>

                                        <td>&nbsp;</td>

                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Locacion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                                            <asp:Label ID="LabelSalonRepetido" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>

                                        </td>
                                        <td rowspan="15">
                                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3283.718940608615!2d-58.37184168477015!3d-34.6112679804575!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95a3352b1ccb0299%3A0xa5aa7ac31ee24fc!2sEdificio+Lahusen+%7C+Sal%C3%B3n+de+Eventos!5e0!3m2!1ses!2sar!4v1520452002856" width="600" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Locacion Propia?</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListTipoLocacion" runat="server" class="form-control" Width="100px">
                                                <asp:ListItem Value="P">Si</asp:ListItem>
                                                <asp:ListItem Value="NP">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Capacidad Formal:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCapacidadFormal" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Capacidad Informal:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCapacidadInformal" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Capacidad Auditorio:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCapacidadAuditorio" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Verde:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListVerde" runat="server" class="form-control" Width="100px">
                                                <asp:ListItem Value="SI">Si</asp:ListItem>
                                                <asp:ListItem Value="NO">No</asp:ListItem>
                                            </asp:DropDownList></td>

                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Aire Libre:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListAireLibre" runat="server" class="form-control" Width="100px">
                                                <asp:ListItem Value="SI">Si</asp:ListItem>
                                                <asp:ListItem Value="NO">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Estacionamiento:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListEstacionamiento" runat="server" class="form-control" Width="100px">
                                                <asp:ListItem Value="SI">Si</asp:ListItem>
                                                <asp:ListItem Value="NO">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <h3>Uso de Cocina:</h3>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="TextBoxUsoCocina" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonCannonPorPersonaCatering" runat="server" Text="Canon por Persona?" GroupName="Catering" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonPorcentajeCatering" runat="server" Text="Canon Porcentaje del Total?" GroupName="Catering" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonValorAbsolutoCatering" runat="server" Text="Canon Valor Fijo?" GroupName="Catering" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Canon Catering:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCannon" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonCannonPorPersonaBarra" runat="server" Text="Canon por Persona?" GroupName="Barra" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonPorcentajeBarra" runat="server" Text="Canon Porcentaje del Total?" GroupName="Barra" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonValorAbsolutoBarra" runat="server" Text="Canon Valor Fijo?" GroupName="Barra" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Canon Barra:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCannonBarra" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                         <td>
                                            <asp:RadioButton ID="RadioButtonCannonPorPersonaAmbientacion" runat="server" Text="Canon por Persona?" GroupName="Ambientacion" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonPorcentajeAmbientacion" runat="server" Text="Canon Porcentaje del Total?" GroupName="Ambientacion" />
                                            &nbsp;|&nbsp;
                                            <asp:RadioButton ID="RadioButtonCannonValorAbsolutoAmbientacion" runat="server" Text="Canon Valor Fijo?" GroupName="Ambientacion" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Canon Ambientacion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCannonAmbientacion" runat="server" class="form-control" Width="100px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Direccion:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDireccion" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Telefono:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxTel" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Mail:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxMail" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Web:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxWeb" runat="server" class="form-control" Width="300px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Localidad:</h3>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListLocalidades" runat="server" class="form-control" Width="400px">
                                            </asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Comentarios:</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxComentarios" runat="server" class="form-control" Width="600px" MaxLength="2000" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                        <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <h4><asp:CheckBox ID="CheckBoxRequiereMesasySillas" runat="server" OnCheckedChanged="CheckBoxRequiereMesasySillas_CheckedChanged" Text="Requiere Mesas y sillas" AutoPostBack="True" /></h4>
                                            </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Panel ID="PanelRequiereMesasySillas" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>Costo Mesas para 10 PAX</td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxCostoMesas" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Costo Sillas por PAX</td>
                                                        <td> <asp:TextBox ID="TextBoxCostoSillas" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Precio Mesas para 10 PAX</td>
                                                        <td> <asp:TextBox ID="TextBoxPrecioMesas" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                      <tr>
                                                        <td>Precio Sillas por PAX</td>
                                                        <td> <asp:TextBox ID="TextBoxPrecioSillas" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>

                                            </asp:Panel>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                      <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <h4>
                                                <asp:CheckBox ID="CheckBoxLlevaLogistica" Checked="false" runat="server" Text="Lleva Logistica?" /></h4>
                                            &nbsp;
                                            <h4>
                                                <asp:CheckBox ID="CheckBoxComisiona" Checked="false" runat="server" Text="Es Comisionable?" /></h4>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <h4>Sector:</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSectorDescripcion" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                  
                                  
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonAgregarSectores" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregarSectores_Click" />
                                            &nbsp;|&nbsp;<asp:Button ID="ButtonQuitarSectores" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitarSectores_Click" />
                                            <br />
                                            <br />
                                            <br />
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:GridView ID="GridViewSectores" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#ffffcc" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                            </Columns>

                                                        </asp:GridView>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" OnClick="ButtonAceptar_Click" ValidationGroup="Items" />
                                            <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>

                                        <td>&nbsp;</td>

                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">:</td>

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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
