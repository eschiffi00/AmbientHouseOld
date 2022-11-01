using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
	public partial class TiposBarrasComun
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
	}
}

