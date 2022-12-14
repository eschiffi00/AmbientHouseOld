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
    
    public partial class CategoriasItem
    {
        public CategoriasItem()
        {
            this.Familias = new HashSet<Familias>();
            this.Items = new HashSet<Items>();
            this.Items2 = new HashSet<Items2>();
            this.TipoBarraCategoriaItem = new HashSet<TipoBarraCategoriaItem>();
            this.TipoCateringTiempoProductoItem = new HashSet<TipoCateringTiempoProductoItem>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> CategoriaItemPadreId { get; set; }
        public int EstadoId { get; set; }
    
        public virtual ICollection<Familias> Familias { get; set; }
        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Items2> Items2 { get; set; }
        public virtual ICollection<TipoBarraCategoriaItem> TipoBarraCategoriaItem { get; set; }
        public virtual ICollection<TipoCateringTiempoProductoItem> TipoCateringTiempoProductoItem { get; set; }
    }
}
