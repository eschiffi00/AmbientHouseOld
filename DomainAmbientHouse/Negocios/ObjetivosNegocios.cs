using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
