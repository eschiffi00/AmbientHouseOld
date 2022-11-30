<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="CargarComandaNew.aspx.cs" Inherits="AmbientHouse.Administracion.PresupuestosAprobados.CargarComandaNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 241px;
        }
        .auto-style2 {
            width: 237px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

       <div class="panel panel-primary">
        <div class="panel-heading"><h3>Evento</h3></div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>
                        Nro Evento: 
                        <p>
                            <asp:Label ID="LabelNroEvento" runat="server" ></asp:Label></p>
                    </td>
                    <td>
                        Nro Presupuesto: 
                        <p>
                            <asp:Label ID="LabelNroPresupuesto" runat="server" ></asp:Label></p>

                    </td>
                    <td>
                        Fecha Evento:
                        <p>
                            <asp:Label ID="LabelFechaEvento" runat="server" ></asp:Label></p>
                    </td>
                    <td>
                        Locacion:
                        <p>
                            <asp:Label ID="LabelLocacion" runat="server" ></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ejecutivo:
                        <p>
                            <asp:Label ID="LabelVendedor" runat="server" ></asp:Label>
                        </p>
                    </td>
                    <td>
                        Organizador:
                        <p>
                            <asp:Label ID="LabelOrganizador" runat="server" ></asp:Label>
                        </p>
                    </td>
                       


                    <td>
                        Hora Inicio:
                        <p><asp:Label ID="TextBoxHoraInicio" runat="server"  Width="200px" ReadOnly="True"></asp:Label></p>
                       
                    </td>
                    <td>
                        Hora Fin:
                         <p><asp:Label ID="TextBoxHoraFin" runat="server"  Width="200px" ReadOnly="True"></asp:Label> </p>
                        
                    </td>
                </tr>
            </table>
        </div>

        <div class="panel-heading"><h3>Datos del Cliente</h3></div>
        <div class="panel-body">

            <table >
                <tr>
                    <td>
                        Nombre:
                        <p style ="font-size: 15px"><asp:Label ID="LabelCliente" runat="server" ></asp:Label></p>
                    </td>


                    <td >
                        Telefono:

                         <p><asp:Label ID="TextBoxTelefono" runat="server" Width="200px" ReadOnly="True"></asp:Label></p>
                    </td>

                    <td>
                        Mail:
                        <p><asp:Label ID="TextBoxMail" runat="server" Width="200px" ReadOnly="True"></asp:Label><p>
                    </td>

                    <%--<td>
                        Ejecutivo:
                        <p>
                            <asp:Label ID="LabelEjecutivo" runat="server" ></asp:Label></p>
                    </td>--%>
                </tr>
                <tr>
                    <td>
                        Tipo Evento:
                        <p>
                            <asp:Label ID="LabelTipoEvento" runat="server" ></asp:Label></p>
                    </td>
                    <td class="auto-style1">
                        Caracteristicas:
                        <p>
                            <asp:Label ID="LabelCaracteristicas" runat="server" ></asp:Label></p>
                    </td>
                </tr>
                <tr><td>Cantidad de Invitados</td></tr>
                <tr>
                    <td>
                        Adultos:
                        <asp:TextBox ID="TextBoxCantAdultos" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        Adolecentes:
                        <asp:TextBox ID="TextBoxAdolecentes" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        Menores entre 3 y 8:
                        <asp:TextBox ID="TextBoxMenores3y8" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        Menores de 3:
                        <asp:TextBox ID="TextBoxMenores3" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    <div class="panel panel-success">
        <div class="panel-heading">
            <h3>Personal</h3> 
        </div>
        <asp:GridView ID="GridViewPersonal" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <HeaderStyle BackColor="#0449B4"  ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <EmptyDataTemplate>
                ¡No hay Personal Asignado!  
            </EmptyDataTemplate>

            <Columns>
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="textboxCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Horario" HeaderText="Horario" SortExpression="Horario" />
            </Columns>

        </asp:GridView>
    </div>
    <div>
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3>Bebidas sin Alcohol</h3> 
            </div>
            <asp:GridView ID="GridViewBebidas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="50%">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <HeaderStyle BackColor="#0449B4"  ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No hay Bebidas Asignadas!  
                </EmptyDataTemplate>

                <Columns>
                    <asp:BoundField DataField="Detalle" HeaderText="Item" SortExpression="Item" />
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="textboxCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                         </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
         <div class="panel panel-success">
            <div class="panel-heading">
                <h3>Bebidas Alcoholicas</h3> 
            </div>
            <asp:GridView ID="GridViewBebidas2" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="50%">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <HeaderStyle BackColor="#0449B4"  ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No hay Bebidas Asignadas!  
                </EmptyDataTemplate>

                <Columns>
                    <asp:BoundField DataField="Detalle" HeaderText="Item" SortExpression="Item" />
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="textboxCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                         </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
     <div class="panel panel-success">
        <div class="panel-heading">
            <h3>Comida</h3> 
        </div>
        <asp:GridView ID="GridViewComida" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <HeaderStyle BackColor="#0449B4"  ForeColor="White" />
            <EditRowStyle BackColor="#ffffcc" />
            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
            <EmptyDataTemplate>
                ¡No hay Platos asignados a la experiencia!  
            </EmptyDataTemplate>

            <Columns>
                <asp:BoundField DataField="Detalle" HeaderText="Item" SortExpression="Item" />
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="textboxCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    <div class="panel-heading">
            <h3>Particularidades</h3> 
    </div>
    <asp:TextBox ID="TextBoxParti" runat="server" class="form-control" Width="100%" Height="100px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox>
     <div class="panel panel-primary">
        <div class="panel-heading"><h3>Logistica,Vajilla y Manteleria</h3></div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>
                        Vajilla: 
                        <p>
                            <asp:Label ID="LabelVajilla" runat="server" ></asp:Label></p>
                    </td>
                    <td>
                        Tipo: 
                        <p>
                            <asp:Label ID="LabelTipoVajilla" runat="server" ></asp:Label></p>

                    </td>
                    <td>
                        Manteleria Salon:
                        <p>
                            <asp:Label ID="LabelManSalon" runat="server" ></asp:Label></p>
                    </td>
                    <td>
                        Servilletas:
                        <p>
                            <asp:Label ID="LabelServilletas" runat="server" ></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fundas:
                        <p>
                            <asp:Label ID="LabelFundas" runat="server" ></asp:Label>
                        </p>
                    </td>
                    <td>
                        Moño/Lazo:
                        <p>
                            <asp:Label ID="LabelLazo" runat="server" ></asp:Label>
                        </p>
                    </td>
                       


                    <td>
                       Manteleria Recepcion:
                        <p><asp:Label ID="LabelManRecepcion" runat="server" class="form-control" Width="200px" ReadOnly="True"></asp:Label></p>
                       
                    </td>
                    <td>
                        Forma mesa principal:
                         <p><asp:Label ID="LabelFormamesa" runat="server" class="form-control" Width="200px" ReadOnly="True"></asp:Label> </p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
