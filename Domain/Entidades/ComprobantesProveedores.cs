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
    
    public partial class ComprobantesProveedores
    {
        public ComprobantesProveedores()
        {
            this.ComprobantePagoProveedor = new HashSet<ComprobantePagoProveedor>();
            this.ComprobantesProveedores_Detalles = new HashSet<ComprobantesProveedores_Detalles>();
            this.NotaCreditos = new HashSet<NotaCreditos>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public Nullable<int> CuentaId { get; set; }
        public int TipoComprobanteId { get; set; }
        public int FormadePagoId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public double MontoNeto { get; set; }
        public Nullable<double> MontoFactura { get; set; }
        public long NroComprobante { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<double> Iva21 { get; set; }
        public Nullable<double> Iva27 { get; set; }
        public Nullable<double> Iva105 { get; set; }
        public Nullable<double> IIBBCABA { get; set; }
        public Nullable<double> IIBBARBA { get; set; }
        public Nullable<double> PercepcionIVA { get; set; }
        public string GeneraOP { get; set; }
        public int EstadoId { get; set; }
        public System.DateTime CreateFecha { get; set; }
        public Nullable<System.DateTime> UpdateFecha { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> DeleteFecha { get; set; }
    
        public virtual ICollection<ComprobantePagoProveedor> ComprobantePagoProveedor { get; set; }
        public virtual Cuentas Cuentas { get; set; }
        public virtual ICollection<ComprobantesProveedores_Detalles> ComprobantesProveedores_Detalles { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual FormasdePago FormasdePago { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public virtual TipoComprobantes TipoComprobantes { get; set; }
        public virtual ICollection<NotaCreditos> NotaCreditos { get; set; }
    }
}
