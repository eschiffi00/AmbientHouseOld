//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Integracion.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class ObtenerPresupuestoSalon
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int LocacionId { get; set; }
        public double PrecioLista { get; set; }
        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }
        public byte[] Adjunto { get; set; }
        public string AdjuntoExtension { get; set; }
        public Nullable<double> ValorSeleccionado { get; set; }
        public Nullable<double> Descuentos { get; set; }
        public string Locacion { get; set; }
    }
}
