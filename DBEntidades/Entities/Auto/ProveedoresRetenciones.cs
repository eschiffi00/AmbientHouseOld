using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ProveedoresRetenciones
    {
		public int Id { get; set; }
		public int ProveedorId { get; set; }
		public int TablaRetencionId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ProveedorId: " + ProveedorId.ToString() + "\r\n " + 
			"TablaRetencionId: " + TablaRetencionId.ToString() + "\r\n " ;
		}
        public ProveedoresRetenciones()
        {
            Id = -1;

        }

		public Proveedores GetRelatedProveedorId()
		{
			Proveedores proveedores = ProveedoresOperator.GetOneByIdentity(ProveedorId);
			return proveedores;
		}

		public TABLA_Retenciones GetRelatedTablaRetencionId()
		{
			TABLA_Retenciones tABLA_Retenciones = TABLA_RetencionesOperator.GetOneByIdentity(TablaRetencionId);
			return tABLA_Retenciones;
		}





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ProveedorId": return false;
				case "TablaRetencionId": return false;
				default: return false;
			}
		}
    }
}

