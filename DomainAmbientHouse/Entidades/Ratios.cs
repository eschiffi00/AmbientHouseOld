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
    
    public partial class Ratios
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ExperienciaBarra { get; set; }
        public int CategoriaId { get; set; }
        public string TipoRatio { get; set; }
        public string DetalleTipo { get; set; }
        public Nullable<double> ValorRatio { get; set; }
        public Nullable<double> TopeRatio { get; set; }
        public bool Menores3 { get; set; }
        public bool Menores3y8 { get; set; }
        public bool Adolescentes { get; set; }
        public bool AdicionalRatio { get; set; }
        public int EstadoId { get; set; }
    }
}
