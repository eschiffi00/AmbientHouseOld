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
    
    public partial class ProductosCateringItems
    {
        public int Id { get; set; }
        public int ProductoCateringId { get; set; }
        public int ItemId { get; set; }
    
        public virtual Items Items { get; set; }
        public virtual ProductosCatering ProductosCatering { get; set; }
    }
}
