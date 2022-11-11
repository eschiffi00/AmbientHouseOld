using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;

namespace AmbientHouse.Configuracion.Categorias
{
    public partial class Editar : System.Web.UI.Page
    {

        EventosServicios servicios = new EventosServicios();
        AdministrativasServicios serviciosAdministrativas = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Categorias CategoriaSeleccionado
        {
            get
            {
                return Session["CategoriaSeleccionado"] as DomainAmbientHouse.Entidades.Categorias;
            }
            set
            {
                Session["CategoriaSeleccionado"] = value;
            }
        }

        private int CategoriaId
        {
            get
            {
                return Int32.Parse(Session["CategoriaId"].ToString());
            }
            set
            {
                Session["CategoriaId"] = value;
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

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CategoriaId = id;
            }


            if (id == 0)
                NuevoCategoria();
            else
                EditarCategoria(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarCategoria(int id)
        {

            DomainAmbientHouse.Entidades.Categorias categoria = new DomainAmbientHouse.Entidades.Categorias();

            categoria = serviciosAdministrativas.BuscarCategorias(id);

            CategoriaSeleccionado = categoria;


            TextBoxDescripcion.Text = categoria.Descripcion;

            if (categoria.LocacionId != null)
            {
                DropDownListLocaciones.SelectedValue = categoria.LocacionId.ToString();
            }
            if (categoria.CaracteristicaId != null)
            {
                DropDownListCaracteristicas.SelectedValue = categoria.CaracteristicaId.ToString();
            }
            if (categoria.SegmentoId != null)
            {
                DropDownListSegmentos.SelectedValue = categoria.SegmentoId.ToString();
            }
            if (categoria.SectorId != null)
            {
                DropDownListSectores.Items.Clear();
                DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(categoria.LocacionId);
                DropDownListSectores.DataTextField = "Descripcion";
                DropDownListSectores.DataValueField = "Id";
                DropDownListSectores.DataBind();


                DropDownListSectores.SelectedValue = categoria.SectorId.ToString();
            }

        }

        private void NuevoCategoria()
        {
            CategoriaSeleccionado = new DomainAmbientHouse.Entidades.Categorias();
        }

        private void CargarListas()
        {
            DropDownListCaracteristicas.DataSource = servicios.TraerCaracteristicas();
            DropDownListCaracteristicas.DataTextField = "Descripcion";
            DropDownListCaracteristicas.DataValueField = "Id";
            DropDownListCaracteristicas.DataBind();

            DropDownListLocaciones.DataSource = servicios.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();

            DropDownListSegmentos.DataSource = servicios.TraerSegmentos();
            DropDownListSegmentos.DataTextField = "Descripcion";
            DropDownListSegmentos.DataValueField = "Id";
            DropDownListSegmentos.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Categorias/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarCategoria();
        }

        private void GrabarCategoria()
        {

            int activo = Int32.Parse(ConfigurationManager.AppSettings["CategoriasActivo"].ToString()); ;



            DomainAmbientHouse.Entidades.Categorias categoria = CategoriaSeleccionado;

            categoria.Descripcion = TextBoxDescripcion.Text;
            categoria.CaracteristicaId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
            categoria.SegmentoId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
            categoria.LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
            categoria.SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
            categoria.EstadoId = activo;

            serviciosAdministrativas.NuevaCategoria(categoria);


            Response.Redirect("~/Configuracion/Categorias/Index.aspx");
        }

        protected void DropDownListLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListLocaciones.SelectedItem != null)
            {
                int seleccionado = Int32.Parse(this.DropDownListLocaciones.SelectedItem.Value.ToString());

                DropDownListSectores.Items.Clear();
                DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(seleccionado);
                DropDownListSectores.DataTextField = "Descripcion";
                DropDownListSectores.DataValueField = "Id";
                DropDownListSectores.DataBind();


            }



        }
    }
}