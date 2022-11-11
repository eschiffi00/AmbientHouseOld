using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class GruposNegocios
    {

        GruposDatos Datos;

        public GruposNegocios()
        {
            Datos = new GruposDatos();
        }

        public virtual List<GruposItems> ObtenerGrupos()
        {

            return Datos.ObtenerGrupos();

        }

        public GruposItems BuscarGruposItems(int Id)
        {
            return Datos.BuscarGruposItems(Id);
        }

        public void NuevoGruposItems(GruposItems grupoItem)
        {
            Datos.NuevoGruposItems(grupoItem);
        }


        public List<ObtenerGruposconFamilias> ObtenerGruposConFamilias()
        {
            return Datos.ObtenerGruposConFamilias();
        }
    }
}
