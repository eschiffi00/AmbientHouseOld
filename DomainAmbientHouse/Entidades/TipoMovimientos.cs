//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoMovimientos
    {
        public TipoMovimientos()
        {
            this.ComprobantesProveedores_Detalles = new HashSet<ComprobantesProveedores_Detalles>();
            this.Movimientos = new HashSet<Movimientos>();
            this.PagosClientes = new HashSet<PagosClientes>();
            this.Retenciones = new HashSet<Retenciones>();
            this.UnidadesNegocios_TipoMovimientos = new HashSet<UnidadesNegocios_TipoMovimientos>();
        }
    
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Visible { get; set; }
        public Nullable<bool> IsEgreso { get; set; }
        public Nullable<bool> IsIngreso { get; set; }
        public string TipoGasto { get; set; }
    
        public virtual ICollection<ComprobantesProveedores_Detalles> ComprobantesProveedores_Detalles { get; set; }
        public virtual ICollection<Movimientos> Movimientos { get; set; }
        public virtual ICollection<PagosClientes> PagosClientes { get; set; }
        public virtual ICollection<Retenciones> Retenciones { get; set; }
        public virtual ICollection<UnidadesNegocios_TipoMovimientos> UnidadesNegocios_TipoMovimientos { get; set; }
    }
}
