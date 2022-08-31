using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion.Entidades
{
  
        public partial class ReporteAdicionales
        {
            public int NroEvento { get; set; }
            public int NroPresupuesto { get; set; }
            public DateTime? FechaEvento { get; set; }

            public int AdicionalCant { get; set; }
            public double AdicionalValor { get; set; }

            public string Rubro { get; set; }
            public string AdicionalDesc { get; set; }

        }
    
}
