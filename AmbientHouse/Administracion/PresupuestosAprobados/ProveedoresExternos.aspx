<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ProveedoresExternos.aspx.cs" Inherits="AmbientHouse.Administracion.PresupuestosAprobados.ProveedoresExternos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelProveedores" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="panel panel-danger">
                <div class="panel-heading">PROVEEDORES EXTERNOS</div>
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
                                <asp:Label ID="LabelFechaEvento" runat="server" Font-Bold="True"></asp:Label></h4>
                        </td>
                        <td>
                            <h3>Locacion:</h3>
                            <h4>
                                <asp:Label ID="LabelLocacion" runat="server" Font-Bold="True"></asp:Label></h4>
                        </td>
                    </tr>
                       <tr>
                    <td>
                        <h3>Hora Inicio:<asp:TextBox ID="TextBoxHoraInicio" runat="server" class="form-control" Width="200px" ReadOnly="True"></asp:TextBox>
                        </h3>
                    </td>
                    <td>
                        <h3>Hora Fin:<asp:TextBox ID="TextBoxHoraFin" runat="server" class="form-control" Width="200px" ReadOnly="True"></asp:TextBox>
                        </h3>
                    </td>
                </tr>
                </table>

                <div class="panel-heading">Datos del Cliente</div>
                <div class="panel-body">

                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <h3>Nombre:</h3>
                            </td>
                            <td>
                                <h4>
                                    <asp:Label ID="LabelCliente" runat="server" Font-Bold="True"></asp:Label></h4>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Telefono:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTelefono" runat="server" class="form-control" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Mail:</h3>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMail" runat="server" class="form-control" Width="400px" ReadOnly="True"></asp:TextBox>
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
                            <td>&nbsp;</td>

                        </tr>

                        <tr>
                            <td colspan="2">&nbsp;</td>

                        </tr>

                    </table>
                </div>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="2">

                            <asp:GridView ID="GridViewProveedoresExternos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewProveedoresExternos_RowDataBound" OnRowCommand="GridViewProveedoresExternos_RowCommand">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Proveedores Externos cargado!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProveedorExterno" HeaderText="Proveedor" SortExpression="ProveedorExterno" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rubro" HeaderText="Rubro" SortExpression="Rubro" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" HeaderStyle-Width="50px">
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Observaciones" ControlStyle-Width="500px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="300px" />
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100%">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar Observaciones" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                           
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Seguros">
                                        <ItemTemplate>

                                            <asp:ImageButton ID="ImageButtonSegurosOK" runat="server" Text="Seguros Ok" CommandName="Seguros" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                        </ItemTemplate>
                                        <ControlStyle Width="30px" />
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
        <p>

            <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Salir" />
        </p>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>



