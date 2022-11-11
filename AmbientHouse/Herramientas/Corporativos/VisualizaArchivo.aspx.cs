using DomainAmbientHouse.Servicios;
using System;
using System.Web;

namespace AmbientHouse.Herramientas.Corporativos
{
    public partial class VisualizaArchivo : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Herramientas Archivo
        {
            get { return (DomainAmbientHouse.Entidades.Herramientas)HttpContext.Current.Session["Herramienta"]; }
            set { HttpContext.Current.Session["Herramienta"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = int.Parse(Request["Id"]);
            }

            Archivo = new DomainAmbientHouse.Entidades.Herramientas();

            Archivo = servicios.TraerArchivo(id);

        }

        protected void ButtonVolverInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Default.aspx");
        }

        protected void ButtonVolverHerramientas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/Corporativos/Index.aspx");
        }
    }
}