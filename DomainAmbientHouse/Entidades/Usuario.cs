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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.UsuarioRol = new HashSet<UsuarioRol>();
        }
    
        public int UsuarioId { get; set; }
        public string LoginName { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime FeCreacion { get; set; }
        public int NroDeFallos { get; set; }
        public int EsAdmin { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioIdCreador { get; set; }
    
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
