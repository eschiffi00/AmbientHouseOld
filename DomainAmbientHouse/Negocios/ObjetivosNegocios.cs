using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ObjetivosNegocios
    {

        ObjetivosDatos Datos;

        public ObjetivosNegocios()
        {
            Datos = new ObjetivosDatos();
        }

        public virtual List<ObjetivosEmpleados> BuscarObjetivosPorEmpleadoMensuales(int empleadoId)
        {

            return Datos.BuscarObjetivosPorEmpleadoMensuales(empleadoId);

        }

    }
}
