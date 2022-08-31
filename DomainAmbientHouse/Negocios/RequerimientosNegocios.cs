using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;
using System.Configuration;

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
