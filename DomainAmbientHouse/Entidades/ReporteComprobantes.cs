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
    
    public partial class ReporteComprobantes
    {
        public int Id { get; set; }
        public long NroComprobante { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<double> MontoFactura { get; set; }
        public string Descripcion { get; set; }
        public string RazonSocial { get; set; }
        public string Cuenta { get; set; }
        public double NETO { get; set; }
        public string TipoImpuesto { get; set; }
        public double IMPUESTO { get; set; }
        public double IMPUESTOINTERNO { get; set; }
        public string FormadePago { get; set; }
        public string CC { get; set; }
        public string Leyenda { get; set; }
        public string Codigo { get; set; }
        public int TipoMoviemientoId { get; set; }
        public Nullable<int> PresupuestoId { get; set; }
    }
}
