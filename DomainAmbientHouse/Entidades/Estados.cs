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
    
    public partial class Estados
    {
        public Estados()
        {
            this.Adicionales = new HashSet<Adicionales>();
            this.Cheques = new HashSet<Cheques>();
            this.ComprobantesProveedores = new HashSet<ComprobantesProveedores>();
            this.Degustacion = new HashSet<Degustacion>();
            this.DegustacionDetalle = new HashSet<DegustacionDetalle>();
            this.Empleados = new HashSet<Empleados>();
            this.Eventos = new HashSet<Eventos>();
            this.FacturasCliente = new HashSet<FacturasCliente>();
            this.PagosClientes = new HashSet<PagosClientes>();
            this.Presupuestos = new HashSet<Presupuestos>();
            this.Usuarios = new HashSet<Usuarios>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Entidad { get; set; }
    
        public virtual ICollection<Adicionales> Adicionales { get; set; }
        public virtual ICollection<Cheques> Cheques { get; set; }
        public virtual ICollection<ComprobantesProveedores> ComprobantesProveedores { get; set; }
        public virtual ICollection<Degustacion> Degustacion { get; set; }
        public virtual ICollection<DegustacionDetalle> DegustacionDetalle { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Eventos> Eventos { get; set; }
        public virtual ICollection<FacturasCliente> FacturasCliente { get; set; }
        public virtual ICollection<PagosClientes> PagosClientes { get; set; }
        public virtual ICollection<Presupuestos> Presupuestos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
