using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class BancosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public BancosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Bancos> ObtenerBancos()
        {


            var query = from Tm in SqlContext.Bancos
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo
                        };



            List<Bancos> Salida = new List<Bancos>();
            foreach (var item in query)
            {

                Bancos cat = new Bancos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;


                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Codigo).ToList();


        }

    }
}
