using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class GruposDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public GruposDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<GruposItems> ObtenerGrupos()
        {

            return SqlContext.GruposItems.ToList();

        }

        public GruposItems BuscarGruposItems(int Id)
        {
            return SqlContext.GruposItems.Where(o => o.Id == Id).First();
        }

        public void NuevoGruposItems(GruposItems grupoItem)
        {

           

            if (grupoItem.Id > 0)
            {
                GruposItems grupoItemEdit = SqlContext.GruposItems.Where(o => o.Id == grupoItem.Id).First();

                grupoItemEdit.Codigo = grupoItem.Codigo;
                grupoItemEdit.Tipo = grupoItem.Tipo;
                grupoItemEdit.Descripcion = grupoItem.Descripcion;
               

                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.GruposItems.Add(grupoItem);
                SqlContext.SaveChanges();
            }
        }

        public List<ObtenerGruposconFamilias> ObtenerGruposConFamilias()
        {
            return SqlContext.ObtenerGruposconFamilias.ToList();
        }
    }
}
