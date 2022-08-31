<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepExperiencias.aspx.cs" Inherits="AmbientHouse.RepExperiencias" %>

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
            var css = ventimp.document.createElement('link');
            css.setAttribute('href', 'Content/Css/print.css');
            css.setAttribute('rel', 'stylesheet');
            css.setAttribute('type', 'text/css');
            ventimp.document.head.appendChild(css);
        }
    </script>
    <link rel="stylesheet" type="text/css" href="Content/Css/screen.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="Content/Css/print.css" media="print" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="muestra">
            <div>
                <table id="encabezado" style="width: 100%;">
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
            <br />
            <br />
            <br />

            <div style="vertical-align: central; width: auto">
                <img src="Content/Imagenes/Diego%20capo.png" style="width: 300px;" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div style="vertical-align: central; width: auto;">
                <img src="Content/Imagenes/spices-herbs.png" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div>
            </div>
            <%--    <div id="header">
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
            <br />--%>

            <br />

            <div>
                &nbsp;
            </div>
            <%-- <div>
                <asp:Label ID="LabelExperiencia" runat="server" class="form-control" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
            </div>--%>
            <br />

          <%--  <table id="TableTipoCatering" style="width: 100%;" runat="server">
            </table>--%>
            <table id="Experiencias" style="width: 100%; border-style: none; margin: 20px 40px 40px 40px;" runat="server">
            </table>
            <h3>Por favor considerar:<br />
                Si la experiencia del servicio contratado incluyera islas, se contemplará 1 isla cada 50 personas, sumándose la próxima isla cuando superen 25 invitados más.<br />
                La variedad de las islas respetarán el orden de aparición del menú contratado. En caso de desear intercambiar una isla por otra, dicha modificación tendrá costo adicional.<br />
                Los platos principales y postres son uno a elección.<br />
                La descripción del servicio es orientativa.<br />
                Los productos podrán ser modificados y/o reemplazos por ítems similares, dependiendo la disponibilidad de insumos o materia prima del mercado.<br />
            </h3>
        </div>
        <a id="boton" href="javascript:imprSelec('muestra')">Imprimir</a>
    </form>
</body>
</html>
