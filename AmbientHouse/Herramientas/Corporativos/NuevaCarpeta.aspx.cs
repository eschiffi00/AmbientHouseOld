using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Herramientas.Corporativos
{
    public partial class NuevaCarpeta : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

            DomainAmbientHouse.Entidades.CategoriasArchivos Categorias = new DomainAmbientHouse.Entidades.CategoriasArchivos();

            Categorias.Descripcion = TextBoxDescripcion.Text;

            servicios.NuevaCategoriaArchivo(Categorias);

            Response.Redirect("~/Herramientas/Corporativos/Index.aspx");

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/Corporativos/Index.aspx");
        }
    }
}