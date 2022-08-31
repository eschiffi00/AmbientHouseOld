<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteExperienciaOrganizador.aspx.cs" Inherits="AmbientHouse.Organizador.ReporteExperienciaOrganizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Reporte Experiencias</title>
    <script type="text/javascript">
        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 455px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div id="muestra">
            <div id="header">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style1">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Imagenes/GRUPO LAHUSEN.png" Height="156px" Width="344px" />


                        </td>
                        <td>
                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Content/Imagenes/ambient.jpg" Height="156px" Width="344px" />
                           </td>

                    </tr>


                </table>


            </div>
            <br />
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>NRO EVENTO:</td>
                        <td>
                            <asp:Label ID="LabelNroEvento" runat="server" class="form-control" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label></td>

                    </tr>
                    <tr>
                        <td>NRO PRESUPUESTO:</td>
                        <td>
                            <asp:Label ID="LabelNroPresupuesto" runat="server" class="form-control" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
                        </td>

                    </tr>

                </table>
            </div>
            <br />

            <div>
                &nbsp;
            </div>
            <div>
                <asp:Label ID="LabelExperiencia" runat="server" class="form-control" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
            </div>
            <br />

            <table id="TableTipoCatering" style="width: 100%;" runat="server">
            </table>
            <table id="Experiencias" style="width: 100%;" runat="server" class="form-control">
            </table>
          <div>
               <b> La descripción del servicio es orientativa.</b><br />
                <b>Los productos podrán ser modificados y/o reemplazos por items similares, dependiendo la disponibilidad de insumos o materia prima del mercado.</b>

            </div>
        </div>
        <a href="javascript:imprSelec('muestra')">Imprimir</a>
        <asp:LinkButton ID="LinkButtonVolver" runat="server" OnClick="LinkButtonVolver_Click">Volver</asp:LinkButton>
    </form>
</body>
</html>
