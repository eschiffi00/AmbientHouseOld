using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ChecklistOrganizacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ChecklistOrganizacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        //public virtual List<CheckListOrganizacion> ObtenerChecklistOrganizacion()
        //{

        //    return SqlContext.CheckListOrganizacion.OrderBy(o => o.Orden).ToList();


        //}


        //public CheckListOrganizacion BuscarChecklistOrganizacion(int checkId)
        //{
        //    return SqlContext.CheckListOrganizacion.Where(o => o.Id == checkId).SingleOrDefault();
        //}
    }
}
