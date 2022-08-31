using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class TipoServiciosNegocios
    {

      TipoServiciosDatos Datos;

      public TipoServiciosNegocios()
        {
            Datos = new TipoServiciosDatos();
        }

        public virtual List<TipoServicios> ObtenerTipoServicios()
        {

            return Datos.ObtenerTipoServicios();

        }


        public  TipoServicios BuscarTipoServicios(int id)
        {
            return Datos.BuscarTipoServicios( id);
        }

        public void NuevoTipoServicio(TipoServicios tiposervicio)
        {
            Datos.NuevoTipoServicios(tiposervicio);
        }

        public List<TipoServicios> TraerTipoServicios(int CaracteristicasId, int SegmentosId, int MomentoDiaId, int DuracionId)
        {
           return Datos.TraerTipoServicios( CaracteristicasId,  SegmentosId,  MomentoDiaId,  DuracionId);
        }

        public List<TipoServicios> BuscarTipoServicioPorAdicional(int adicionalId)
        {
          return Datos.BuscarTipoServicioPorAdicional( adicionalId);
        }

        public List<TipoServicios> BuscarTipoServicioParaAgregarPorAdicional(int adicionalId)
        {
            return Datos.BuscarTipoServicioParaAgregarPorAdicional(adicionalId);
        }
    }
}
