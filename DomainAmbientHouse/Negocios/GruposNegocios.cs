using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
            return Datos.BuscarGruposItems (Id);
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
