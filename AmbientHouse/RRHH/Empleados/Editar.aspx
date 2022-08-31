<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.RRHH.Empleados.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">


    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Empleados</h3>
            <br />
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelEmpleados" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="ButtonDatosPersonales" runat="server" Text="Datos Personales" OnClick="ButtonDatosPersonales_Click" />
                    <asp:Button ID="ButtonDatosLaborales" runat="server" Text="Datos Laborales" OnClick="ButtonDatosLaborales_Click" />
                    <asp:Panel ID="PanelDatosPersonales" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>

                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Nro de Legajo:</td>
                                            <td> <asp:TextBox ID="TextBoxNroLegajo" runat="server" Width="400px" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NroLegajoRequired" runat="server" ControlToValidate="TextBoxNroLegajo" Display="Dynamic" ErrorMessage="Nro de Legajo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                          <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Apellido:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxApellidoNombre" runat="server" Width="400px" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ApellidoRequired" runat="server" ControlToValidate="TextBoxApellidoNombre" Display="Dynamic" ErrorMessage="Apellido es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Nombre:</td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNombre" runat="server" class="form-control" Width="400px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="TextBoxNombre" Display="Dynamic" ErrorMessage="Nombre es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Tipo Documento:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTipoDocumento" runat="server" class="form-control" Width="200px">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;</td>
                                            <td>Nro. Documento:</td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNroDocumento" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NroDocRequired" runat="server" ControlToValidate="TextBoxNroDocumento" Display="Dynamic" ErrorMessage="Nro. Documento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Fecha de Nacimiento:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFechaNacimiento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaNacimiento" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaNacimiento" CultureName="en-nz" />
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaNacimiento" runat="server" ControlToValidate="TextBoxFechaNacimiento" 
                                                       Display="Dynamic" ErrorMessage="Fecha Nacimiento es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>CUIL:(Sin guiones) </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCUIL" runat="server" class="form-control" Width="130px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CuilRequired" runat="server" ControlToValidate="TextBoxCUIL" Display="Dynamic" ErrorMessage="Nro. CUIL es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Domicilio:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDomicilio" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Provincia:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListProvincia" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Codigo Postal:</td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCP" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                               
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Localidad:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListLocalidad" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocalidad_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                          <tr>
                                            <td>Domicilio Legal:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDomicilioLegal" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDomicilioLegal" Display="Dynamic" ErrorMessage="Domicilio Legal es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Provincia Legal:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListProvinciaLegal" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProvinciaLegal_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Codigo Postal Legal:</td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCPLegal" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxCPLegal" Display="Dynamic" ErrorMessage="Codigo Postal Legal es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Localidad Legal:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListLocalidadLegal" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocalidadLegal_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Telefono Personal Fijo: </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxTelefonoFijo" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Telefono Personal Movil: </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxTelefonoMovil" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Mail Personal:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxMail" runat="server" Width="300px" class="form-control"></asp:TextBox>

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>


                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>


                                        <tr>
                                            <td>Observaciones:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxObservaciones" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:CheckBox ID="CheckBoxEsUsuario" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxEsUsuario_CheckedChanged" Text=" Es Usuario del Sistema?" />

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Panel ID="PanelUsuarios" runat="server">
                                                    <h3>Usuarios</h3>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <h4>Nombre de Usuario:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNombreUsuario" runat="server" class="form-control" Width="300px"></asp:TextBox>
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
                                                                <h4>Password:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxPassword" runat="server" class="form-control" Width="300px" TextMode="Password"></asp:TextBox>
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
                                                                <h4>Confirmar Password:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxConfirmarPassword" runat="server" class="form-control" Width="300px"></asp:TextBox>
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
                                                                <h4>Estado:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListEstado" runat="server" class="form-control">
                                                                </asp:DropDownList>
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
                                                                <h4>Perfiles:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListPerfiles" runat="server" class="form-control">
                                                                </asp:DropDownList>
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
                                                                <h4>Pertenece al Grupo:</h4>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListGrupo" runat="server" class="form-control" AppendDataBoundItems="True">
                                                                    <asp:ListItem Value="null">&lt;Seleccionar un Grupo&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>

                                </td>
                                <td>&nbsp;</td>

                                <tr>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                </tr>
                        </table>
                    </asp:Panel>

                    <asp:Panel ID="PanelDatosLaborales" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Fecha de Ingreso:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaIngreso" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderIngreso" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaIngreso" CultureName="en-nz" />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaIngreso" runat="server" ControlToValidate="TextBoxFechaIngreso" 
                                                       Display="Dynamic" ErrorMessage="Fecha Ingreso es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td>Situacion:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSituacion" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Departamento:
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListDepartamento" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDepartamento_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList></td>

                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>Sector:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSector" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListSector_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>

                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Tipo Empleados:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoEmpleado" runat="server" class="form-control" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>

                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>Hora Entrada:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxHoraDesde" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraDesde" TargetControlID="TextBoxHoraDesde" runat="server" Mask="99:99" AcceptAMPM="true" MaskType="Time" AutoComplete="true" />
                                </td>
                                <td>&nbsp;</td>
                                <td>Hora Salida: </td>
                                <td>
                                    <asp:TextBox ID="TextBoxHoraHasta" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHasta" runat="server" AcceptAMPM="true" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraHasta" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Mail Laboral:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxMailLaboral" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td>Telefono Fijo Laboral:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxTelLaboral" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>Celular Laboral:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxCelularLaboral" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Usa PC:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListUsaPC" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListDepartamento_SelectedIndexChanged" Width="100%">
                                        <asp:ListItem>Si</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="NroPc" runat="server" Text="Nro PC:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroPc" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Sueldo:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxSueldo" runat="server" class="form-control" Width="100px"></asp:TextBox>

                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Premio:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPremio" runat="server" class="form-control" Width="100px"></asp:TextBox>

                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>SAC:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxSAC" runat="server" class="form-control" Width="100px"></asp:TextBox>

                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                    <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click" class="btn btn-info" Text="Aceptar" ValidationGroup="Cliente" />
                    &nbsp;&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
