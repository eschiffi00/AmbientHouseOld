using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TABLARetencionesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public TABLARetencionesDatos()
        {
            SqlContext = new AmbientHouseEntities();

        }

        private List<TABLA_Retenciones> TABLARetencionesToModel(IQueryable<TABLA_Retenciones> query)
        {
            List<TABLA_Retenciones> list = new List<TABLA_Retenciones>();

            foreach (var item in query)
            {
                TABLA_Retenciones salida = new TABLA_Retenciones();

                salida.Id = item.Id;
                salida.Concepto = item.Concepto;
                salida.PorcentajeInscripto = item.PorcentajeInscripto;
                salida.PorcentajeNoInscripto = item.PorcentajeNoInscripto;
                salida.ValorMaximoaRetenerInscriptos = item.ValorMaximoaRetenerInscriptos;

                list.Add(salida);
            }

            return list;
        }



        public virtual List<TABLA_Retenciones> ObtenerTABLA_Retenciones()
        {

            var query = from c in SqlContext.TABLA_Retenciones
                        select c;

            return TABLARetencionesToModel(query).ToList();

        }


    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class TABLA_Retenciones
    {

    }

    public class TABLA_RetencionesSearcher
    {

    }
}