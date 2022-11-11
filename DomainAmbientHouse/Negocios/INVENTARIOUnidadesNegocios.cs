using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class INVENTARIOUnidadesNegocios
    {

        INVENTARIOUnidadesDatos Datos;

        public INVENTARIOUnidadesNegocios()
        {
            Datos = new INVENTARIOUnidadesDatos();
        }

        public virtual List<INVENTARIO_Unidades> ListarUnidades()
        {

            return Datos.ListarUnidades();

        }

        public virtual INVENTARIO_Unidades BuscarINVENTARIOUnidades(int Id)
        {

            return Datos.BuscarINVENTARIOUnidades(Id);

        }




    }
}
