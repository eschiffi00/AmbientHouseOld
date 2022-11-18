using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerArchivosPorCategorias
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public object Archivo { get; set; }
		public string ExtencionArchivo { get; set; }
		public int? CategoriaArchivoId { get; set; }
		public int? CarpetaId { get; set; }
		public string Carpeta { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"Archivo: " + Archivo.ToString() + "\r\n " + 
			"ExtencionArchivo: " + ExtencionArchivo.ToString() + "\r\n " + 
			"CategoriaArchivoId: " + CategoriaArchivoId.ToString() + "\r\n " + 
			"CarpetaId: " + CarpetaId.ToString() + "\r\n " + 
			"Carpeta: " + Carpeta.ToString() + "\r\n " ;
		}
        public ObtenerArchivosPorCategorias()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Descripcion": return false;
				case "Archivo": return true;
				case "ExtencionArchivo": return true;
				case "CategoriaArchivoId": return true;
				case "CarpetaId": return true;
				case "Carpeta": return true;
				default: return false;
			}
		}
    }
}

