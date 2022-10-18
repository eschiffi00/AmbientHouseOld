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
    
    public partial class LiquidacionHorasPersonal_Detalle
    {
        public int Id { get; set; }
        public int LiquidacionPersonalHoraId { get; set; }
        public int SectorEmpresaId { get; set; }
        public int TipoEmpleadoId { get; set; }
        public int EmpleadoId { get; set; }
        public int TipoPagoId { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public double Valor { get; set; }
        public int EstadoId { get; set; }
        public System.DateTime FechaCreate { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual LiquidacionHorasPersonal LiquidacionHorasPersonal { get; set; }
        public virtual TipoPagoEmpleados TipoPagoEmpleados { get; set; }
    }
}
