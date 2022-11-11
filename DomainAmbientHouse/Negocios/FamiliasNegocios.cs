using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class FamiliasNegocios
    {

        FamiliasDatos Datos;

        public FamiliasNegocios()
        {
            Datos = new FamiliasDatos();
        }

        public virtual List<ObtenerFamilias> ObtenerFamilias()
        {

            return Datos.ObtenerFamilias();

        }


        public Familias BuscarFamilias(int GrupoId, int CategoriaId)
        {
            return Datos.BuscarFamilias(GrupoId, CategoriaId);
        }

        public void NuevaFamilia(Familias familia)
        {
            Datos.NuevaFamilia(familia);
        }

        public List<ObtenerFamilias> ObtenerFamiliasConItems()
        {
            return Datos.ObtenerFamiliasConItems();

        }

        public void NuevaTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {
            Datos.NuevaTipoCateringFamilia(tipoCateringFamilia);
        }


        public List<GruposItems> ObtenerFamiliasConItemsTipoCatering(int tipoCateringId)
        {
            return Datos.ObtenerFamiliasConItemsTipoCatering(tipoCateringId);
        }

        public List<GruposItems> ObtenerFamiliasConItemsAdicionales(int AdicionalId)
        {
            return Datos.ObtenerFamiliasConItemsAdicionales(AdicionalId);
        }

        public void QuitarTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {
            Datos.QuitarTipoCateringFamilia(tipoCateringFamilia);
        }

        public TipoCateringFamilia BuscarTipoCateringFamiliaPorGrupo(int grupoId, int tipoCateringId)
        {
            return Datos.BuscarTipoCateringFamiliaPorGrupo(grupoId, tipoCateringId);
        }
    }
}
