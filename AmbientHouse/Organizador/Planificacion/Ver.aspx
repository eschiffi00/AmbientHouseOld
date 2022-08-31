<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="AmbientHouse.Organizador.Planificacion.Ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
        .auto-style1 {
            width: 268px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
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
                            <asp:Label ID="LabelFechaEvento" runat="server" Font-Bold="True"></asp:Label></h4>
                    </td>
                    <td>
                        <h3>Locacion:</h3>
                        <h4>
                            <asp:Label ID="LabelLocacion" runat="server" Font-Bold="True"></asp:Label></h4>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <h3>Motivo del Festejo:<asp:TextBox ID="TextBoxMotivo" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox>
                        </h3>
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
                  <tr>
                            <td>
                                <h3>Out:</h3>
                            </td>
                            <td>
                                
                                <asp:TextBox ID="TextBoxLocacionOtra" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox>
                                
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <h3>Direccion:</h3>
                            </td>
                            <td>
                                
                                <asp:TextBox ID="TextBoxDireccionLocacion" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox>
                                
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
                    <td>&nbsp;</td>

                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>

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
        <div class="panel-heading">
            Catering 
        </div>
        <asp:GridView ID="GridViewCatering" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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




            </Columns>

        </asp:GridView>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <h4>Bocados:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxBocados" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Islas:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxIslas" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Principal Adultos:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPrincipalAdultos" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>

                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Principal Adolescentes:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPrincipalAdolescentes" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Postre para Adultos y Adolescentes:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostreAdultosAdolescentes" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Principal Menores:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPrincipalMenores" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Postre Menores:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostreMenores" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Mesa Dulce:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMesaDulce" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Fin de Fiesta:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFindeFiesta" runat="server" class="form-control" Width="100%" ReadOnly="True" Height="100px" TextMode="MultiLine"></asp:TextBox></td>


                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>ObObservaciones:</h4>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxObservacionesCatering" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="True"></asp:TextBox></td>

            </tr>
        </table>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading">
            Barras 
        </div>
        <asp:GridView ID="GridViewBarras" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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




            </Columns>

        </asp:GridView>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <h4>Servicio de Vino y Champagne:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxVinoChampagne" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Observaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesBarras" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>

        </table>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading">Particularidades/Observaciones div>

        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <h4>Mesa Principal:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMesaPrincipal" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Manteleria:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxManteleria" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Servilletas:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxServilletas" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Sillas:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSillas" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Invitados despues de las 00Hs:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxInvitadosDespuesde00" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Cumpleanios en el Evento:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCumpleenelEvento" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Torta Alegorica:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTortaAlegorica" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Llega al Salon:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLlegaSalon" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Platos Especiales:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1PlatosEspecciales" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>ObObservaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesParticularidades" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="true"></asp:TextBox></td>
                <td>&nbsp;</td>

            </tr>
        </table>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading">Tecnica</div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td colspan="2">

                    <asp:GridView ID="GridViewTecnica" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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



                        </Columns>

                    </asp:GridView>

                </td>


            </tr>
            <tr>
                <td class="auto-style1">
                    <h4>Observaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesTecnica" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="true"></asp:TextBox></td>


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

                    <asp:GridView ID="GridViewAmbientacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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
                    <h4>ObObservaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesAmbientacion" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="true"></asp:TextBox></td>


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

                    <asp:GridView ID="GridViewAdicionales" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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
                    <h4>ObObservaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesAdicionales" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="true"></asp:TextBox></td>


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

                    <asp:GridView ID="GridViewOtros" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

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
                    <h4>ObObservaciones:</h4>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxObservacionesOtros" runat="server" class="form-control" Width="100%" Height="200px" TextMode="MultiLine" MaxLength="2000" ReadOnly="true"></asp:TextBox></td>


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

                    <asp:GridView ID="GridViewProveedoresExternos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" >

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Proveedores Externos cargado!  
                        </EmptyDataTemplate>

                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="ProveedorExterno" HeaderText="Proveedor" SortExpression="ProveedorExterno" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Rubro" HeaderText="Rubro" SortExpression="Rubro" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" SortExpression="Observaciones" HeaderStyle-Width="50px" />

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
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBoxAcreditaciones" runat="server" class="form-control" Width="100%" MaxLength="200" ReadOnly="true"></asp:TextBox></td>
                        <td class="auto-style4">
                           </td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Lista de Invitados:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxListadeInvitados" runat="server" class="form-control" Width="100%" MaxLength="200" ReadOnly="true"></asp:TextBox></td>
                        <td>
                           </td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Lista de Cocheras:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxListaCocheras" runat="server" class="form-control" Width="100%" MaxLength="200" ReadOnly="true" ></asp:TextBox></td>
                        <td>
                            </td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Layout:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxLayout" runat="server" class="form-control" Width="100%" MaxLength="2000" ReadOnly="true" Height="100px" TextMode="MultiLine" ></asp:TextBox></td>
                        <td>
                          </td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Alfombra Roja:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxAlfombraRoja" runat="server" class="form-control" Width="100%" MaxLength="200" ReadOnly="true" ></asp:TextBox></td>
                        <td>
                            <a</td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Anexo 7:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxAnexo7" runat="server" class="form-control" Width="100%" MaxLength="200" ReadOnly="true" ></asp:TextBox></td>
                        <td>
                           </td>

                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <h4>Ramo:</h4>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="DropDownListRamo" runat="server" Width="100px" class="form-control" Enabled="False">
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
                            <asp:DropDownList ID="DropDownListEscenario" runat="server" Width="100px" class="form-control" Enabled="False">
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

               

                            <asp:GridView ID="GridViewTimming" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" >

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Timming cargado!  
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Nro." SortExpression="Id"  />
                                     <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" SortExpression="HoraInicio"  />
                                     <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"  />
                                     <asp:BoundField DataField="Duracion" HeaderText="Duracion" SortExpression="Duracion"  />
                                    
                                    
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

     <div class="panel panel-danger">
        <div class="panel-heading">Archivos</div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td colspan="2">
                      

                    <asp:GridView ID="GridViewArchivo" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewArchivo_RowCommand" >

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

                             <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonDescargar" runat="server" Text="Descargar" class="btn btn-primary" CommandName="Descargar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                  
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
    <p>

        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" />

    </p></asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
