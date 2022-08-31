<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmbientHouse.Stock.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="jumbotron">
        <div class="container">
            <h1 class="display-4">Inventario</h1>
            <p class="lead"></p>


        </div>
    </div>
           <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            ...
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
               Nuevo Producto
            </button>
    <div class="container">

        <div class="row">

            <div class="col-sm-6">

                <div class="card w-100">
                    <div class="card-body">
                        <h5 class="card-title">Productos</h5>
                        <p class="card-text">Administrar Productos de Catering/Barras</p>
                        <a href="Productos/Index.aspx" class="btn btn-primary">Productos</a>
                    </div>
                </div>


            </div>
            <div class="col-sm-6">
                <div class="card w-100">
                    <div class="card-body">
                        <h5 class="card-title">Requerimientos</h5>
                        <p class="card-text">Administrar Requerimientos de Catering/Barras</p>
                        <a href="Requerimientos/Index.aspx" class="btn btn-primary">Requerimientos</a>
                    </div>
                </div>
            </div>


            <div aria-live="polite" aria-atomic="true" style="position: relative; min-height: 200px;">
                <!-- Position it -->
                <div style="position: absolute; top: 0; right: 0;">

                    <!-- Then put toasts within -->
                    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                            <img src="..." class="rounded mr-2" alt="...">
                            <strong class="mr-auto">Bootstrap</strong>
                            <small class="text-muted">just now</small>
                            <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="toast-body">
                            See? Just like this.
                        </div>
                    </div>

                    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">
                            <img src="..." class="rounded mr-2" alt="...">
                            <strong class="mr-auto">Bootstrap</strong>
                            <small class="text-muted">2 seconds ago</small>
                            <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="toast-body">
                            Heads up, toasts will stack automatically
                        </div>
                    </div>
                </div>
            </div>
           
       

         <%--   <div class="col-sm-12">

                <% 
                    DomainAmbientHouse.Entidades.INVENTARIO_Producto prod = new DomainAmbientHouse.Entidades.INVENTARIO_Producto();
                    DomainAmbientHouse.Servicios.AdministrativasServicios administracion = new DomainAmbientHouse.Servicios.AdministrativasServicios();

                    List<DomainAmbientHouse.Entidades.INVENTARIO_Producto> list = administracion.ListarProductos();

                    if (list.Count() > 0)
                    {
                        Response.Write("<table class=\"table\"><thead class=\"thead-dark\"><tr><th scope=\"col\">#</th><th scope=\"col\">Codigo</th><th scope=\"col\">Descripcion</th><th scope=\"col\"></th></tr> </thead><tbody>");

                        foreach (var item in list)
                        {
                            Response.Write("<tr><th scope=\"row\">" + item.Id + "</th>");
                            Response.Write("<td>" + item.Codigo + "</td>");
                            Response.Write("<td>" + item.Descripcion + "</td>");
                            Response.Write("<td> <input id=\"btnEditar\" type=\"button\" value=\"Editar\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#exampleModal\" /></td>");
                            Response.Write("</tr>");

                        }

                        Response.Write("</tbody></table>");
                    }

                %>
            </div>--%>


        </div>

    </div>
  
    <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../Boostrap4/js/popper.min.js"></script>
    <script src="../../Boostrap4/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
