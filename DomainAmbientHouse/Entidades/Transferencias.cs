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
    
    public partial class Transferencias
    {
        public int Id { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public int BancoId { get; set; }
        public string NroTransferencia { get; set; }
        public double Importe { get; set; }
        public string NombreArchivo { get; set; }
        public byte[] Comprobante { get; set; }
        public string ComprobanteExtension { get; set; }
        public System.DateTime FechaTransferencia { get; set; }
        public System.DateTime FechaCreate { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
    
        public virtual Bancos Bancos { get; set; }
    }
}
