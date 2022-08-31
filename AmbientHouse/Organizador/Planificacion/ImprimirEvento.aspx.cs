using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Organizador.Planificacion
{
    public partial class ImprimirEvento : System.Web.UI.Page
    {
        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoIdOR"].ToString());
            }
            set
            {
                Session["PresupuestoIdOR"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LabelNroPresupuesto.Text = Int32.Parse(Request["PresupuestoId"]).ToString();
                LabelNroEvento.Text = Int32.Parse(Request["EventoId"]).ToString();

            }
        }

 
    }
}