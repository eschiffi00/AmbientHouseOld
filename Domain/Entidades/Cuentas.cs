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
    
    public partial class Cuentas
    {
        public Cuentas()
        {
            this.ComprobantesProveedores = new HashSet<ComprobantesProveedores>();
            this.Cuentas_Log = new HashSet<Cuentas_Log>();
            this.PagosProveedores = new HashSet<PagosProveedores>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoCuenta { get; set; }
    
        public virtual ICollection<ComprobantesProveedores> ComprobantesProveedores { get; set; }
        public virtual ICollection<Cuentas_Log> Cuentas_Log { get; set; }
        public virtual ICollection<PagosProveedores> PagosProveedores { get; set; }
    }
}
