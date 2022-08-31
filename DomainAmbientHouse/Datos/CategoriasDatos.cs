using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class CategoriasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CategoriasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Categorias> ObtenerCategorias()
        {

            return SqlContext.Categorias.ToList();

        }

        public List<Categorias> ObtenerAmbientaciones()
        {
            var query = from u in SqlContext.Categorias
                        join p in SqlContext.Segmentos on u.SegmentoId equals p.Id 
                        join q in SqlContext.Caracteristicas on u.CaracteristicaId equals q.Id 
                        join j in SqlContext.Locaciones on u.LocacionId equals j.Id
                        join s in SqlContext.Sectores on u.SectorId equals s.Id
                        select new
                           {
                               Id = u.Id,
                               Descripcion = u.Descripcion,
                               LocacionId =  u.LocacionId,
                               SegmentoId =  u.SegmentoId,
                               CaracteristicaId =  u.CaracteristicaId,
                               SectorId = u.SectorId,
                               SegmentoDescripcion = (p.Descripcion == null ? String.Empty : p.Descripcion),
                               CaracteristicaDescripcion = (q == null ? String.Empty : q.Descripcion),
                               LocacionDescripcion = (j == null ? String.Empty : j.Descripcion),
                               SectorDescripcion = (s == null ? String.Empty : s.Descripcion)

                           };

            List<Categorias> Salida = new List<Categorias>();
            foreach (var item in query)
            {

                Categorias cat = new Categorias();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.SegmentoId = item.SegmentoId;
                cat.SegmentoDescripcion = item.SegmentoDescripcion;
                cat.CaracteristicaId = item.CaracteristicaId;
                cat.CaracteristicaDescripcion = item.CaracteristicaDescripcion;
                cat.SectorId = item.SectorId;
                cat.SectorDescripcion = item.SectorDescripcion;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public List<Categorias> ObtenerAmbientacionesPorLocacion(int locacionId)
        {
            var query = from u in SqlContext.Categorias
                        join p in SqlContext.Segmentos on u.SegmentoId equals p.Id
                        join q in SqlContext.Caracteristicas on u.CaracteristicaId equals q.Id
                        join j in SqlContext.Locaciones on u.LocacionId equals j.Id
                        join s in SqlContext.Sectores on u.SectorId equals s.Id
                        where u.LocacionId == locacionId
                        select new
                        {
                            Id = u.Id,
                            Descripcion = u.Descripcion,
                            LocacionId = u.LocacionId,
                            SegmentoId = u.SegmentoId,
                            CaracteristicaId = u.CaracteristicaId,
                            SectorId = u.SectorId,
                            SegmentoDescripcion = (p.Descripcion == null ? String.Empty : p.Descripcion),
                            CaracteristicaDescripcion = (q == null ? String.Empty : q.Descripcion),
                            LocacionDescripcion = (j == null ? String.Empty : j.Descripcion),
                            SectorDescripcion = (s == null ? String.Empty : s.Descripcion)

                        };

            List<Categorias> Salida = new List<Categorias>();
            foreach (var item in query)
            {

                Categorias cat = new Categorias();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.SegmentoId = item.SegmentoId;
                cat.SegmentoDescripcion = item.SegmentoDescripcion;
                cat.CaracteristicaId = item.CaracteristicaId;
                cat.CaracteristicaDescripcion = item.CaracteristicaDescripcion;
                cat.SectorId = item.SectorId;
                cat.SectorDescripcion = item.SectorDescripcion;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public Categorias BuscarCategorias(int id)
        {
            return SqlContext.Categorias.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaCategoria(Categorias categoria)
        {
            if (categoria.Id > 0)
            {

                Categorias edit = SqlContext.Categorias.Where(o => o.Id == categoria.Id).First();

                edit.Descripcion = categoria.Descripcion;
                edit.CaracteristicaId = categoria.CaracteristicaId;
                edit.SegmentoId = categoria.SegmentoId;
                edit.LocacionId = categoria.LocacionId;
                edit.SectorId = categoria.SectorId;
                edit.EstadoId = categoria.EstadoId;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.Categorias.Add(categoria);
                SqlContext.SaveChanges();
            }
        }

        public List<Categorias> BuscarCategoriasPorLocacionCaracteristicaSegmento(int locacionId, 
                                                                                    int caracteristicaId, 
                                                                                    int segmentoId, 
                                                                                    int sectorId)
        {

            int activo = Int32.Parse(ConfigurationManager.AppSettings["CategoriasActivo"].ToString()); ;

            List<Categorias> query = (from c in SqlContext.Categorias
                                      where (c.LocacionId == locacionId 
                                                && c.CaracteristicaId == caracteristicaId 
                                                && c.SegmentoId == segmentoId 
                                                && c.SectorId == sectorId
                                                && c.EstadoId == activo)
                                              
                        select c).ToList();

            return query.ToList();
        
        }
    }
}
