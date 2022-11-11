using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Configuracion.Familias
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

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

        private int GrupoId
        {
            get
            {
                return Int32.Parse(Session["GrupoId"].ToString());
            }
            set
            {
                Session["GrupoId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Familias FamiliaSeleccionado
        {
            get
            {
                return Session["FamiliaSeleccionado"] as DomainAmbientHouse.Entidades.Familias;
            }
            set
            {
                Session["FamiliaSeleccionado"] = value;
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
            DropDownListCodigo.DataSource = servicios.ObtenerGrupos();
            DropDownListCodigo.DataTextField = "Codigo";
            DropDownListCodigo.DataValueField = "Id";
            DropDownListCodigo.DataBind();

            DropDownListCategorias.DataSource = servicios.ObtenerCategoriasItem();
            DropDownListCategorias.DataTextField = "Descripcion";
            DropDownListCategorias.DataValueField = "Id";
            DropDownListCategorias.DataBind();
        }

        private void InicializarPagina()
        {
            int grupoId = 0;
            int categoriaId = 0;

            if (Request["GrupoId"] != null && Request["CategoriaId"] != null)
            {
                grupoId = Int32.Parse(Request["GrupoId"]);
                categoriaId = Int32.Parse(Request["CategoriaId"]);

                GrupoId = grupoId;
                CategoriaId = categoriaId;
            }


            if (grupoId == 0 && categoriaId == 0)
                NuevaFamilia();
            else
                EditarFamilia(GrupoId, CategoriaId);

            SetFocus(TextBoxTitulo);
        }

        private void EditarFamilia(int GrupoId, int CategoriaId)
        {
            DomainAmbientHouse.Entidades.Familias familia = new DomainAmbientHouse.Entidades.Familias();

            familia = servicios.BuscarFamilias(GrupoId, CategoriaId);

            FamiliaSeleccionado = familia;

            DropDownListCodigo.SelectedValue = familia.GrupoId.ToString();
            DropDownListCategorias.SelectedValue = familia.CategoriaItemId.ToString();
            TextBoxTitulo.Text = familia.Titulo;
            TextBoxSubtitulo.Text = familia.Subtitulo;
            TextBoxComentario.Text = familia.Comentario;
            if (familia.Edad != null)
            {
                DropDownListEdad.SelectedValue = familia.Edad.ToString();
            }
            else
            {
                DropDownListEdad.Items.FindByText("...").Selected = true;
            }
            TextBoxFantasia.Text = familia.Fantasia;


        }

        private void NuevaFamilia()
        {
            FamiliaSeleccionado = new DomainAmbientHouse.Entidades.Familias();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Familias/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarFamilia();
        }

        private void GrabarFamilia()
        {

            DomainAmbientHouse.Entidades.Familias familia = FamiliaSeleccionado;

            familia.GrupoId = Int32.Parse(DropDownListCodigo.SelectedItem.Value.ToString());
            familia.CategoriaItemId = Int32.Parse(DropDownListCategorias.SelectedItem.Value.ToString());
            familia.Titulo = TextBoxTitulo.Text;
            familia.Subtitulo = TextBoxSubtitulo.Text;
            familia.Comentario = TextBoxComentario.Text;
            familia.Fantasia = TextBoxFantasia.Text;

            if (DropDownListEdad.SelectedItem.Value != "...")
            {
                familia.Edad = DropDownListEdad.SelectedItem.Value.ToString();
            }

            servicios.NuevaFamilia(familia);
            Response.Redirect("~/Configuracion/Familias/Index.aspx");
        }
    }
}