using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Herramientas.Corporativos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Herramientas HerramientaSeleccionado
        {
            get
            {
                return Session["HerramientaSeleccionado"] as DomainAmbientHouse.Entidades.Herramientas;
            }
            set
            {
                Session["HerramientaSeleccionado"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                InicializarPagina();
                CargarListas();
            }

        }

        private void CargarListas()
        {
            DropDownListCategorias.DataSource = servicios.ObtenerCategoriasArchivos();
            DropDownListCategorias.DataTextField = "Descripcion";
            DropDownListCategorias.DataValueField = "Id";
            DropDownListCategorias.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);
            }


            if (id == 0)
                NuevaHerramienta();


            SetFocus(TextBoxDescripcion);
        }




        private void NuevaHerramienta()
        {
            HerramientaSeleccionado = new DomainAmbientHouse.Entidades.Herramientas();
        }



        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/Corporativos/Index.aspx");
        }


        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Herramientas herramienta = HerramientaSeleccionado;

            herramienta.Descripcion = TextBoxDescripcion.Text;
            herramienta.Archivo = FileUploadArchivo.FileBytes;
            herramienta.ExtencionArchivo = System.IO.Path.GetExtension(FileUploadArchivo.FileName);

            if (DropDownListCategorias.SelectedItem != null)
            {
                herramienta.CategoriaArchivoId = Int32.Parse(DropDownListCategorias.SelectedItem.Value.ToString());
            }

            servicios.GrabarHerramientas(herramienta);
            Response.Redirect("~/Herramientas/Corporativos/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

    }
}