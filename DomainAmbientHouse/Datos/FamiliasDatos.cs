using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class FamiliasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FamiliasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ObtenerFamilias> ObtenerFamilias()
        {

            return SqlContext.ObtenerFamilias.ToList();

        }

        public Familias BuscarFamilias(int GrupoId, int CatagoriaId)
        {
            return SqlContext.Familias.Where(o => o.GrupoId == GrupoId && o.CategoriaItemId == CatagoriaId).First();
        }

        public void NuevaFamilia(Familias familia)
        {

            Familias familiaEdit = SqlContext.Familias.Where(o => o.GrupoId == familia.GrupoId && o.CategoriaItemId == familia.CategoriaItemId).FirstOrDefault();

            if (familiaEdit!=null)
            {

                familiaEdit.Comentario = familia.Comentario;
                familiaEdit.Edad = familia.Edad;
                familiaEdit.Fantasia = familia.Fantasia;
                familiaEdit.Subtitulo = familia.Subtitulo;
                familiaEdit.Titulo = familia.Titulo;
 
                SqlContext.SaveChanges();
            }
            else
            {


                SqlContext.Familias.Add(familia);
                SqlContext.SaveChanges();
            }
        }

        public List<ObtenerFamilias> ObtenerFamiliasConItems()
        {
            var query = from OF in SqlContext.ObtenerFamilias
                        join It in SqlContext.Items on OF.CategoriaItemId equals It.CategoriaItemId
                        select OF;

            return query.ToList();
        }

        public void NuevaTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {

            SqlContext.TipoCateringFamilia.Add(tipoCateringFamilia);
            SqlContext.SaveChanges();
        }

        public void QuitarTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {

            TipoCateringFamilia detalle = SqlContext.TipoCateringFamilia.Where(o => o.TipoCateringId == tipoCateringFamilia.TipoCateringId && o.GrupoId == tipoCateringFamilia.GrupoId).FirstOrDefault();

           if (detalle != null)
            {

                SqlContext.TipoCateringFamilia.Remove(detalle);
                SqlContext.SaveChanges();

            }


        }

        public List<GruposItems> ObtenerFamiliasConItemsTipoCatering(int tipoCateringId)
        {

            var query = from OF in SqlContext.ObtenerFamilias
                        join It in SqlContext.TipoCateringFamilia on OF.GrupoId equals It.GrupoId
                        join G in SqlContext.GruposItems on It.GrupoId equals G.Id
                        where It.TipoCateringId == tipoCateringId
                        select G;

            return query.Distinct().ToList();
        }

        public  List<GruposItems> ObtenerFamiliasConItemsAdicionales(int AdicionalId)
        {
            var query = from OF in SqlContext.ObtenerFamilias
                        join It in SqlContext.TipoCateringFamilia on OF.GrupoId equals It.GrupoId
                        join G in SqlContext.GruposItems on It.GrupoId equals G.Id
                        where It.AdicionalId == AdicionalId
                        select G;

            return query.Distinct().ToList();
        }

        public TipoCateringFamilia BuscarTipoCateringFamiliaPorGrupo(int grupoId, int tipoCateringId)
        {
            return SqlContext.TipoCateringFamilia.Where(o => o.GrupoId == grupoId && o.TipoCateringId == tipoCateringId).FirstOrDefault();
        }
    }

}
