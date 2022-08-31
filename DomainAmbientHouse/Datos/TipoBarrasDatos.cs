
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class TipoBarrasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoBarrasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TiposBarras> ObtenerTipoBarras()
        {

            return SqlContext.TiposBarras.ToList();

        }


        public TiposBarras BuscarTipoBarras(int id)
        {
            return SqlContext.TiposBarras.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoTipoBarra(TiposBarras tipoBarra)
        {
            if (tipoBarra.Id > 0)
            {

                TiposBarras catTipoBarra = SqlContext.TiposBarras.Where(o => o.Id == tipoBarra.Id).First();

                catTipoBarra.Descripcion = tipoBarra.Descripcion;
                catTipoBarra.SegmentoId = tipoBarra.SegmentoId;
                catTipoBarra.DuracionId = tipoBarra.DuracionId;
                catTipoBarra.RangoEtareo = tipoBarra.RangoEtareo;

                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.TiposBarras.Add(tipoBarra);
                SqlContext.SaveChanges();
            }
        }

        public List<TiposBarras> BuscarTipoBarrasPorSegmento(int segmentoId, int duracionId)
        {
            return SqlContext.TiposBarras.Where(o => o.SegmentoId == segmentoId && o.DuracionId == duracionId).ToList();
        }
    }
}
