using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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

            return Datos.ObtenerFeriados(anio,mes);

        }

    }
}
