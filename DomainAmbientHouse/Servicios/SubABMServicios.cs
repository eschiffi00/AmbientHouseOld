using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;

namespace DomainAmbientHouse.Servicios
{
    public class SubABMServicios
    {

        SectoresNegocios NegociosSectores;

        public SubABMServicios()
        {
            NegociosSectores = new SectoresNegocios();
        }

        //public List<ListItem> ObtenerSectoresPorLocacion(int locacionId)
        //{
        //    return NegociosSectores.ObtenerSectoresPorLocacion(locacionId).Select(o => new ListItem { Value = o.Id.ToString(), Text = o.Descripcion }).OrderBy(o => o.Text).ToList();
        //}


    }
}
