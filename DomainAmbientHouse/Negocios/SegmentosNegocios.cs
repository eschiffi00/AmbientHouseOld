using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
