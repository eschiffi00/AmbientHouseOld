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
    
    public partial class Tiempos
    {
        public Tiempos()
        {
            this.TipoCateringTiempoProductoItem = new HashSet<TipoCateringTiempoProductoItem>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Orden { get; set; }
    
        public virtual ICollection<TipoCateringTiempoProductoItem> TipoCateringTiempoProductoItem { get; set; }
    }
}
