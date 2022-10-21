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
    
    public partial class Cheques
    {
        public Cheques()
        {
            this.ChequesPagosProveedores = new HashSet<ChequesPagosProveedores>();
            this.Eventos = new HashSet<Eventos>();
        }
    
        public int Id { get; set; }
        public string NroCheque { get; set; }
        public double Importe { get; set; }
        public string EmitidoA { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public int BancoId { get; set; }
        public string Observaciones { get; set; }
        public string TipoCheque { get; set; }
        public int EstadoId { get; set; }
        public Nullable<int> CuentaId { get; set; }
    
        public virtual Bancos Bancos { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual ICollection<ChequesPagosProveedores> ChequesPagosProveedores { get; set; }
        public virtual ICollection<Eventos> Eventos { get; set; }
    }
}
