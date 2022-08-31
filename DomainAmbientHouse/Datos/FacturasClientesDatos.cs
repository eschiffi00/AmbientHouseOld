using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Globalization;

namespace DomainAmbientHouse.Datos
{
    public class FacturasClientesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public ClientesDatos DatosClientes;

        public FacturasClientesDatos()
        {
            SqlContext = new AmbientHouseEntities();
            DatosClientes = new ClientesDatos();
        }


        private List<FacturasCliente> FacturasClienteToModel(IQueryable<FacturasCliente> query)
        {
            List<FacturasCliente> list = new List<FacturasCliente>();

            foreach (var item in query)
            {
                FacturasCliente salida = new FacturasCliente();

                salida.Id = item.Id;
                salida.Fecha = item.Fecha;
                salida.Importe = item.Importe;
                salida.NroFactura = item.NroFactura;
                salida.TipoComprobanteId = item.TipoComprobanteId;
                salida.TipoComprobanteDescripcion = SqlContext.TipoComprobantes.Single(o => o.Id == item.TipoComprobanteId).Descripcion;
                salida.ClienteId = item.ClienteId;
                salida.ClienteDescripcion = DatosClientes.ValidarCliente(item.ClienteId);
                salida.CUIT = DatosClientes.BuscarCliente(Int64.Parse(item.ClienteId.ToString())).CUILCUIT;
                salida.FacturaClienteDetalle = SqlContext.FacturaClienteDetalle.Where(o => o.FacturaClienteId == item.Id).ToList();
                salida.EmpresaId = item.EmpresaId;
                salida.PresupuestoId = item.PresupuestoId;
                salida.EmpresaDescripcion = SqlContext.Empresas.Single(o => o.Id == item.EmpresaId).RazonSocial;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Single(o => o.Id == item.EstadoId).Descripcion;

                list.Add(salida);
            }

            return list;
        }

        internal List<FacturasCliente> BuscarFacturasClientePorNroPresupuesto(int presupuestoId)
        {
            var query = from t in SqlContext.FacturasCliente
                        where t.PresupuestoId == presupuestoId
                        select t;


            return FacturasClienteToModel(query).ToList();

        }

        public virtual FacturasCliente BuscarFacturaCliente(int id)
        {

            var query = from t in SqlContext.FacturasCliente
                        where t.Id == id
                        select t;


            return FacturasClienteToModel(query).SingleOrDefault();

        }

        public void GrabarFacturasCliente(FacturasCliente factura)
        {


            try
            {

                if (factura.Id > 0)
                {
                    FacturasCliente edit = SqlContext.FacturasCliente.Where(o => o.Id == factura.Id).FirstOrDefault();

                    edit.ClienteId = factura.ClienteId;
                    edit.TipoComprobanteId = factura.TipoComprobanteId;
                    edit.EmpresaId = factura.EmpresaId;
                    edit.Fecha = factura.Fecha;
                    edit.NroFactura = factura.NroFactura;
                    edit.Importe = factura.Importe;
                    edit.PresupuestoId = factura.PresupuestoId;
                    edit.EstadoId = factura.EstadoId;
                    edit.UpdateFecha = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    //return true;

                }
                else
                {
                    factura.CreateFecha = System.DateTime.Now;

                    SqlContext.FacturasCliente.Add(factura);
                    SqlContext.SaveChanges();

                    //return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }

        }

        public bool ElimnarFacturaCliente(int id)
        {
            if (id > 0)
            {
                FacturasCliente edit = BuscarFacturaCliente(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.FechaDelete = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        public List<FacturasCliente> ListarFacturasClientes(FacturasClienteSearcher searcher)
        {
            var query = from c in SqlContext.FacturasCliente
                        join cb in SqlContext.ClientesBis on c.ClienteId equals cb.Id
                        where c.Delete == false
                        select c;

           

            if (Int32.Parse(searcher.EmpresaId.ToString()) > 0)
                query = query.Where(o => o.EmpresaId == searcher.EmpresaId);

            if (!String.IsNullOrWhiteSpace(searcher.PresupuestoId))
            {
                int nroPresupuestoId = Int32.Parse(searcher.PresupuestoId);
                query = query.Where(o => o.PresupuestoId == nroPresupuestoId);
            }


            if (Int32.Parse(searcher.EstadoId.ToString()) > 0)
                query = query.Where(o => o.EstadoId == searcher.EstadoId);

            if (!String.IsNullOrWhiteSpace(searcher.NroFactura))
            {
                int nroFactura = Int32.Parse(searcher.NroFactura);
                query = query.Where(o => o.NroFactura == nroFactura);
            }

            if (!string.IsNullOrEmpty(searcher.FechaHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha <= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha >= fecha);
            }

            return FacturasClienteToModel(query).OrderBy(o => o.EmpresaId).OrderBy(o => o.NroFactura).ToList();
        }

        internal bool ExisteFacturaPorEmpresayNro(int empresaId, int nroFactura, int tipoComprobanteId)
        {
            return SqlContext.FacturasCliente.Where(o => o.EmpresaId == empresaId && o.NroFactura == nroFactura && o.TipoComprobanteId == tipoComprobanteId).Count() > 0;
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class FacturasCliente
    {
        public string TipoComprobanteDescripcion { get; set; }

        public string ClienteDescripcion { get; set; }

        public string CUIT { get; set; }

        public string EmpresaDescripcion { get; set; }

        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaStr
        {
            get
            {
                return String.Format(formatoFecha, Fecha);
            }
            set
            {
                Fecha = DateTime.ParseExact(FechaStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }


        public string EstadoDescripcion { get; set; }
    }

    public partial class FacturasClienteSearcher
    {
        public int EmpresaId { get; set; }
        public int EstadoId { get; set; }
        public string PresupuestoId { get; set; }
        public string NroFactura { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
    }
}
