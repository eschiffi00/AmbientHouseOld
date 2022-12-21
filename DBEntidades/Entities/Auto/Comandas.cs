using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class Comandas
    {
		public int Id { get; set; }
		public int PresupuestoId { get; set; }
		public DateTime? fechaEvento { get; set; }
		public string Locacion { get; set; }
		public string HorarioLlegada { get; set; }
		public string HorarioInicio { get; set; }
		public string HorarioFin { get; set; }
		public string TipoEvento { get; set; }
		public string TipoExperiencia { get; set; }
		public int? Duracion { get; set; }
		public string Empresa { get; set; }
		public string Organizador { get; set; }
		public string Maitre { get; set; }
		public string Coordinador { get; set; }
		public string JefeProducto { get; set; }
		public int? Adultos { get; set; }
		public int? Menores3 { get; set; }
		public int? Menores3y8 { get; set; }
		public int? Adolescentes { get; set; }
		public int EstadoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"fechaEvento: " + fechaEvento.ToString() + "\r\n " + 
			"Locacion: " + Locacion.ToString() + "\r\n " + 
			"HorarioLlegada: " + HorarioLlegada.ToString() + "\r\n " + 
			"HorarioInicio: " + HorarioInicio.ToString() + "\r\n " + 
			"HorarioFin: " + HorarioFin.ToString() + "\r\n " + 
			"TipoEvento: " + TipoEvento.ToString() + "\r\n " + 
			"TipoExperiencia: " + TipoExperiencia.ToString() + "\r\n " + 
			"Duracion: " + Duracion.ToString() + "\r\n " + 
			"Empresa: " + Empresa.ToString() + "\r\n " + 
			"Organizador: " + Organizador.ToString() + "\r\n " + 
			"Maitre: " + Maitre.ToString() + "\r\n " + 
			"Coordinador: " + Coordinador.ToString() + "\r\n " + 
			"JefeProducto: " + JefeProducto.ToString() + "\r\n " + 
			"Adultos: " + Adultos.ToString() + "\r\n " + 
			"Menores3: " + Menores3.ToString() + "\r\n " + 
			"Menores3y8: " + Menores3y8.ToString() + "\r\n " + 
			"Adolescentes: " + Adolescentes.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " ;
		}
        public Comandas()
        {
            Id = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "PresupuestoId": return false;
				case "fechaEvento": return true;
				case "Locacion": return true;
				case "HorarioLlegada": return true;
				case "HorarioInicio": return true;
				case "HorarioFin": return true;
				case "TipoEvento": return true;
				case "TipoExperiencia": return true;
				case "Duracion": return true;
				case "Empresa": return true;
				case "Organizador": return true;
				case "Maitre": return true;
				case "Coordinador": return true;
				case "JefeProducto": return true;
				case "Adultos": return true;
				case "Menores3": return true;
				case "Menores3y8": return true;
				case "Adolescentes": return true;
				case "EstadoId": return false;
				default: return false;
			}
		}
    }
}

