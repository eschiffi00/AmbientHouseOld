using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class AgregarTecnica : System.Web.UI.Page
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

        private DomainAmbientHouse.Entidades.TecnicaSalon TecnicaSalonSeleccionado
        {
            get
            {
                return Session["TecnicaSalonSeleccionado"] as DomainAmbientHouse.Entidades.TecnicaSalon;
            }
            set
            {
                Session["TecnicaSalonSeleccionado"] = value;
            }
        }
        private List<DomainAmbientHouse.Entidades.TecnicaSalon> ListTecnicaSalon
        {
            get
            {
                return Session["ListTecnicaSalon"] as List<DomainAmbientHouse.Entidades.TecnicaSalon>;
            }
            set
            {
                Session["ListTecnicaSalon"] = value;
            }
        }

        EventosServicios servicios = new EventosServicios();
        AdministrativasServicios serviciosAdmin = new AdministrativasServicios();
        ProveedoresServicios serviciosProveedor = new ProveedoresServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InicializarPagina();

                CargarListaProveedores();

            }

        }

        private void CargarListaProveedores()
        {
            int unTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());

            DropDownListProveedores.DataSource = servicios.TraerProveedoresPorRubro(unTecnica);
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

            EditarTecnicaSalon(id);
        }

        private void EditarTecnicaSalon(int id)
        {

            ListTecnicaSalon = CargarListaProveedores(LocacionId, Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString()));

            GridViewProveedores.DataSource = ListTecnicaSalon.ToList();
            GridViewProveedores.DataBind();


        }

        private List<DomainAmbientHouse.Entidades.TecnicaSalon> CargarListaProveedores(int LocacionId, int sectorId)
        {
            List<DomainAmbientHouse.Entidades.TecnicaSalon> lista = servicios.ObtenerProveedorTecnicaPorLocacionSector(LocacionId, sectorId);
            return lista;
        }

        private void NuevoTecnicaSalon()
        {
            TecnicaSalonSeleccionado = new DomainAmbientHouse.Entidades.TecnicaSalon();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();

        }

        private void Grabar()
        {
            int sectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

            serviciosAdmin.GrabarTecnicaSalon(sectorId, ListTecnicaSalon);
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.TecnicaSalon proveedorTecnica = new DomainAmbientHouse.Entidades.TecnicaSalon();



            proveedorTecnica.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
            proveedorTecnica.RazonSocial = DropDownListProveedores.SelectedItem.Text;
            proveedorTecnica.SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
            proveedorTecnica.SectorDescripcion = DropDownListSectores.SelectedItem.Text;
            proveedorTecnica.LocacionId = LocacionId;
            proveedorTecnica.LocacionDescripcion = LabelLocacion.Text;

            if (ListTecnicaSalon.Where(o => o.ProveedorId == proveedorTecnica.ProveedorId && o.LocacionId == proveedorTecnica.LocacionId && o.SectorId == proveedorTecnica.SectorId).Count() > 0)
            { }
            else
            {
                ListTecnicaSalon.Add(proveedorTecnica);
            }

            GridViewProveedores.DataSource = ListTecnicaSalon.ToList();
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

                    DomainAmbientHouse.Entidades.TecnicaSalon proveedorTecnica = new DomainAmbientHouse.Entidades.TecnicaSalon();

                    proveedorTecnica.SectorId = Int32.Parse(row.Cells[4].Text);
                    proveedorTecnica.LocacionId = Int32.Parse(row.Cells[5].Text);
                    proveedorTecnica.ProveedorId = Int32.Parse(row.Cells[6].Text);

                    var itemRemove = ListTecnicaSalon.Where(o => o.ProveedorId == proveedorTecnica.ProveedorId
                                                                      && o.LocacionId == proveedorTecnica.LocacionId
                                                                      && o.SectorId == proveedorTecnica.SectorId).Single();

                    ListTecnicaSalon.Remove(itemRemove);
                }

            }


            GridViewProveedores.DataSource = ListTecnicaSalon.ToList();
            GridViewProveedores.DataBind();

            UpdatePanelGrilla.Update();
        }

        protected void DropDownListSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListSectores.SelectedItem != null)
            {
                EditarTecnicaSalon(LocacionId);
            }
        }
    }
}