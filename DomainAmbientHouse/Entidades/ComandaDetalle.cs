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
    
    public partial class ComandaDetalle
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public string Clave { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<bool> EsItem { get; set; }
        public Nullable<bool> EsProducto { get; set; }
        public Nullable<bool> EsAdicional { get; set; }
        public Nullable<int> Orden { get; set; }
    }
}
