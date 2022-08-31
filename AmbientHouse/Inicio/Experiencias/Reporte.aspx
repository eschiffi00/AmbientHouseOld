<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="AmbientHouse.Inicio.Experiencias.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte Experiencias</title>

</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <iframe height="780px" src="../CateringExperiencias.ashx" width="100%">
                    </iframe>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <p>
            <asp:LinkButton ID="LinkButtonVolver" runat="server" OnClick="LinkButtonVolver_Click">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>
