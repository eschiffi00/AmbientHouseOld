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
    public class DegustacionNegocios
    {

        DegustacionDatos Datos;

        public DegustacionNegocios()
        {
            Datos = new DegustacionDatos();
        }

        public virtual Degustacion BuscarDegustacion(int Id)
        {

            return Datos.BuscarDegustacion(Id);

        }

        public virtual void GrabarDegustacion(Degustacion degustacion)
        {

            Datos.GrabarDegustacion(degustacion);

        }

        public virtual List<Degustacion> ObtenerDegustaciones()
        {

            return Datos.ObtenerDegustaciones();

        }



    }
}
