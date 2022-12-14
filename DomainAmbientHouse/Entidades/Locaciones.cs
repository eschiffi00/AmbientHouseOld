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
    
    public partial class Locaciones
    {
        public Locaciones()
        {
            this.AmbientacionSalon = new HashSet<AmbientacionSalon>();
            this.Categorias = new HashSet<Categorias>();
            this.CostoSalones = new HashSet<CostoSalones>();
            this.DegustacionDetalle = new HashSet<DegustacionDetalle>();
            this.Intermediarios = new HashSet<Intermediarios>();
            this.LocacionesValorAnio = new HashSet<LocacionesValorAnio>();
            this.Presupuestos = new HashSet<Presupuestos>();
            this.Sectores = new HashSet<Sectores>();
            this.TecnicaSalon = new HashSet<TecnicaSalon>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoLocacion { get; set; }
        public Nullable<int> CapacidadFormal { get; set; }
        public Nullable<int> CapacidadInformal { get; set; }
        public Nullable<int> CapacidadAuditorio { get; set; }
        public string Verde { get; set; }
        public string AireLibre { get; set; }
        public string Estacionamiento { get; set; }
        public string Comentarios { get; set; }
        public Nullable<double> UsoCocina { get; set; }
        public string TipoCannonCatering { get; set; }
        public Nullable<double> Cannon { get; set; }
        public string TipoCannonBarra { get; set; }
        public Nullable<double> CannonBarra { get; set; }
        public string TipoCannonAmbientacion { get; set; }
        public Nullable<double> CannonAmbientacion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string web { get; set; }
        public int LocalidadId { get; set; }
        public string TieneLogistica { get; set; }
        public string Comisiona { get; set; }
        public bool RequiereMesasSillas { get; set; }
        public Nullable<double> CostoSillas { get; set; }
        public Nullable<double> CostoMesas { get; set; }
        public Nullable<double> PrecioSillas { get; set; }
        public Nullable<double> PrecioMesas { get; set; }
    
        public virtual ICollection<AmbientacionSalon> AmbientacionSalon { get; set; }
        public virtual ICollection<Categorias> Categorias { get; set; }
        public virtual ICollection<CostoSalones> CostoSalones { get; set; }
        public virtual ICollection<DegustacionDetalle> DegustacionDetalle { get; set; }
        public virtual ICollection<Intermediarios> Intermediarios { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual ICollection<LocacionesValorAnio> LocacionesValorAnio { get; set; }
        public virtual ICollection<Presupuestos> Presupuestos { get; set; }
        public virtual ICollection<Sectores> Sectores { get; set; }
        public virtual ICollection<TecnicaSalon> TecnicaSalon { get; set; }
    }
}
