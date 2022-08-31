using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Grupos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.GruposItems GrupoSeleccionado
        {
            get
            {
                return Session["GrupoSeleccionado"] as DomainAmbientHouse.Entidades.GruposItems;
            }
            set
            {
                Session["GrupoSeleccionado"] = value;
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

      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            int Id = 0;

            if (Request["Id"] != null)
            {
                Id = Int32.Parse(Request["Id"].ToString());

                GrupoId = Id;
            }


            if (Id == 0)
                NuevoGrupo();
            else
                EditarGrupo(Id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarGrupo(int Id)
        {

            DomainAmbientHouse.Entidades.GruposItems Grupoitem = new DomainAmbientHouse.Entidades.GruposItems();

            Grupoitem = servicios.BuscarGruposItems(Id);

            GrupoSeleccionado = Grupoitem;

            TextBoxCodigo.Text = Grupoitem.Codigo;
            TextBoxDescripcion.Text = Grupoitem.Descripcion;
            DropDownListTipo.SelectedValue = Grupoitem.Tipo;

        }

        private void NuevoGrupo()
        {
            GrupoSeleccionado = new DomainAmbientHouse.Entidades.GruposItems();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarGrupo();
        }

        private void GrabarGrupo()
        {
            DomainAmbientHouse.Entidades.GruposItems Grupoitem = GrupoSeleccionado;

            Grupoitem.Codigo = TextBoxCodigo.Text;
            Grupoitem.Descripcion = TextBoxDescripcion.Text;
            Grupoitem.Tipo = DropDownListTipo.SelectedItem.Value.ToString();

            servicios.NuevoGrupoItem(Grupoitem);
            Response.Redirect("~/Configuracion/Grupos/Index.aspx");
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Grupos/Index.aspx");
        }
    }
}