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
    
    public partial class Segmentos
    {
        public Segmentos()
        {
            this.Categorias = new HashSet<Categorias>();
            this.ConfiguracionCateringTecnica = new HashSet<ConfiguracionCateringTecnica>();
            this.CostoCanon = new HashSet<CostoCanon>();
            this.CostosPaquetesCIAmbientacion = new HashSet<CostosPaquetesCIAmbientacion>();
            this.CostoTecnica = new HashSet<CostoTecnica>();
            this.DegustacionDetalle = new HashSet<DegustacionDetalle>();
            this.Presupuestos = new HashSet<Presupuestos>();
            this.TiposBarras = new HashSet<TiposBarras>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Categorias> Categorias { get; set; }
        public virtual ICollection<ConfiguracionCateringTecnica> ConfiguracionCateringTecnica { get; set; }
        public virtual ICollection<CostoCanon> CostoCanon { get; set; }
        public virtual ICollection<CostosPaquetesCIAmbientacion> CostosPaquetesCIAmbientacion { get; set; }
        public virtual ICollection<CostoTecnica> CostoTecnica { get; set; }
        public virtual ICollection<DegustacionDetalle> DegustacionDetalle { get; set; }
        public virtual ICollection<Presupuestos> Presupuestos { get; set; }
        public virtual ICollection<TiposBarras> TiposBarras { get; set; }
    }
}
