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
    
    public partial class ObtenerPresupuestoTecnica
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int CanalId { get; set; }
        public int TipoServicioId { get; set; }
        public int ProveedorId { get; set; }
        public double PrecioLista { get; set; }
        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }
        public byte[] Adjunto { get; set; }
        public string AdjuntoExtension { get; set; }
        public Nullable<double> ValorSeleccionado { get; set; }
        public Nullable<double> Descuentos { get; set; }
        public string Canal { get; set; }
        public string TipoServicio { get; set; }
        public string RazonSocial { get; set; }
    }
}
