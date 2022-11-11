using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class FeriadosNegocios
    {

        FeriadosDatos Datos;

        public FeriadosNegocios()
        {
            Datos = new FeriadosDatos();
        }

        public virtual List<Feriados> ObtenerFeriados(int anio, int mes)
        {

            return Datos.ObtenerFeriados(anio, mes);

        }

    }
}
