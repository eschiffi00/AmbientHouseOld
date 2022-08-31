using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
