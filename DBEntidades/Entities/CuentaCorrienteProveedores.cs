using System;

namespace DbEntidades.Entities
{
    public partial class CuentaCorrienteProveedores
    {

        public string NroComprobante { get; set; }
        public string CuitProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public int NroPresupuesto { get; set; }
        public DateTime FechaPresupuesto { get; set; }
        public DateTime FechaEvento { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string NroTransaccion { get; set; }
        public double ValorNetoFactura { get; set; }
        public double ValorImpuesto { get; set; }
        public double ValorImpuestoInterno { get; set; }
        public double ImporteSinIVA { get; set; }
        public double SaldoPendiente { get; set; }

    }
    public partial class parametros2
    {
        public string CuitProveedor { get; set; }
        public int NroPresupuesto { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string TipoMovimiento { get; set; }
        public parametros2()
        {
            CuitProveedor = "";
            NroPresupuesto = 0;
        }
    }

}
