using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class DepartamentosNegocios
    {

      DepartamentosDatos Datos;

      public DepartamentosNegocios()
        {
            Datos = new DepartamentosDatos();
        }

      public virtual List<Departamentos> ObtenerDepartamentos()
        {

            return Datos.ObtenerDepartamentos();

        }


      public Departamentos BuscarDepartamentoPorSector(int sectorid)
      {
          return Datos.BuscarDepartamentoPorSector( sectorid);
      }
    }
}
