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
    
    public partial class ClientesEventosMovimientos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EventoId { get; set; }
        public string Comentario { get; set; }
        public System.DateTime FechaSeguimiento { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
    }
}
