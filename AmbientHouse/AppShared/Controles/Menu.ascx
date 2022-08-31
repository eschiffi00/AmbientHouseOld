<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="AmbientHouse.App_Shared.Controles.Menu" %>

<link href="../../Content/Css/Style.css" rel="stylesheet" />

<style>
.nav-link[data-toggle].collapsed:after {
    content: "▾";
}
.nav-link[data-toggle]:not(.collapsed):after {
    content: "▴";
}

</style>

   
     <asp:Menu ID="MenuPrincipal" runat="server" 
        Orientation="Vertical"
        Height="100%">
    </asp:Menu>


<% 
    //Response.Write("<nav class=\"navbar navbar-expand-lg navbar-dark bg-dark\">");
    //Response.Write("<a class=\"navbar-brand\" href=\"#\">Ambient</a>");
    //Response.Write("<button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navbarNavAltMarkup\" aria-controls=\"navbarNavAltMarkup\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">");
    //Response.Write("<span class=\"navbar-toggler-icon\"></span>");
    //Response.Write("</button>");
    //Response.Write("<div class=\"collapse navbar-collapse\" id=\"navbarNavAltMarkup\">");
    //Response.Write("<div class=\"navbar-nav\">");
    //Response.Write("<a class=\"nav-item nav-link active\" href=\"#\">Home <span class=\"sr-only\">(current)</span></a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Ventas</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Organizacion</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Operaciones</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Administracion</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Compras</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Configuracion</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">RRHH</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Reportes</a>");
    //Response.Write("<a class=\"nav-item nav-link\" href=\"#\">Sistemas</a>");
    //Response.Write("</div>");
    //Response.Write("</div>");
    //Response.Write("</nav>");
    
    
//Response.Write("<div class=\"container-fluid\">");
//    Response.Write("<div class=\"row\">");
//        Response.Write("<div class=\"col-2 collapse show d-md-flex bg-light pt-2 pl-0 min-vh-100\" id=\"sidebar\">");
//            Response.Write("<ul class=\"nav flex-column flex-nowrap overflow-hidden\">");
//                Response.Write("<li class=\"nav-item\">");
//                    Response.Write("<a class=\"nav-link text-truncate\" href=\"#\"><i class=\"fa fa-home\"></i> <span class=\"d-none d-sm-inline\">Overview</span></a>");
//                Response.Write("</li>");
//                Response.Write("<li class=\"nav-item\">");
//                    Response.Write("<a class=\"nav-link collapsed text-truncate\" href=\"#submenu1\" data-toggle=\"collapse\" data-target=\"#submenu1\"><i class=\"fa fa-table\"></i> <span class=\"d-none d-sm-inline\">Reports</span></a>");
//                    Response.Write("<div class=\"collapse\" id=\"submenu1\" aria-expanded=\"false\">");
//                        Response.Write("<ul class=\"flex-column pl-2 nav\">");
//                            Response.Write("<li class=\"nav-item\"><a class=\"nav-link py-0\" href=\"#\"><span>Orders</span></a></li>");
//                            Response.Write("<li class=\"nav-item\">");
//                                Response.Write("<a class=\"nav-link collapsed py-1\" href=\"#submenu1sub1\" data-toggle=\"collapse\" data-target=\"#submenu1sub1\"><span>Customers</span></a>");
//                                Response.Write("<div class=\"collapse\" id=\"submenu1sub1\" aria-expanded=\"false\">");
//                                    Response.Write("<ul class=\"flex-column nav pl-4\">");
//                                        Response.Write("<li class=\"nav-item\">");
//                                            Response.Write("<a class=\"nav-link p-1\" href=\"#\">");
//                                                Response.Write("<i class=\"fa fa-fw fa-clock-o\"></i> Daily </a>");
//                                        Response.Write("</li>");
//                                        Response.Write("<li class=\"nav-item\">");
//                                            Response.Write("<a class=\"nav-link p-1\" href=\"#\">");
//                                                Response.Write("<i class=\"fa fa-fw fa-dashboard\"></i> Dashboard </a>");
//                                        Response.Write("</li>");
//                                        Response.Write("<li class=\"nav-item\">");
//                                            Response.Write("<a class=\"nav-link p-1\" href=\"#\">");
//                                                Response.Write("<i class=\"fa fa-fw fa-bar-chart\"></i> Charts </a>");
//                                        Response.Write("</li>");
//                                        Response.Write("<li class=\"nav-item\">");
//                                            Response.Write("<a class=\"nav-link p-1\" href=\"#\">");
//                                                Response.Write("<i class=\"fa fa-fw fa-compass\"></i> Areas </a>");
//                                        Response.Write("</li>");
//                                    Response.Write("</ul>");
//                                Response.Write("</div>");
//                            Response.Write("</li>");
//                        Response.Write("</ul>");
//                    Response.Write("</div>");
//                Response.Write("</li>");
//                Response.Write("<li class=\"nav-item\"><a class=\"nav-link text-truncate\" href=\"#\"><i class=\"fa fa-bar-chart\"></i> <span class=\"d-none d-sm-inline\">Analytics</span></a></li>");
//                Response.Write("<li class=\"nav-item\"><a class=\"nav-link text-truncate\" href=\"#\"><i class=\"fa fa-download\"></i> <span class=\"d-none d-sm-inline\">Export</span></a></li>");
//            Response.Write("</ul>");
//        Response.Write("</div>");
//        Response.Write("<div class=\"col pt-2\">");
//            Response.Write("<h2>");
//                Response.Write("<a href=\"\" data-target=\"#sidebar\" data-toggle=\"collapse\" class=\"d-md-none\"><i class=\"fa fa-bars\"></i></a> Content </h2>");
//            Response.Write("<h6 class=\"hidden-sm-down\">Shrink page width to see sidebar collapse</h6>");
//            Response.Write("<p>Codeply editor wolf moon retro jean shorts chambray sustainable roof party. Shoreditch vegan artisan Helvetica. Tattooed Codeply Echo Park Godard kogi, next level irony ennui twee squid fap selvage. Meggings flannel Brooklyn literally small batch, mumblecore PBR try-hard kale chips. Brooklyn vinyl lumbersexual bicycle rights, viral fap cronut leggings squid chillwave pickled gentrify mustache. 3 wolf moon hashtag church-key Odd Future. Austin messenger bag normcore, Helvetica Williamsburg sartorial tote bag distillery Portland before they sold out gastropub taxidermy Vice.</p>");
//        Response.Write("</div>");
//    Response.Write("</div>");
//Response.Write("</div>");
%>      