using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class RequerimientosNegocios
    {

        RequerimientoDatos Datos;

        public RequerimientosNegocios()
        {
            Datos = new RequerimientoDatos();
        }

        public virtual List<INVENTARIO_Requerimiento> ListarRequerimiento()
        {

            return Datos.ListarRequerimiento();

        }

        public INVENTARIO_Requerimiento BuscarRequerimiento(int id)
        {
            return Datos.BuscarRequerimiento(id);
        }

        public virtual bool GrabarRequerimiento(INVENTARIO_Requerimiento requerimiento)
        {
            return Datos.GrabarRequerimiento(requerimiento);
        }

        public virtual bool ElimarRequerimiento(int id)
        {
            return Datos.ElimnarRequerimiento(id);
        }
    }
}
