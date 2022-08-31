using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

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
