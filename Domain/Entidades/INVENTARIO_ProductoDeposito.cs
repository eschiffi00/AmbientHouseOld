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
    
    public partial class INVENTARIO_ProductoDeposito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int DepositoId { get; set; }
        public double Cantidad { get; set; }
        public int UnidadId { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
    
        public virtual INVENTARIO_Depositos INVENTARIO_Depositos { get; set; }
        public virtual INVENTARIO_Producto INVENTARIO_Producto { get; set; }
    }
}
