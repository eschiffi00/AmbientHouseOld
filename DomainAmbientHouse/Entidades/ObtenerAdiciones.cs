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
    
    public partial class ObtenerAdiciones
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<double> Precio { get; set; }
        public int RubroId { get; set; }
        public string Rubro { get; set; }
        public int EstadoId { get; set; }
        public string EstadoDescripcion { get; set; }
        public string RequiereCantidad { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public Nullable<double> Costo { get; set; }
    }
}
