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
    
    public partial class informeCorrienteProveedor_Result
    {
        public string CuitProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public Nullable<int> NroPresupuesto { get; set; }
        public Nullable<System.DateTime> FechaPresupuesto { get; set; }
        public Nullable<System.DateTime> FechaEvento { get; set; }
        public string TipoTransaccion { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public string NroTransaccion { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<double> ImporteSinIVA { get; set; }
        public Nullable<double> SaldoPendiente { get; set; }
    }
}
