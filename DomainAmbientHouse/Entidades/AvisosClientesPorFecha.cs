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
    
    public partial class AvisosClientesPorFecha
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }
        public string RazonSocial { get; set; }
        public string Comentario { get; set; }
        public Nullable<System.DateTime> FechaAviso { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
    }
}
