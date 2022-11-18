using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerFamilias
    {
		public int GrupoId { get; set; }
		public int CategoriaItemId { get; set; }
		public string Titulo { get; set; }
		public string Subtitulo { get; set; }
		public string Comentario { get; set; }
		public string Edad { get; set; }
		public string Fantasia { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"GrupoId: " + GrupoId.ToString() + "\r\n " + 
			"CategoriaItemId: " + CategoriaItemId.ToString() + "\r\n " + 
			"Titulo: " + Titulo.ToString() + "\r\n " + 
			"Subtitulo: " + Subtitulo.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " + 
			"Edad: " + Edad.ToString() + "\r\n " + 
			"Fantasia: " + Fantasia.ToString() + "\r\n " + 
			"Codigo: " + Codigo.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " ;
		}
        public ObtenerFamilias()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "GrupoId": return false;
				case "CategoriaItemId": return false;
				case "Titulo": return false;
				case "Subtitulo": return true;
				case "Comentario": return false;
				case "Edad": return true;
				case "Fantasia": return false;
				case "Codigo": return false;
				case "Descripcion": return false;
				default: return false;
			}
		}
    }
}

