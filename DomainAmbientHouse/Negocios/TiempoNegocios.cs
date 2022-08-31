using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class TiempoNegocios
    {

        TiempoDatos Datos;

        public TiempoNegocios()
        {
            Datos = new TiempoDatos();
        }

        public virtual List<Tiempos> ObtenerTiempos()
        {

            return Datos.ObtenerTiempos();

        }


        public Tiempos BuscarTiempo(int id)
        {
            return Datos.BuscarTiempo(id);
        }

        public void NuevoTiempo(Tiempos tiempo)
        {
            Datos.NuevoTiempo(tiempo);
        }

        public List<Tiempos> ObtenerTiemposPorTipoCatering(int TipoCateringId)
        {
            return Datos.ObtenerTiemposPorTipoCatering(TipoCateringId);
        }
    }
}
