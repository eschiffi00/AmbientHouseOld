using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();

        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.Locaciones LocacionSeleccionada
        {
            get
            {
                return Session["LocacionSeleccionada"] as DomainAmbientHouse.Entidades.Locaciones;
            }
            set
            {
                Session["LocacionSeleccionada"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Sectores> ListSectoresSeleccionada
        {
            get
            {
                return Session["ListSectoresSeleccionada"] as List<DomainAmbientHouse.Entidades.Sectores>;
            }
            set
            {
                Session["ListSectoresSeleccionada"] = value;
            }
        }

        private int LocacionId
        {
            get
            {
                return Int32.Parse(Session["LocacionId"].ToString());
            }
            set
            {
                Session["LocacionId"] = value;
            }
        }

        private bool isEditable
        {
            get
            {
                return bool.Parse(Session["isEditable"].ToString());
            }
            set
            {
                Session["isEditable"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListSectoresSeleccionada = new List<DomainAmbientHouse.Entidades.Sectores>();

                LabelErrores.Visible = false;
                LabelSalonRepetido.Visible = false;
                CheckBoxRequiereMesasySillas.Checked = false;

                PanelRequiereMesasySillas.Visible = false;

                CargarListas();
                InicializarPagina();


            }
        }

        private void CargarListas()
        {
            DropDownListLocalidades.DataSource = servicios.ObtenerLocalidades();
            DropDownListLocalidades.DataTextField = "Descripcion";
            DropDownListLocalidades.DataValueField = "Id";
            DropDownListLocalidades.DataBind();
        }


        private void InicializarPagina()
        {
            int Id = 0;

            if (Request["Id"] != null)
            {
                Id = Int32.Parse(Request["Id"].ToString());

                LocacionId = Id;
            }


            if (Id == 0)
            {
                NuevaLocacion();
                isEditable = false;
            }
            else
            {
                EditarLocacion(Id);
                isEditable = true;
            }

            SetFocus(TextBoxDescripcion);
        }

        private void EditarLocacion(int Id)
        {
            DomainAmbientHouse.Entidades.Locaciones Locacion = new DomainAmbientHouse.Entidades.Locaciones();

            Locacion = servicios.BuscarLocaciones(Id);

            LocacionSeleccionada = Locacion;


            TextBoxDescripcion.Text = Locacion.Descripcion;
            DropDownListTipoLocacion.SelectedValue = Locacion.TipoLocacion.Trim().ToString();

            if (Locacion.CapacidadFormal != null) TextBoxCapacidadFormal.Text = Locacion.CapacidadFormal.ToString();
            if (Locacion.CapacidadInformal != null) TextBoxCapacidadInformal.Text = Locacion.CapacidadInformal.ToString();
            if (Locacion.CapacidadAuditorio != null) TextBoxCapacidadAuditorio.Text = Locacion.CapacidadAuditorio.ToString();



            DropDownListAireLibre.SelectedValue = (Locacion.AireLibre != null ? Locacion.AireLibre.Trim().ToString() : "SI");
            DropDownListEstacionamiento.SelectedValue = (Locacion.Estacionamiento != null ? Locacion.Estacionamiento.Trim().ToString() : "SI");
            DropDownListVerde.SelectedValue = (Locacion.Verde != null ? Locacion.Verde.Trim().ToString() : "SI");


            if (Locacion.UsoCocina != null) TextBoxUsoCocina.Text = Locacion.UsoCocina.ToString();
            if (Locacion.Cannon != null) TextBoxCannon.Text = Locacion.Cannon.ToString();
            if (Locacion.CannonBarra != null) TextBoxCannonBarra.Text = Locacion.CannonBarra.ToString();


            if (Locacion.TipoCannonCatering == "Persona")
                RadioButtonCannonPorPersonaCatering.Checked = true;
            else if (Locacion.TipoCannonCatering == "Porcentaje")
                RadioButtonCannonPorcentajeCatering.Checked = true;
            else
                RadioButtonCannonValorAbsolutoCatering.Checked = true;

            TextBoxCannon.Text = Locacion.Cannon.ToString();

            if (Locacion.TipoCannonBarra == "Persona")
                RadioButtonCannonPorPersonaBarra.Checked = true;
            else if (Locacion.TipoCannonBarra == "Porcentaje")
                RadioButtonCannonPorcentajeBarra.Checked = true;
            else
                RadioButtonCannonValorAbsolutoBarra.Checked = true;


            TextBoxCannonBarra.Text = Locacion.CannonBarra.ToString();

            if (Locacion.TipoCannonAmbientacion == "Persona")
                RadioButtonCannonPorPersonaAmbientacion.Checked = true;
            else if (Locacion.TipoCannonAmbientacion == "Porcentaje")
                RadioButtonCannonPorcentajeAmbientacion.Checked = true;
            else
                RadioButtonCannonValorAbsolutoAmbientacion.Checked = true;


            TextBoxCannonAmbientacion.Text = Locacion.CannonAmbientacion.ToString();


            TextBoxDireccion.Text = Locacion.Direccion;
            TextBoxMail.Text = Locacion.Mail;
            TextBoxTel.Text = Locacion.Telefono;
            TextBoxWeb.Text = Locacion.web;
            TextBoxComentarios.Text = Locacion.Comentarios;

            if (Locacion.Comisiona == "S")
                CheckBoxComisiona.Checked = true;
            else
                CheckBoxComisiona.Checked = false;

            if (Locacion.TieneLogistica == "S")
                CheckBoxLlevaLogistica.Checked = true;
            else
                CheckBoxLlevaLogistica.Checked = false;


            CheckBoxRequiereMesasySillas.Checked = Locacion.RequiereMesasSillas;

            if (Locacion.RequiereMesasSillas)
            {
                PanelRequiereMesasySillas.Visible = Locacion.RequiereMesasSillas;

                if (Locacion.CostoMesas > 0 || Locacion.CostoMesas != null)
                    TextBoxCostoMesas.Text = Locacion.CostoMesas.ToString();

                if (Locacion.CostoSillas > 0 || Locacion.CostoSillas != null)
                    TextBoxCostoSillas.Text = Locacion.CostoSillas.ToString();

                if (Locacion.PrecioMesas > 0 || Locacion.PrecioMesas != null)
                    TextBoxPrecioMesas.Text = Locacion.PrecioMesas.ToString();

                if (Locacion.PrecioSillas > 0 || Locacion.PrecioSillas != null)
                    TextBoxPrecioSillas.Text = Locacion.PrecioSillas.ToString();

            }

            DropDownListLocalidades.SelectedValue = Locacion.LocalidadId.ToString();


            ListSectoresSeleccionada = serviciosEventos.BuscarSectoresPorLocacion(Locacion.Id);

            GridViewSectores.DataSource = ListSectoresSeleccionada.ToList();
            GridViewSectores.DataBind();

            UpdatePanelLocaciones.Update();

        }

        private void NuevaLocacion()
        {
            LocacionSeleccionada = new DomainAmbientHouse.Entidades.Locaciones();
        }

        private void GrabarLocaciones()
        {
            DomainAmbientHouse.Entidades.Locaciones Locacion = LocacionSeleccionada;


            Locacion.Descripcion = TextBoxDescripcion.Text;
            Locacion.TipoLocacion = DropDownListTipoLocacion.SelectedItem.Value.ToString();

            if (cmd.IsNumeric(TextBoxCapacidadFormal.Text)) Locacion.CapacidadFormal = Int32.Parse(TextBoxCapacidadFormal.Text);
            if (cmd.IsNumeric(TextBoxCapacidadInformal.Text)) Locacion.CapacidadInformal = Int32.Parse(TextBoxCapacidadInformal.Text);
            if (cmd.IsNumeric(TextBoxCapacidadAuditorio.Text)) Locacion.CapacidadAuditorio = Int32.Parse(TextBoxCapacidadAuditorio.Text);

            Locacion.Verde = DropDownListVerde.SelectedItem.Value;
            Locacion.AireLibre = DropDownListAireLibre.SelectedItem.Value;
            Locacion.Estacionamiento = DropDownListEstacionamiento.SelectedItem.Value;

            if (cmd.IsNumeric(TextBoxUsoCocina.Text)) Locacion.UsoCocina = double.Parse(TextBoxUsoCocina.Text);
            if (cmd.IsNumeric(TextBoxCannon.Text)) Locacion.Cannon = double.Parse(TextBoxCannon.Text);
            if (cmd.IsNumeric(TextBoxCannonBarra.Text)) Locacion.CannonBarra = double.Parse(TextBoxCannonBarra.Text);

            Locacion.Direccion = TextBoxDireccion.Text;
            Locacion.Mail = TextBoxMail.Text;
            Locacion.Telefono = TextBoxTel.Text;
            Locacion.web = TextBoxWeb.Text;
            Locacion.Comentarios = TextBoxComentarios.Text;

            if (RadioButtonCannonPorPersonaCatering.Checked)
                Locacion.TipoCannonCatering = "Persona";
            else if (RadioButtonCannonPorcentajeCatering.Checked)
                Locacion.TipoCannonCatering = "Porcentaje";
            else
                Locacion.TipoCannonCatering = "Fijo";

            Locacion.Cannon = (TextBoxCannon.Text == "" ? 0 : double.Parse(TextBoxCannon.Text));

            if (RadioButtonCannonPorPersonaBarra.Checked)
                Locacion.TipoCannonBarra = "Persona";
            else if (RadioButtonCannonPorcentajeBarra.Checked)
                Locacion.TipoCannonBarra = "Porcentaje";
            else
                Locacion.TipoCannonBarra = "Fijo";

            Locacion.CannonBarra = (TextBoxCannonBarra.Text == "" ? 0 : double.Parse(TextBoxCannonBarra.Text));

            if (RadioButtonCannonPorPersonaAmbientacion.Checked)
                Locacion.TipoCannonAmbientacion = "Persona";
            else if (RadioButtonCannonPorcentajeAmbientacion.Checked)
                Locacion.TipoCannonAmbientacion = "Porcentaje";
            else
                Locacion.TipoCannonAmbientacion = "Fijo";

            Locacion.CannonAmbientacion = (TextBoxCannonAmbientacion.Text == "" ? 0 : double.Parse(TextBoxCannonAmbientacion.Text));

            Locacion.LocalidadId = Int32.Parse(DropDownListLocalidades.SelectedItem.Value);


            Locacion.RequiereMesasSillas = CheckBoxRequiereMesasySillas.Checked;

            if (cmd.IsNumeric(TextBoxCostoMesas.Text))
                Locacion.CostoMesas = cmd.ValidarImportes(TextBoxCostoMesas.Text);

            if (cmd.IsNumeric(TextBoxCostoSillas.Text))
                Locacion.CostoSillas = cmd.ValidarImportes(TextBoxCostoSillas.Text);

            if (cmd.IsNumeric(TextBoxPrecioSillas.Text))
                Locacion.PrecioSillas = cmd.ValidarImportes(TextBoxPrecioSillas.Text);

            if (cmd.IsNumeric(TextBoxPrecioMesas.Text))
                Locacion.PrecioMesas = cmd.ValidarImportes(TextBoxPrecioMesas.Text);




            if (CheckBoxComisiona.Checked)
                Locacion.Comisiona = "S";
            else
                Locacion.Comisiona = "N";

            if (CheckBoxLlevaLogistica.Checked)
                Locacion.TieneLogistica = "S";
            else
                Locacion.TieneLogistica = "N";

            servicios.NuevaLocacion(Locacion, ListSectoresSeleccionada);

            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
                GrabarLocaciones();
        }

        private bool Validar()
        {
            LabelSalonRepetido.Visible = false;

            if (!isEditable)
            {
                List<DomainAmbientHouse.Entidades.Locaciones> loc = servicios.ObtenerLocaciones();

                if (loc.Where(o => o.Descripcion.ToLower().Equals(TextBoxDescripcion.Text.ToLower())).Count() == 1)
                {
                    LabelSalonRepetido.Text = "La Locacion ya Existe.";
                    LabelSalonRepetido.Visible = true;
                    return false;
                }
            }
            return true;
        }


        protected void ButtonAgregarSectores_Click(object sender, EventArgs e)
        {

            string sector = TextBoxSectorDescripcion.Text.Trim().ToUpper();

            var query = from L in ListSectoresSeleccionada
                        where (L.Descripcion.ToString().Trim().ToUpper().StartsWith(sector))
                        select L;

            if (query != null)
            {

                DomainAmbientHouse.Entidades.Sectores sectores = new DomainAmbientHouse.Entidades.Sectores();

                sectores.Descripcion = TextBoxSectorDescripcion.Text;

                ListSectoresSeleccionada.Add(sectores);


                GridViewSectores.DataSource = ListSectoresSeleccionada.ToList();
                GridViewSectores.DataBind();

                TextBoxSectorDescripcion.Text = "";
            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Va a ingresar el mismo Sector mas de una vez en la Locacion.";

            }

        }

        protected void ButtonQuitarSectores_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewSectores.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.Sectores detalle = new DomainAmbientHouse.Entidades.Sectores();


                    detalle.Id = Int32.Parse(row.Cells[1].Text);

                    var itemRemove = ListSectoresSeleccionada.Where(o => o.Id == detalle.Id).Single();

                    ListSectoresSeleccionada.Remove(itemRemove);
                }

            }

        }

        protected void CheckBoxRequiereMesasySillas_CheckedChanged(object sender, EventArgs e)
        {
            PanelRequiereMesasySillas.Visible = CheckBoxRequiereMesasySillas.Checked;
        }


    }
}