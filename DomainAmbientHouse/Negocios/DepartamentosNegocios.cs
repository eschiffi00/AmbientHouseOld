using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
            return Datos.BuscarDepartamentoPorSector(sectorid);
        }
    }
}
