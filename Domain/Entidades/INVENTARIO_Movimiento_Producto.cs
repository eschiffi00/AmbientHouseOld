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
    
    public partial class INVENTARIO_Movimiento_Producto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public System.DateTime Fecha { get; set; }
        public double CantidadAnterior { get; set; }
        public double CantidadNueva { get; set; }
        public int DepositoId { get; set; }
        public int EmpleadoId { get; set; }
    
        public virtual INVENTARIO_Producto INVENTARIO_Producto { get; set; }
    }
}
