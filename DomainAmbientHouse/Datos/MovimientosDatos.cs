using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class MovimientosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public MovimientosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual void NuevoMovimiento(Movimientos mov)
        {
            SqlContext.Movimientos.Add(mov);
            SqlContext.SaveChanges();
        }

    }
}
