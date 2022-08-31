using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class TipoServiciosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoServiciosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoServicios> ObtenerTipoServicios()
        {

            return SqlContext.TipoServicios.ToList();

        }


        public TipoServicios BuscarTipoServicios(int id)
        {
            return SqlContext.TipoServicios.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoTipoServicios(TipoServicios tiposervicio)
        {
            if (tiposervicio.Id > 0)
            {

                TipoServicios tipoServiciosEdit = SqlContext.TipoServicios.Where(o => o.Id == tiposervicio.Id).First();

                tipoServiciosEdit.Descripcion = tiposervicio.Descripcion;
              


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.TipoServicios.Add(tiposervicio);
                SqlContext.SaveChanges();
            }
        }

        public  List<TipoServicios> TraerTipoServicios(int CaracteristicasId, int SegmentosId, int MomentoDiaId, int DuracionId)
        {
            var query = from Tc in SqlContext.TipoServicios
                        join Ctc in SqlContext.ConfiguracionCateringTecnica on Tc.Id equals Ctc.TipoServicioId
                        where Ctc.CaracteristicaId == CaracteristicasId &&
                            Ctc.SegmentoId == SegmentosId &&
                            Ctc.MomentoDiaId == MomentoDiaId &&
                            Ctc.DuracionId == DuracionId
                        select Tc;

            return query.ToList();
        }

        public List<TipoServicios> BuscarTipoServicioPorAdicional(int adicionalId)
        {
            var query = from Tc in SqlContext.TipoServicios
                        join TcA in SqlContext.TipoServicioAdicional on Tc.Id equals TcA.TipoServicioId
                        where TcA.AdicionalId == adicionalId
                        select Tc;

            return query.ToList();
        }

        public List<TipoServicios> BuscarTipoServicioParaAgregarPorAdicional(int adicionalId)
        {
            List<TipoServicios> query = (from Tc in SqlContext.TipoServicios
                                        join TcA in SqlContext.TipoServicioAdicional on Tc.Id equals TcA.TipoServicioId
                                        where TcA.AdicionalId == adicionalId
                                        select Tc).ToList();

            List<TipoServicios> queryfinal = (from Tc in SqlContext.TipoServicios
                                             select Tc).ToList();

            return queryfinal.Except(query).ToList();
        }

        public void EliminarTipoServicioAdicional(int adicionalId)
        {
            List<TipoServicioAdicional> tipoServicioAdicional = SqlContext.TipoServicioAdicional.Where(o => o.AdicionalId == adicionalId).ToList();

            foreach (var item in tipoServicioAdicional)
            {
                SqlContext.TipoServicioAdicional.Remove(item);
            }
            SqlContext.SaveChanges();
        }

        public void NuevoTipoServicioAdicional(TipoServicioAdicional tsA)
        {
            SqlContext.TipoServicioAdicional.Add(tsA);
            SqlContext.SaveChanges();
        }
    }
}
