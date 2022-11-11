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
