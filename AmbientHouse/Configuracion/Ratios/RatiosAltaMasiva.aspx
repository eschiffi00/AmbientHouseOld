﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="RatiosAltaMasiva.aspx.cs" Inherits="AmbientHouse.Configuracion.AbmItems.RatiosAltaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Css/NuevaArc.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/resizecolumns/jquery.resizableColumns.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/Css/Recursos/Botones/BotonSlide.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/resizecolumns/jquery.resizableColumns.min.js" type="text/javascript"></script>
    

    <script>

        //////////////////////////////////
        //////IMPORTADOR DE ARCHIVOS/////
        ///////////////////////////////

        $(document).ready(function () {
            // 
            $("#ov-container1").click(function () {
                FakeClickUpload()  
            });


            $("#ov-container2").click(function () {
                FakeClickImportar()
            });
            $("#ov-container3").click(function () {
                FakeClickConfirmar()
            });


        });
        function FakeClickImportar() {
            $('[Id$=btnImportar]')[0].click();
        }
        function FakeClickUpload() {
            $('[Id$=btnSubirArchivo]')[0].click();
        }
        function FakeClickConfirmar() {
            $('[Id$=btnConfirmar]')[0].click();
        }
        function FakeTextBox() {
            var texto = $('[Id$=btnSubirArchivo]')[0].value ? $('[Id$=btnSubirArchivo]')[0].value : "";
            var texto2 = texto.split("\\");
            texto = texto2[texto2.length - 1];
            $('#ov-texto-archivo').html(texto);
            
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
        <asp:TextBox runat="server" ID="searchpanelstate" Text="invisible" CssClass="invisible" ClientIDMode="Static"></asp:TextBox>
        <div class="col-8">
            <h4 class="ml-3 mb-4">Alta Masiva de Items &nbsp;
            </h4>
        </div>
        <div class="col-8">
            <div class ="fileupload-container">
                <a  class="ov-btn-slide-right" id="ov-container1">
                    <asp:FileUpload ID="btnSubirArchivo" style="display:none" Width="400px" runat="server" onchange="FakeTextBox()" />Seleccione un Archivo
                </a>
                <div class ="ov-texto-archivo">
                    <p id="ov-texto-archivo"></p>
                </div>
                <a  class="ov-btn-slide-right" id="ov-container2">
                    <asp:Button ID="btnImportar"  runat="server" class="ov-asp" Text="XXXXXXXXXXXXX" OnClick="btnImportar_Click"
                         style="width: auto" />Subir Archivo
                </a>
            </div>
            <div>
                <a  class="ov-btn-slide-right" id="ov-container3">
                    <asp:Button ID="btnConfirmar"  runat="server" class="ov-asp" Text="XXXXXXXXXXXXX" OnClick="btnConfirmar_Click"
                         style="width: auto" />Confirmar
                </a>
            </div>
            <br />
            <div class="mensaje">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay registros!" 
                Height="25px">
                <RowStyle Width="200px" />
                <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="1px" ForeColor="#003300" />
                <HeaderStyle BackColor="#47B449" ForeColor="#000000" BorderColor="#333333" BorderStyle="Solid" 
                    BorderWidth="1px" VerticalAlign="Top" Width="200px"  Wrap="True" />
              
            </asp:GridView>
        </div>
</asp:Content>

