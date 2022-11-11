using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class ConfiguracionCateringTecnicaDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ConfiguracionCateringTecnicaDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ConfiguracionCateringTecnica> ObtenerConfiguracionCateringTecnica()
        {

            return SqlContext.ConfiguracionCateringTecnica.ToList();

        }

    }
}
