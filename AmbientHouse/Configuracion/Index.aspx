<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading"><h3>Configuracion</h3><br />
                    </div>
                    <div class="panel-body">

                        <asp:Panel ID="PanelConfiguracion" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    
                                    <td>   &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    
                                    <td>
                                        &nbsp;</td>
                                    
                                    <td>
                                        &nbsp;</td>

                                     <td>
                                         &nbsp;</td>
                                    
                                    <td>
                                        &nbsp;</td>
                                    
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                   
                                </tr>
                                <tr>
                                    <td></td>
                                   
                                    <td><asp:Button ID="ButtonAdministrarCategorias" runat="server" class="btn btn-info" Text="Administrar Experiencias Ambientacion" OnClick="ButtonAdministrarCategorias_Click"  /></td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTecnica" runat="server" class="btn btn-info" OnClick="ButtonAdministrarTecnica_Click" Text="Administrar Experiencias Tecnica" />
                                    </td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTipoBarras" runat="server" class="btn btn-info"  Text="Administrar Tipos de Barras" OnClick="ButtonAdministrarTipoBarras_Click" />
                                    </td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarParametros" runat="server" class="btn btn-info" OnClick="ButtonAdministrarParametros_Click" Text="Administrar Parametros" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTipoLogistica" runat="server" class="btn btn-info" OnClick="ButtonAdministrarTipoLogistica_Click" Text="Administrar Tipo Logistica" />
                                    </td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCategoriaItems" runat="server" class="btn btn-info" OnClick="ButtonAdministrarCategoriaItems_Click" Text="Administrar Categoria Items" />
                                    </td>
                                   
                                </tr>
                                 <tr>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarUnidadesNegocios" runat="server" class="btn btn-info"  Text="Administrar Undades Negocios" OnClick="ButtonAdministrarUnidadesNegocios_Click"  />
                                     </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarProveedor" runat="server" class="btn btn-info" OnClick="ButtonAdministrarProveedor_Click" Text="Administrar Proveedores" />
                                     </td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarPlanesDePago" runat="server" class="btn btn-info" OnClick="ButtonAdministrarPlanesDePago_Click" Text="Administrar Planes de Pago" />
                                     </td>
                                   
                                    <td>
                                        <asp:Button ID="ButtonAdministrarComisiones" runat="server" class="btn btn-info"  Text="Administrar Comisiones" OnClick="ButtonAdministrarComisiones_Click" />
                                     </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarLocalidades" runat="server" class="btn btn-info" OnClick="ButtonAdministrarLocalidades_Click" Text="Administrar Localidades" />
                                     </td>
                                   
                                     <td>
                                         <asp:Button ID="ButtonAdministrarExperienciasCatering" runat="server" class="btn btn-info" OnClick="ButtonAdministrarExperienciasCatering_Click" Text="Administrar Experiencias Catering" />
                                     </td>
                                   
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarRubros" runat="server" class="btn btn-info" OnClick="ButtonAdministrarRubros_Click" Text="Administrar Rubros" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarDuraciones" runat="server" class="btn btn-info" OnClick="ButtonAdministrarDuraciones_Click" Text="Administrar Duracion Evento" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarMomentosDia" runat="server" class="btn btn-info" Text="Administrar Momentos del Dia" OnClick="ButtonAdministrarMomentosDia_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarExperienciasBarras" runat="server" class="btn btn-info" OnClick="ButtonAdministrarExperienciasBarras_Click" Text="Administrar Experiencias Barras" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarItemsOrganizacion" runat="server" class="btn btn-info" OnClick="ButtonAdministrarItemsOrganizacion_Click" Text="Administrar Items Organizacion" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarItemsAdicionales" runat="server" class="btn btn-info" OnClick="ButtonAdministrarItemsAdicionales_Click" Text="Administrar Adicionales Items" />
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="ButtonAdministrarCategoriasCorporativoInformal" runat="server" class="btn btn-info" OnClick="ButtonAdministrarCategoriasCorporativoInformal_Click" Text="Administrar Experiencias Ambientacion Corporativa Informal" />
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="ButtonAdministrarConfiguracionCateringTecnica" runat="server" class="btn btn-info" OnClick="ButtonAdministrarConfiguracionCateringTecnica_Click" Text="Administrar Config. Catering/Tecnica Cotizador" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosSalones" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosSalones_Click" Text="Costos Salones Anio" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosSalonesBis" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosSalonesBis_Click" Text="Costos Salones" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosCatering" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosCatering_Click" Text="Costos Catering" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosBarras" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosBarras_Click" Text="Costos Barras" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosTecnica" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosTecnica_Click" Text="Costos Tecnica" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosAmbientacion" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosAmbientacion_Click" Text="Costos Ambientacion" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosAdicionales" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosAdicionales_Click" Text="Costos Adicionales" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosLogistica" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosLogistica_Click" Text="Costos Logistica" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosCannon" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosCannon_Click" Text="Costos Cannon" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCostosAmbientacionCI" runat="server" class="btn btn-success" OnClick="ButtonAdministrarCostosAmbientacionCI_Click" Text="Costos Ambientacion Corporativo Informal" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Volver al Inicio" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>

                            </table>
                        </asp:Panel>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
