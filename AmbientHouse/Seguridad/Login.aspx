<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmbientHouse.Seguridad.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ambient House Celebration</title>


    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <link href="../Content/css/Login.css" rel="stylesheet" />

</head>
<body>
    <div class="row">

        <div class="col-sm-6 col-md-4 col-md-offset-4">

            <h1 class="text-center login-title">Inicio de Sesion en Grupo Ambient</h1>

            <div class="account-wall">

                <img class="profile-img" src="../Content/Imagenes/usuarios.png" alt="" />

                <div class="container">
                    <form id="form1" runat="server" class="form-signin">
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;</td>
                                    <td>
                                        <asp:Login ID="LoginAmbient" class="form-signin" runat="server" LoginButtonText="Aceptar" OnLoggingIn="LoginAmbient_LoggingIn" TitleText="Ingrese el Usuario y el Password" Width="100%">
                                            <%--<asp:Login ID="LoginAmbient" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" LoginButtonText="Aceptar" OnLoggingIn="LoginAmbient_LoggingIn" TitleText="Ingrese el Usuario y el Password" Width="100%">--%>
                                            <%--  <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                            <TextBoxStyle Font-Size="0.8em" />
                            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />--%>
                                        </asp:Login>
                                    </td>
                                    <td>&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </div>



            </div>

        </div>

    </div>





</body>
</html>
