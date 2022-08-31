<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Organizador.Planificacion.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 268px;
        }

        .auto-style2 {
            height: 20px;
        }

        .auto-style3 {
            width: 268px;
            height: 39px;
        }

        .auto-style4 {
            height: 39px;
        }

        .auto-style5 {
            height: 39px;
            width: 1781px;
        }

        .auto-style6 {
            width: 1781px;
        }

        .auto-style8 {
            width: 327px;
        }

        .auto-style9 {
            height: 39px;
            width: 327px;
        }

        .auto-style12 {
            height: 39px;
            width: 145px;
        }

        .auto-style13 {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanelOrganizacion" runat="server" UpdateMode="Conditional">

        <ContentTemplate>



            <div class="panel panel-primary">
                <div class="panel-heading">Evento</div>
                <div class="panel-body">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <h3>Nro Evento: </h3>
                                <h4>
                                    <asp:Label ID="LabelNroEvento" runat="server" Font-Bold="True"></asp:Label></h4>
                            </td>
                            <td>
                                <h3>Nro Presupuesto: </h3>
                                <h4>
                                    <asp:Label ID="LabelNroPresupuesto" runat="server" Font-Bold="True"></asp:Label></h4>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Fecha Evento:</h3>
                                <h4>
                                    <asp:Label ID="LabelFechaEvento" runat="server" Font-Bold="True"></asp:Label>
                                </h4>
                            </td>
                            <td>
                                <h3>Locacion:</h3>
                                <h4>
                                    <asp:Label ID="LabelLocacion" runat="server" Font-Bold="True"></asp:Label>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Ejecutivo:</h3>
                                <h4>
                                    <asp:Label ID="LabelVendedor" runat="server" Font-Bold="True"></asp:Label>
                                </h4>
                            </td>
                            <td>
                                <h3>Organizador:</h3>
                                <h4>
                                    <asp:Label ID="LabelOrganizador" runat="server" Font-Bold="True"></asp:Label>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h3>Motivo del Festejo:<asp:TextBox ID="TextBoxMotivo" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Hora Inicio:<asp:TextBox ID="TextBoxHoraInicio" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                </h3>
                            </td>
                            <td>
                                <h3>Hora Fin:<asp:TextBox ID="TextBoxHoraFin" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Out:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxLocacionOtra" runat="server" class="form-control" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Direccion:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDireccionLocacion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonCambiarHora" runat="server" OnClick="ButtonCambiarHora_Click" Text="Cambiar Hora" class="btn btn-success" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LabelMensaje" runat="server" class="form-control" Width="100%" CssClass="text-center" Text="Label" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="panel-heading">Datos del Cliente</div>
                <div class="panel-body">

                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <h3>Nombre:</h3>
                            </td>
                            <td>
                                <h4>
                                    <asp:Label ID="LabelCliente" runat="server" Font-Bold="True"></asp:Label>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Telefono:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTelefono" runat="server" class="form-control" Width="400px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Mail:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMail" runat="server" class="form-control" Width="400px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Ejecutivo:</h3>
                            </td>
                            <td>
                                <h4>
                                    <asp:Label ID="LabelEjecutivo" runat="server" Font-Bold="True"></asp:Label></h4>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Tipo Evento:</h3>
                            </td>
                            <td>
                                <h4>
                                    <asp:Label ID="LabelTipoEvento" runat="server" Font-Bold="True"></asp:Label></h4>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Caracteristicas:</h3>
                            </td>
                            <td>
                                <h4>
                                    <asp:Label ID="LabelCaracteristicas" runat="server" Font-Bold="True"></asp:Label></h4>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Cantidad Adultos:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCantAdultos" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Cantidad Adolecentes:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxAdolecentes" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Cantidad Menores entre 3 y 8:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMenores3y8" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Cantidad Menores de 3:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMenores3" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonCambiarCantidadInvitados" runat="server" OnClick="ButtonCambiarCantidadInvitados_Click" Text="Cambiar Cantidad Invitados" class="btn btn-success" Visible="False" />
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2">&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Comentario Presupuesto:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxComentario" runat="server" class="form-control" Width="100%" ReadOnly="True" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LabelMensajeInvitados" runat="server" class="form-control" Width="100%" CssClass="text-center" Text="Label" Font-Bold="True"></asp:Label></td>

                        </tr>

                    </table>
                </div>

                <div class="panel panel-success">
                    <div class="panel-heading">
                        Barras 
                    </div>
                    <asp:GridView ID="GridViewBarras" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewBarras_RowDataBound">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Barras presupuestados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                            <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                            <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style1">
                                <h4>Servicio de Vino y Champagne:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxVinoChampagne" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonVinoChampagne" runat="server" Height="30px" Width="30px" OnClick="ImageButtonVinoChampagne_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Observaciones:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesBarras" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>
                            <td>&nbsp;</td>

                        </tr>

                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonGrabarBarras" runat="server" class="btn btn-primary" OnClick="ButtonGrabarBarras_Click" Text=" Grabar y Continuar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                    </table>
                </div>

                <div class="panel panel-success">
                    <div class="panel-heading">
                        Catering 
                    </div>
                    <asp:GridView ID="GridViewCatering" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewCatering_RowDataBound">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Catering presupuestados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                            <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                            <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style1">
                                <h4>Bocados:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxBocados" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonBocados" runat="server" OnClick="ImageButtonBocados_Click" Height="30px" Width="30px" />
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Islas:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxIslas" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonIslas" runat="server" Height="30px" Width="30px" OnClick="ImageButtonIslas_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Plato Entrada:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxEntrada" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonEntrada" runat="server" Height="30px" Width="30px" OnClick="ImageButtonEntrada_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Principal Adultos:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPrincipalAdultos" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>

                            <td>
                                <asp:ImageButton ID="ImageButtonPrincipalAdultos" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPrincipalAdultos_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Principal Adolescentes:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPrincipalAdolescentes" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonPrincipalAdolescentes" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPrincipalAdolescentes_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Principal Menores:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPrincipalMenores" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonPrincipalMenores" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPrincipalMenores_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Postre para Adultos y Adolescentes:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPostreAdultosAdolescentes" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonPostreAdultosAdolescentes" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPostreAdultosAdolescentes_Click" /></td>
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <h4>Postre Menores:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxPostreMenores" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonPostreMenores" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPostreMenores_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Mesa Dulce:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMesaDulce" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonMesaDulce" runat="server" Height="30px" Width="30px" OnClick="ImageButtonMesaDulce_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Fin de Fiesta:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxFindeFiesta" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>


                            <td>
                                <asp:ImageButton ID="ImageButtonFindeFiesta" runat="server" Height="30px" Width="30px" OnClick="ImageButtonFindeFiesta_Click" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Torta Alegorica:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTortaAlegorica" runat="server" class="form-control" Width="100%" MaxLength="600" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonTortaAlegorica" runat="server" Height="30px" Width="30px" OnClick="ImageButtonTortaAlegorica_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Platos Especiales:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1PlatosEspecciales" runat="server" class="form-control" Width="100%" MaxLength="2000" Height="300px" TextMode="MultiLine"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonPlatosEspeciales" runat="server" Height="30px" Width="30px" OnClick="ImageButtonPlatosEspeciales_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Observaciones:</h4>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBoxObservacionesCatering" runat="server" class="form-control" Width="100%" Height="300px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonGrabarCatering" runat="server" class="btn btn-primary" OnClick="ButtonGrabarCatering_Click" Text=" Grabar y Continuar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>



                <div class="panel panel-success">
                    <div class="panel-heading">Particularidades/Observaciones </div>

                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style1">
                                <h4>Mesa Principal:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMesaPrincipal" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonMesaPrincipal" runat="server" Height="30px" Width="30px" OnClick="ImageButtonMesaPrincipal_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Manteleria:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxManteleria" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonManteleria" runat="server" Height="30px" Width="30px" OnClick="ImageButtonManteleria_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Servilletas:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxServilletas" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonServilletas" runat="server" Height="30px" Width="30px" OnClick="ImageButtonServilletas_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Sillas:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSillas" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonSillas" runat="server" Height="30px" Width="30px" OnClick="ImageButtonSillas_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Invitados despues de las 00Hs:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxInvitadosDespuesde00" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonInvitadosDespuesde00" runat="server" Height="30px" Width="30px" OnClick="ImageButtonInvitadosDespuesde00_Click" /></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h4>Cumpleanios en el Evento:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCumpleenelEvento" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonCumpleenelEvento" runat="server" Height="30px" Width="30px" OnClick="ImageButtonCumpleenelEvento_Click" /></td>

                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <h4>Llega al Salon:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxLlegaSalon" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                            <td>
                                <asp:ImageButton ID="ImageButtonLlegaSalon" runat="server" Height="30px" Width="30px" OnClick="ImageButtonLlegaSalon_Click" /></td>

                        </tr>


                        <tr>
                            <td class="auto-style1">
                                <h4>Observaciones:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesParticularidades" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonGrabarParticularidades" runat="server" class="btn btn-primary" OnClick="ButtonGrabarParticularidades_Click" Text=" Grabar y Continuar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>


                <div class="panel-heading">Calendario de Reuniones</div>
                <div class="panel-body">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Se envio mail Presentacion:</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListMailPresentacionSiNo" CssClass="form-control" runat="server">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>
                                    <asp:Label ID="LabelFechaEnvioMail" runat="server" Text="Fecha Nuevo Contacto:"></asp:Label></h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxFechaMailPresentacion" runat="server" class="form-control" Width="700px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaMailPresentacion" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaMailPresentacion" TodaysDateFormat="" CssClass="black" />

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Se realizo reunion con el cliente:</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListSeRealizoReunionCliente" CssClass="form-control" runat="server">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                    </table>

                </div>
                <div class="panel-heading">Informacion Pre Evento y Armado </div>
                <div class="panel-body">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Direccion de Proveedores e Ingreso del Persona:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxContactoDireccionProveedoresIngresoLugar" runat="server" class="form-control" Width="700px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Nombre Contacto responsable del Lugar:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxContactoResponsableLugar" runat="server" class="form-control" Width="700px"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Telefono:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxContactoTelefonoLugar" runat="server" class="form-control" Width="700px"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                    </table>

                </div>
                <div class="panel-body">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Dia de Armado Logistica:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxDiaArmadoLogistica" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxDiaArmadoLogistica" TodaysDateFormat="" CssClass="black" />

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Dia Armado Salon:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxDiaArmadoSalon" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxDiaArmadoSalon" TodaysDateFormat="" CssClass="black" />

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Dia Desarmado Salon:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxDiaDesarmadoSalon" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxDiaDesarmadoSalon" TodaysDateFormat="" CssClass="black" />

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Cant. Personas Afectadas al Armado:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxCantPersonasAfectadasArmado" runat="server" class="form-control" Width="150px"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                    </table>

                </div>
                <div class="panel-body">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Hora de Armado Logistica:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxHoraArmadoLogistica" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="TextBoxHoraArmadoLogistica" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="LabelHoraArmadoLogistica" runat="server" ForeColor="Red" Text="Hora Invalida"></asp:Label></td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Hora Armado Salon:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxHoraArmadoSalon" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="TextBoxHoraArmadoSalon" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Hora Desarmado Salon:</h3>
                            </td>
                            <td>

                                <asp:TextBox ID="TextBoxHoraDesarmadoSalon" runat="server" AutoPostBack="True" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="TextBoxHoraDesarmadoSalon" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="LabelHoraArmadoSalon" runat="server" ForeColor="Red" Text="Hora Invalida"></asp:Label></td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style9">
                                <h3>Se pidio Hielo?</h3>
                            </td>
                            <td class="auto-style12">
                                <asp:ImageButton ID="ImageButtonSePidioHielo" runat="server" Width="30px" Height="30px" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesHielo" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <h3>Se pidio Mobiliario?</h3>
                            </td>
                            <td class="auto-style12">
                                <asp:ImageButton ID="ImageButtonSePidioMoviliario" runat="server" Width="30px" Height="30px" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesMoviliario" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td class="auto-style9">
                                <h3>Se pidio Logistica?</h3>
                            </td>
                            <td class="auto-style12">
                                <asp:ImageButton ID="ImageButtonSePidioLogitica" runat="server" Width="30px" Height="30px" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesLogistica" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <h3>Se pidio Manteleria?</h3>
                            </td>
                            <td class="auto-style12">
                                <asp:ImageButton ID="ImageButtonSePidioManteleria" runat="server" Width="30px" Height="30px" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxObservacionesManteleria" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </td>

                        </tr>





                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td class="auto-style13">
                                <asp:Button ID="ButtonGuardarLogistica" runat="server" class="btn btn-primary" OnClick="ButtonGuardarLogistica_Click" Text=" Grabar y Continuar" />
                            </td>
                        </tr>
                    </table>

                </div>

            </div>
            <%--     <div class="panel panel-success">
        <div class="panel-heading">Barras  <h4>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></h4></div>

        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                
            </tr>
            <tr>
                <td> <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewChecklistOrganizacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewChecklistOrganizacion_RowDataBound" >

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay clientes con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                           
                                            <asp:TemplateField HeaderStyle-Width="100px"  ControlStyle-Width="400px">
                                                <ItemTemplate>
                                                   <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                    <asp:DropDownList ID="DropDownListDescripcion" runat="server" class="form-control" Width="100%"> </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                            </asp:TemplateField>
                                           
                                        </Columns>

                                    </asp:GridView>


                                </ContentTemplate>

                            </asp:UpdatePanel></td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
               
            </tr>
        </table>
    </div>--%>


            <div class="panel panel-success">
                <div class="panel-heading">Tecnica</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="GridViewTecnica" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewTecnica_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Tecnica presupuestados!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                    <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                    <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                                    <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>

                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Observaciones:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxObservacionesTecnica" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>


                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonGrabarTecnica" runat="server" class="btn btn-primary" OnClick="ButtonGrabarTecnica_Click" Text=" Grabar y Continuar" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="panel panel-success">
                <div class="panel-heading">Ambientacion</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="GridViewAmbientacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewAmbientacion_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Ambientacion presupuestados!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                    <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                    <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                                    <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                </Columns>

                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Observaciones:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxObservacionesAmbientacion" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>


                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonGrabarAmbientacion" runat="server" class="btn btn-primary" OnClick="ButtonGrabarAmbientacion_Click" Text=" Grabar y Continuar" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="panel panel-success">
                <div class="panel-heading">Adicionales</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="GridViewAdicionales" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewAdicionales_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Adicionales presupuestados!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Adicional" SortExpression="ProductoDescripcion" />
                                    <asp:BoundField DataField="CantidadAdicional" HeaderText="Cant." SortExpression="CantidadAdicional" />
                                    <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>

                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Observaciones:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxObservacionesAdicionales" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>


                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonGrabarAdicionales" runat="server" class="btn btn-primary" OnClick="ButtonGrabarAdicionales_Click" Text=" Grabar y Continuar" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="panel panel-success">
                <div class="panel-heading">OTRAS UNIDADES DE NEGOCIOS CONTRATADAS A TRAVES NUESTRO</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="GridViewOtros" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewOtros_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Items presupuestados!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" />
                                    <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                    <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                    <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                                    <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEstadoProveedor" runat="server" Height="25px" Width="25px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style2"></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Observaciones:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxObservacionesOtros" runat="server" class="form-control" Width="100%" Height="50px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox></td>


                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonGrabarOrganizacion" runat="server" class="btn btn-primary" OnClick="ButtonGrabarOrganizacion_Click" Text=" Grabar y Continuar" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="panel panel-danger">
                <div class="panel-heading">PROVEEDORES EXTERNOS</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Proveedor:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxProveedorExterno" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Rubro:</h4>
                                    </td>
                                    <td>
                                        <%--<asp:TextBox ID="TextBoxProveedorRubro" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>--%>
                                        <asp:DropDownList ID="DropDownListRubro" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="Ambientacion">Ambientacion</asp:ListItem>
                                            <asp:ListItem Value="DJ">DJ</asp:ListItem>
                                            <asp:ListItem Value="Foto y Video">Foto y Video</asp:ListItem>
                                            <asp:ListItem Value="Shows - Bandas - Aminaciones">Shows - Bandas - Aminaciones</asp:ListItem>
                                            <asp:ListItem Value="Tecnica">Tecnica</asp:ListItem>
                                            <asp:ListItem Value="CABINAS - CARRETINOS - FOODTRUCKS">CABINAS - CARRETINOS - FOODTRUCKS</asp:ListItem>
                                            <asp:ListItem Value="OTROS">OTROS</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Contacto:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxProveedorContacto" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Telefono:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxProveedorTelefono" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Correo:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxProveedorCorreo" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Observaciones:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxProveedorObservaciones" runat="server" CssClass="form-control" Width="100%" MaxLength="2000" Height="100px" TextMode="MultiLine"></asp:TextBox></td>

                                </tr>
                            </table>




                            <p>
                                <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" class="btn btn-success" OnClick="ButtonAgregar_Click" />
                            </p>
                            <asp:GridView ID="GridViewProveedoresExternos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewProveedoresExternos_RowCommand" OnRowDataBound="GridViewProveedoresExternos_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Proveedores Externos cargado!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" HeaderStyle-Width="50px" />
                                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Proveedor" ControlStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxProveedor" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Rubro" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxRubro" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <%--   <asp:DropDownList ID="DropDownListRubro" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Ambientacion">Ambientacion</asp:ListItem>
                                                <asp:ListItem Value="DJ">DJ</asp:ListItem>
                                                <asp:ListItem Value="Foto y Video">Foto y Video</asp:ListItem>
                                                <asp:ListItem Value="Tecnica">Tecnica</asp:ListItem>
                                                <asp:ListItem Value="CABINAS - CARRETINOS - FOODTRUCKS">CABINAS - CARRETINOS - FOODTRUCKS</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Contacto" ControlStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxContacto" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Telefono" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Correo" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Observaciones" ControlStyle-Width="500px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Seguros" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Image ID="ImageSeguros" runat="server" Width="30px" Height="30px" />
                                        </ItemTemplate>
                                        <ControlStyle Width="30px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonActualizar" runat="server" Text="Editar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                           
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonQuitar" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style2"></td>

                    </tr>
                </table>
            </div>

            <div class="panel panel-success">
                <div class="panel-heading">CHECKLIST </div>

                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style3">
                            <h4>Acreditaciones a Cargo de:</h4>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="TextBoxAcreditaciones" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                        <td class="auto-style4">
                            <asp:ImageButton ID="ImageButtonAcreditaciones" runat="server" Height="30px" Width="30px" OnClick="ImageButtonAcreditaciones_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Lista de Invitados:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxListadeInvitados" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ImageButtonListaInvitados" runat="server" Height="30px" Width="30px" OnClick="ImageButtonListaInvitados_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Lista de Cocheras:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxListaCocheras" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ImageButtonListaCocheras" runat="server" Height="30px" Width="30px" OnClick="ImageButtonListaCocheras_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Layout:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxLayout" runat="server" class="form-control" Width="100%" MaxLength="2000" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ImageButtonLayout" runat="server" Height="30px" Width="30px" OnClick="ImageButtonLayout_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Alfombra Roja:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxAlfombraRoja" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ImageButtonAlfombraRoja" runat="server" Height="30px" Width="30px" OnClick="ImageButtonAlfombraRoja_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Anexo 7:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBoxAnexo7" runat="server" class="form-control" Width="100%" MaxLength="200"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ImageButtonAnexo7" runat="server" Height="30px" Width="30px" OnClick="ImageButtonAnexo7_Click" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Ramo:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="DropDownListRamo" runat="server" Width="100px" class="form-control">
                                <asp:ListItem>NO</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Escenario:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="DropDownListEscenario" runat="server" Width="100px" class="form-control">
                                <asp:ListItem>NO</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                            </asp:DropDownList></td>

                        <td></td>

                    </tr>
                </table>
            </div>

            <div class="panel panel-danger">
                <div class="panel-heading">Timming</div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Horario de Inicio:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTimmingHoraInicio" runat="server" CssClass="form-control" Width="150px" MaxLength="5"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraInicio" TargetControlID="TextBoxTimmingHoraInicio" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />

                                        <asp:RequiredFieldValidator ID="HoraInicioRequiredFieldValidator" runat="server" ControlToValidate="TextBoxTimmingHoraInicio" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Timming"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Descripcion:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTimmingDescripcion" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimmingDescripcion" runat="server" ControlToValidate="TextBoxTimmingDescripcion" Display="Dynamic" ErrorMessage="Descripcion del Timming es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Timming"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <h4>Duracion:</h4>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTimmingDuracion" runat="server" CssClass="form-control" Width="150px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>

                            <p>
                                <asp:Button ID="ButtonAgregarTimming" runat="server" Text="Agregar" class="btn btn-success" OnClick="ButtonAgregarTimming_Click" ValidationGroup="Timming" />
                            </p>

                            <asp:GridView ID="GridViewTimming" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewTimming_RowCommand" OnRowDataBound="GridViewTimming_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Timming cargado!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" HeaderStyle-Width="50px" />
                                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Hora Inicio:" ControlStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxHoraInicio" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraInicio" TargetControlID="TextBoxHoraInicio" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />

                                            <asp:RequiredFieldValidator ID="HoraInicioRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraInicio" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="TimmingEditar"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Descripcion:" ControlStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimmingDescripcion" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion del Timming es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="TimmingEditar"></asp:RequiredFieldValidator>

                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Duracion:" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxDuracion" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonActualizar" runat="server" Text="Editar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ValidationGroup="TimmingEditar" /></td>
                                               
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonQuitar" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>



                            </asp:GridView>

                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style2"></td>

                    </tr>
                </table>
            </div>



            <p>

                <asp:Button ID="ButtonGrabar" runat="server" class="btn btn-primary" Text="Grabar" OnClick="ButtonGrabar_Click" />
                &nbsp;|&nbsp;
                <asp:Button ID="ButtonImprimir" runat="server" Text="Imprimir" class="btn btn-danger" OnClick="ButtonImprimir_Click" />
                &nbsp;|&nbsp;
                <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />

            </p>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-danger">
        <div class="panel-heading">Archivos</div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td colspan="2">

                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style1">
                                <h4>Descripcion:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxArchivoDescripcion" runat="server" CssClass="form-control" Width="100%" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorArchivoDescripcion" runat="server" ControlToValidate="TextBoxArchivoDescripcion" Display="Dynamic" ErrorMessage="Descripcion del Archivo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Archivo"></asp:RequiredFieldValidator>

                            </td>

                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <h4>Archivo:</h4>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUploadArchivo" runat="server" />
                            </td>

                        </tr>

                    </table>

                    <p>
                        <asp:Button ID="ButtonAgregarArchivo" runat="server" Text="Agregar" class="btn btn-success" ValidationGroup="Archivo" OnClick="ButtonAgregarArchivo_Click" />

                    </p>

                    <asp:GridView ID="GridViewArchivo" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewArchivo_RowCommand">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Archivos cargados!  
                        </EmptyDataTemplate>

                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Desripcion" HeaderText="Descripcion" SortExpression="Desripcion" />
                            <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo" SortExpression="NombreArchivo" />
                            <asp:BoundField DataField="CreateFecha" HeaderText="Ultima Actualizacion" SortExpression="CreateFecha" />

                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:FileUpload ID="FileUploadArchivoEditar" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="300px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEditar" runat="server" Text="Editar" class="btn btn-warning" CommandName="EditarArchivo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                            
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonDescargar" runat="server" Text="Descargar" class="btn btn-primary" CommandName="Descargar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonQuitar" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>



                    </asp:GridView>

                </td>

            </tr>

        </table>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
