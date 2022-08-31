//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class PagosClientes
    {
        public PagosClientes()
        {
            this.Retenciones = new HashSet<Retenciones>();
        }
    
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int EmpresaId { get; set; }
        public Nullable<int> ProveedorCannonId { get; set; }
        public int FormadePagoId { get; set; }
        public int TipoMovimientoId { get; set; }
        public System.DateTime FechaPago { get; set; }
        public double Importe { get; set; }
        public string Concepto { get; set; }
        public string NroRecibo { get; set; }
        public System.DateTime FechaCreate { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
        public int EmpleadoId { get; set; }
        public Nullable<double> Indexacion { get; set; }
        public Nullable<double> IvaPorcentaje { get; set; }
        public int CuentaId { get; set; }
        public string TipoPago { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual FormasdePago FormasdePago { get; set; }
        public virtual Presupuestos Presupuestos { get; set; }
        public virtual TipoMovimientos TipoMovimientos { get; set; }
        public virtual ICollection<Retenciones> Retenciones { get; set; }
    }
}
