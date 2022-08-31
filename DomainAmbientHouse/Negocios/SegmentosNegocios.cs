using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class SegmentosNegocios
    {

        SegmentosDatos Datos;

        public SegmentosNegocios()
        {
            Datos = new SegmentosDatos();
        }

        public virtual List<Segmentos> ObtenerSegmentos()
        {

            return Datos.ObtenerSegmentos();

        }


        public Segmentos BuscarSegmentos(int Id)
        {
            return Datos.BuscarSegmentos(Id);
        }
    }
}
