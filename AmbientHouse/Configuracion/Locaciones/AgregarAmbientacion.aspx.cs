using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class AgregarAmbientacion : System.Web.UI.Page
    {
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

        private DomainAmbientHouse.Entidades.AmbientacionSalon AmbientacionSalonSeleccionado
        {
            get
            {
                return Session["AmbientacionSalonSeleccionado"] as DomainAmbientHouse.Entidades.AmbientacionSalon;
            }
            set
            {
                Session["TecnicaSalonSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.AmbientacionSalon> ListAmbientacionSalon
        {
            get
            {
                return Session["ListAmbientacionSalon"] as List<DomainAmbientHouse.Entidades.AmbientacionSalon>;
            }
            set
            {
                Session["ListAmbientacionSalon"] = value;
            }
        }


        EventosServicios servicios = new EventosServicios();
        AdministrativasServicios serviciosAdmin = new AdministrativasServicios();
        ProveedoresServicios serviciosProveedor = new ProveedoresServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListAmbientacionSalon = new List<DomainAmbientHouse.Entidades.AmbientacionSalon>();

                InicializarPagina();

                CargarListaProveedores();

            }

        }

        private void CargarListaProveedores()
        {
            int unAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            DropDownListProveedores.DataSource = servicios.TraerProveedoresPorRubro(unAmbientacion);
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                LocacionId = id;
            }

            LabelLocacion.Text = serviciosAdmin.ObtenerLocaciones().Where(o => o.Id == LocacionId).FirstOrDefault().Descripcion.ToUpper();

            DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(LocacionId);
            DropDownListSectores.DataTextField = "Descripcion";
            DropDownListSectores.DataValueField = "Id";
            DropDownListSectores.DataBind();




            EditarAmbientacionSalon(id);
        }

        private void EditarAmbientacionSalon(int id)
        {
            ListAmbientacionSalon = CargarListaProveedores(LocacionId, Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString()));

            GridViewProveedores.DataSource = ListAmbientacionSalon.ToList();
            GridViewProveedores.DataBind();

            UpdatePanelGrilla.Update();
        }

        private List<DomainAmbientHouse.Entidades.AmbientacionSalon> CargarListaProveedores(int LocacionId, int sectorId)
        {
            List<DomainAmbientHouse.Entidades.AmbientacionSalon> lista = servicios.ObtenerProveedorAmbientacionPorLocacionSector(LocacionId, sectorId);
            return lista;
        }

        private void NuevoAmbientacionSalon()
        {
            AmbientacionSalonSeleccionado = new DomainAmbientHouse.Entidades.AmbientacionSalon();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            int sectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

            servicios.GrabarProveedoresAmbientacion(sectorId, ListAmbientacionSalon);
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.AmbientacionSalon proveedorAmb = new DomainAmbientHouse.Entidades.AmbientacionSalon();



            proveedorAmb.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
            proveedorAmb.RazonSocial = DropDownListProveedores.SelectedItem.Text;
            proveedorAmb.SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
            proveedorAmb.SectorDescripcion = DropDownListSectores.SelectedItem.Text;
            proveedorAmb.LocacionId = LocacionId;
            proveedorAmb.LocacionDescripcion = LabelLocacion.Text;


            if (ListAmbientacionSalon.Where(o => o.ProveedorId == proveedorAmb.ProveedorId && o.LocacionId == proveedorAmb.LocacionId && o.SectorId == proveedorAmb.SectorId).Count() > 0)
            { }
            else
            {
                ListAmbientacionSalon.Add(proveedorAmb);
            }

            GridViewProveedores.DataSource = ListAmbientacionSalon.ToList();
            GridViewProveedores.DataBind();

            UpdatePanelGrilla.Update();
        }

        protected void ButtonQuitar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewProveedores.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxQuitarImpuestos") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.AmbientacionSalon proveedorAmb = new DomainAmbientHouse.Entidades.AmbientacionSalon();

                    proveedorAmb.SectorId = Int32.Parse(row.Cells[4].Text);
                    proveedorAmb.LocacionId = Int32.Parse(row.Cells[5].Text);
                    proveedorAmb.ProveedorId = Int32.Parse(row.Cells[6].Text);

                    var itemRemove = ListAmbientacionSalon.Where(o => o.ProveedorId == proveedorAmb.ProveedorId && o.LocacionId == proveedorAmb.LocacionId && o.SectorId == proveedorAmb.SectorId).Single();

                    ListAmbientacionSalon.Remove(itemRemove);
                }

            }


            GridViewProveedores.DataSource = ListAmbientacionSalon.ToList();
            GridViewProveedores.DataBind();

            UpdatePanelGrilla.Update();

        }

        protected void DropDownListSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListSectores.SelectedItem != null)
            {
                EditarAmbientacionSalon(LocacionId);
            }
        }
    }
}