using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class TipoCateringDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoCateringDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public List<TipoCatering> BuscarTipoCateringPorSegmentoCaracteristicaMomendoDuracionEvento(int caracteristicaId, int segmentoId, int MomentoDiaId, int DuracionId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringActivo"].ToString());
            int activoConfig = Int32.Parse(ConfigurationManager.AppSettings["configuracionTecnicaCateringACTIVO"].ToString());


            var query = from Tc in SqlContext.TipoCatering
                        join Ctc in SqlContext.ConfiguracionCateringTecnica on Tc.Id equals Ctc.TipoCateringId
                        where Tc.EstadoId == activo && Ctc.EstadoId == activoConfig &&
                            Ctc.CaracteristicaId == caracteristicaId &&
                            Ctc.SegmentoId == segmentoId &&
                            Ctc.MomentoDiaId == MomentoDiaId &&
                            Ctc.DuracionId == DuracionId
                        select Tc;

            return query.ToList();


        }

        public List<ConfiguracionCateringTecnica> ObtenerConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId)
        {
            var query = from u in SqlContext.ConfiguracionCateringTecnica
                        join p in SqlContext.Segmentos on u.SegmentoId equals p.Id
                        join q in SqlContext.Caracteristicas on u.CaracteristicaId equals q.Id
                        join j in SqlContext.DuracionEvento on u.DuracionId equals j.Id
                        join m in SqlContext.MomentosDias on u.MomentoDiaId equals m.Id
                        join tc in SqlContext.TipoCatering on u.TipoCateringId equals tc.Id
                        join ts in SqlContext.TipoServicios on u.TipoServicioId equals ts.Id

                        select new
                        {
                            SegmentoId = u.SegmentoId,
                            CaracteristicaId = u.CaracteristicaId,
                            SegmentoDescripcion = p.Descripcion,
                            CaracteristicaDescripcion = q.Descripcion,

                            MomentoDiaId = u.MomentoDiaId,
                            DuracionId = u.DuracionId,
                            MometoDiaDescripcion = m.Descripcion,
                            DuracionDescripcion = j.Descripcion,

                            TipoCateringId = u.TipoCateringId,
                            TipoServicioId = u.TipoServicioId,
                            TipoCateringDescripcion = tc.Descripcion,
                            TipoServicioDescripcion = ts.Descripcion,
                            EstadoId = u.EstadoId,
                            Id = u.Id

                        };

            if (segmentoId > 0)
                query = query.Where(o => o.SegmentoId == segmentoId);

            if (caracteristicaId > 0)
                query = query.Where(o => o.CaracteristicaId == caracteristicaId);


            if (momentoDiaId > 0)
                query = query.Where(o => o.MomentoDiaId == momentoDiaId);


            if (duracionId > 0)
                query = query.Where(o => o.DuracionId == duracionId);



            List<ConfiguracionCateringTecnica> Salida = new List<ConfiguracionCateringTecnica>();
            foreach (var item in query)
            {

                ConfiguracionCateringTecnica cat = new ConfiguracionCateringTecnica();


                cat.SegmentoId = item.SegmentoId;
                cat.SegmentoDescripcion = item.SegmentoDescripcion;
                cat.CaracteristicaId = item.CaracteristicaId;
                cat.CaracteristicaDescripcion = item.CaracteristicaDescripcion;

                cat.MomentoDiaId = item.MomentoDiaId;
                cat.MomentodelDiaDescripcion = item.MometoDiaDescripcion;
                cat.DuracionId = item.DuracionId;
                cat.DuracionDescripcion = item.DuracionDescripcion;

                cat.TipoCateringId = item.TipoCateringId;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;
                cat.TipoServicioId = item.TipoServicioId;
                cat.TipoServicioDescripcion = item.TipoServicioDescripcion;

                cat.EstadoId = item.EstadoId;
                cat.Id = item.Id;

                Salida.Add(cat);
            }

           

            return Salida.ToList();
        }

        public void EliminarConfiguracionCateringTecnica()
        {
            List<ConfiguracionCateringTecnica> configuracion = SqlContext.ConfiguracionCateringTecnica.ToList();

            foreach (var item in configuracion)
            {
                SqlContext.ConfiguracionCateringTecnica.Remove(item);
            }
            SqlContext.SaveChanges();
        }

        public void NuevaConfiguracionCateringTecnica(ConfiguracionCateringTecnica configuracion)
        {

            ConfiguracionCateringTecnica configEdit = SqlContext.ConfiguracionCateringTecnica.Where(o => o.SegmentoId == configuracion.SegmentoId && o.CaracteristicaId == configuracion.CaracteristicaId
                                                                                                    && o.DuracionId == configuracion.DuracionId && o.MomentoDiaId == configuracion.MomentoDiaId
                                                                                                    && o.TipoCateringId == configuracion.TipoCateringId && o.TipoServicioId == configuracion.TipoServicioId).FirstOrDefault();
            if (configEdit == null)
            {
                SqlContext.ConfiguracionCateringTecnica.Add(configuracion);
                SqlContext.SaveChanges();
            }
        }

        public ConfiguracionCateringTecnica BuscarConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId, int tipoCateringId, int tipoServicioId)
        {
            return SqlContext.ConfiguracionCateringTecnica.Where(o => o.SegmentoId == segmentoId && o.CaracteristicaId == caracteristicaId &&
                                                                    o.MomentoDiaId == momentoDiaId && o.DuracionId == duracionId &&
                                                                    o.TipoCateringId == tipoCateringId && o.TipoServicioId == tipoServicioId).FirstOrDefault();

            
        }

        public void ActivarDesactivarConfiguracion(int Id, int estado)
        {
            ConfiguracionCateringTecnica editConf = SqlContext.ConfiguracionCateringTecnica.Where(o => o.Id == Id).FirstOrDefault();


            editConf.EstadoId = estado;

            SqlContext.SaveChanges();

        }

        public List<TipoCatering> BuscarTipoCateringPorAdicional(int adicionalId)
        {
            var query = from Tc in SqlContext.TipoCatering
                        join TcA in SqlContext.TipoCateringAdicional on Tc.Id equals TcA.TipoCateringId
                        where TcA.AdicionalId == adicionalId
                        select Tc;

            return query.ToList();
        }

        public List<TipoCatering> BuscarTipoCateringParaAgregarPorAdicional(int adicionalId)
        {
            List<TipoCatering> query = (from Tc in SqlContext.TipoCatering
                        join TcA in SqlContext.TipoCateringAdicional on Tc.Id equals TcA.TipoCateringId
                        where TcA.AdicionalId == adicionalId
                        select Tc).ToList();

            List<TipoCatering> queryfinal = (from Tc in SqlContext.TipoCatering
                                             where Tc.EsAdicional == "N"
                                            select Tc).ToList();

            return queryfinal.Except(query).ToList();
        }

        public void NuevoTipoCateringAdicional(TipoCateringAdicional tcA)
        {
            SqlContext.TipoCateringAdicional.Add(tcA);
            SqlContext.SaveChanges();

        }


        public virtual List<TipoCatering> ObtenerTipoCatering()
        {

            return SqlContext.TipoCatering.Where(o => o.EsAdicional.Equals("N")).ToList();

        }

        public virtual List<TipoCatering> ObtenerTipoCateringSoloActivos()
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringActivo"].ToString());


            return SqlContext.TipoCatering.Where(o => o.EsAdicional.Equals("N") && o.EstadoId == activo).ToList();

        }

        public TipoCatering BuscarTipoCatering(long id)
        {
            return SqlContext.TipoCatering.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoTipoCatering(TipoCatering TipoCatering)
        {
            if (TipoCatering.Id == 0)
            {
                int tipoCateringId = SqlContext.TipoCatering.Max(o => o.Id) + 1;

                TipoCatering.Id = tipoCateringId;


                SqlContext.TipoCatering.Add(TipoCatering);
                SqlContext.SaveChanges();
            }
            else
            { EditarTipoCatering(TipoCatering); }
        }

        public void EditarTipoCatering(TipoCatering TipoCatering)
        {
            TipoCatering editTipoCatering = SqlContext.TipoCatering.Where(o => o.Id == TipoCatering.Id).FirstOrDefault();

            editTipoCatering.Descripcion = TipoCatering.Descripcion;
            editTipoCatering.EsAdicional = TipoCatering.EsAdicional;
            editTipoCatering.RubroId = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            editTipoCatering.EstadoId = TipoCatering.EstadoId;

            SqlContext.SaveChanges();
        }

        public List<TipoCatering> ObtenerAdicionalesTipoCatering()
        {
            return SqlContext.TipoCatering.Where(o => o.EsAdicional == "S").ToList();
        }
        public void EliminarTipoCateringAdicional(int adicionalId)
        {
            List<TipoCateringAdicional> tipoCateringAdicional = SqlContext.TipoCateringAdicional.Where(o=> o.AdicionalId == adicionalId).ToList();

            foreach (var item in tipoCateringAdicional)
            {
                SqlContext.TipoCateringAdicional.Remove(item);
            }
            SqlContext.SaveChanges();
        }


        public void ActualizarTipoCatering(TipoCatering item)
        {
            TipoCatering edit = SqlContext.TipoCatering.Where(o => o.Id == item.Id).SingleOrDefault();

            edit.EstadoId = item.EstadoId;

            SqlContext.SaveChanges();
        }
    }
}
