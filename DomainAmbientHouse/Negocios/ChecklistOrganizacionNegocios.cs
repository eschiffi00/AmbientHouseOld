using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ChecklistOrganizacionNegocios
    {

        ChecklistOrganizacionDatos Datos;

        public ChecklistOrganizacionNegocios()
        {
            Datos = new ChecklistOrganizacionDatos();
        }

        //public virtual List<CheckListOrganizacion> ObtenerChecklistOrganizacion()
        //{

        //    return Datos.ObtenerChecklistOrganizacion();

        //}


        //public CheckListOrganizacion BuscarChecklistOrganizacion(int checkId)
        //{
        //    return Datos.BuscarChecklistOrganizacion(checkId);
        //}
    }
}
