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
    
    public partial class TipoComprobantes
    {
        public TipoComprobantes()
        {
            this.ComprobantesProveedores = new HashSet<ComprobantesProveedores>();
            this.FacturasCliente = new HashSet<FacturasCliente>();
            this.TipoComprobante_Impuestos = new HashSet<TipoComprobante_Impuestos>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> CondicionIvaId { get; set; }
    
        public virtual ICollection<ComprobantesProveedores> ComprobantesProveedores { get; set; }
        public virtual CondicionIva CondicionIva { get; set; }
        public virtual ICollection<FacturasCliente> FacturasCliente { get; set; }
        public virtual ICollection<TipoComprobante_Impuestos> TipoComprobante_Impuestos { get; set; }
    }
}
