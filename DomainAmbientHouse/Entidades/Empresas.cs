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
    
    public partial class Empresas
    {
        public Empresas()
        {
            this.Cuentas = new HashSet<Cuentas>();
            this.FacturasCliente = new HashSet<FacturasCliente>();
            this.PagosClientes = new HashSet<PagosClientes>();
        }
    
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public bool TipoEmpresa { get; set; }
        public string CondicionIva { get; set; }
    
        public virtual ICollection<Cuentas> Cuentas { get; set; }
        public virtual ICollection<FacturasCliente> FacturasCliente { get; set; }
        public virtual ICollection<PagosClientes> PagosClientes { get; set; }
    }
}
