//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostoCanon
    {
        public int Id { get; set; }
        public int SegmentoId { get; set; }
        public int CaracteristicaId { get; set; }
        public int TipoCateringId { get; set; }
        public Nullable<double> CanonInterno { get; set; }
        public Nullable<double> CanonExterno { get; set; }
        public Nullable<double> UsoCocina { get; set; }
    
        public virtual Caracteristicas Caracteristicas { get; set; }
        public virtual Segmentos Segmentos { get; set; }
        public virtual TipoCatering TipoCatering { get; set; }
    }
}
