using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class SectoresEmpresaNegocios
    {

        SectoresEmpresasDatos Datos;

        public SectoresEmpresaNegocios()
        {
            Datos = new SectoresEmpresasDatos();
        }

        public virtual List<SectoresEmpresa> ObtenerSectoresEmpresaPorDepartamento(int departamentoId)
        {
            return Datos.ObtenerSectoresEmpresaPorDepartamento(departamentoId);
        }


        public SectoresEmpresa BuscarSectorEmpresa(int sectorId)
        {
            return Datos.BuscarSectorEmpresa(sectorId);
        }

        internal List<SectoresEmpresa> ObtenerSectoresEmpresa()
        {
            return Datos.ObtenerSectoresEmpresa();
        }
    }
}
