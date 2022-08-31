using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Globalization;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class ChequesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public ClientesDatos DatosClientes;
        public ProveedoresDatos DatosProveedores;

        public ChequesDatos()
        {
            SqlContext = new AmbientHouseEntities();

            DatosClientes = new ClientesDatos();
            DatosProveedores = new ProveedoresDatos();
        }

        private List<Cheques> ChequesToModel(IQueryable<Cheques> query)
        {
            List<Cheques> list = new List<Cheques>();

            foreach (var item in query)
            {
                Cheques salida = new Cheques();

                salida.Id = item.Id;
                salida.FechaEmision = item.FechaEmision;
                salida.Importe = item.Importe;
                salida.FechaVencimiento = item.FechaVencimiento;
                salida.NroCheque = item.NroCheque;
                salida.BancoId = item.BancoId;
                salida.BancoDescripcion = SqlContext.Bancos.Where(o => o.Id == item.BancoId).SingleOrDefault().Descripcion;
                salida.ClienteId = item.ClienteId;
                salida.ClienteDescripcion = DatosClientes.ValidarCliente(item.ClienteId);
                salida.ProveedorId = item.ClienteId;
                salida.ProveedorDescripcion = DatosProveedores.ValidarProveedores(item.ProveedorId);
                salida.ProveedorId = item.ProveedorId;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Where(o => o.Id == item.EstadoId).SingleOrDefault().Descripcion;
                salida.Observaciones = item.Observaciones;

                Cuentas cuenta = BuscarCuentaPorCheque(item.Id);

                if (cuenta != null)
                {
                    salida.CuentaId = cuenta.Id;
                    salida.CuentaDescripcion = cuenta.Nombre;
                }
                else
                {
                    if (item.CuentaId == null)
                    {

                        salida.CuentaId = null;
                        salida.CuentaDescripcion = "";
                    }
                    else
                    {
                        salida.CuentaId = item.CuentaId;
                        salida.CuentaDescripcion = SqlContext.Cuentas.Single(o => o.Id == item.CuentaId).Nombre;
                    }
                }

                list.Add(salida);
            }

            return list;
        }


        internal Cuentas BuscarCuentaPorCheque(int chequeId)
        {

            var query = from C in SqlContext.Cheques
                        join Cp in SqlContext.ChequesPagosProveedores on C.Id equals Cp.ChequeId
                        join Pp in SqlContext.PagosProveedores on Cp.PagoProveedorId equals Pp.Id
                        join Cu in SqlContext.Cuentas on Pp.CuentaId equals Cu.Id
                        where C.Id == chequeId
                        select Cu;


            return query.FirstOrDefault();
        }

        public virtual List<Cheques> ObtenerCheqhes()
        {

            var query = from c in SqlContext.Cheques
                        join b in SqlContext.Bancos on c.BancoId equals b.Id
                        join p in SqlContext.Proveedores on c.ProveedorId equals p.Id into ps
                        from p in ps.DefaultIfEmpty()
                        join e in SqlContext.Estados on c.EstadoId equals e.Id
                        select new
                        {
                            Id = c.Id,
                            NroCheque = c.NroCheque,
                            Importe = c.Importe,
                            FechaEmision = c.FechaEmision,
                            FechaVencimiento = c.FechaVencimiento,
                            Observaciones = c.Observaciones,
                            EstadoId = c.EstadoId,
                            EstadoDescripcion = e.Descripcion,
                            BancoId = c.BancoId,
                            BancoDescripcion = b.Descripcion,
                            ProveedorId = (c.ProveedorId == null ? null : c.ProveedorId),
                            ProveedorRazonSocial = (p.RazonSocial == null ? String.Empty : p.RazonSocial),

                        };

            List<Cheques> Salida = new List<Cheques>();
            foreach (var item in query)
            {

                Cheques cat = new Cheques();

                cat.Id = item.Id;
                cat.NroCheque = item.NroCheque;
                cat.Importe = item.Importe;
                cat.FechaEmision = item.FechaEmision;
                cat.FechaVencimiento = item.FechaVencimiento;
                cat.Observaciones = item.Observaciones;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.BancoId = item.BancoId;
                cat.BancoDescripcion = item.BancoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public virtual void NuevosCheques(Cheques cheque)
        {
            if (cheque.Id > 0)
            {
                Cheques editCheque = SqlContext.Cheques.Where(o => o.Id == cheque.Id).FirstOrDefault();

                editCheque.NroCheque = cheque.NroCheque;
                editCheque.Importe = cheque.Importe;
                editCheque.FechaEmision = cheque.FechaEmision;
                editCheque.FechaVencimiento = cheque.FechaVencimiento;
                editCheque.BancoId = cheque.BancoId;
                editCheque.Observaciones = cheque.Observaciones;
                editCheque.TipoCheque = cheque.TipoCheque;
                editCheque.EstadoId = cheque.EstadoId;
                editCheque.ProveedorId = cheque.ProveedorId;
                editCheque.ClienteId = cheque.ClienteId;
                editCheque.CuentaId = cheque.CuentaId;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.Cheques.Add(cheque);
                SqlContext.SaveChanges();
            }

        }

        public void GrabarChequePagoProveedor(ChequesPagosProveedores chequesPagos)
        {
            SqlContext.ChequesPagosProveedores.Add(chequesPagos);
            SqlContext.SaveChanges();

        }

        public bool GrabarChequesClientes(Cheques cheque)
        {
            try
            {
                SqlContext.Cheques.Add(cheque);
                SqlContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Cheques BuscarCheque(int id)
        {
            return SqlContext.Cheques.Where(o => o.Id == id).SingleOrDefault();

        }

        public List<Cheques> ListarCheques(ChequesSearcher searcher)
        {
            var query = from t in SqlContext.Cheques
                        select t;


            //if (!string.IsNullOrEmpty(searcher.EstadoId)) // != "0")
            if (searcher.EstadoId != "0")
            {
                if (searcher.EstadoId != null)
                {
                    int estado = Int32.Parse(searcher.EstadoId);
                    query = query.Where(o => o.EstadoId == estado);
                }
            }

            if (!string.IsNullOrEmpty(searcher.NroCheque))
                query = query.Where(o => o.NroCheque.Contains(searcher.NroCheque));

            if (!string.IsNullOrEmpty(searcher.FechaEmisionDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaEmisionDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEmision >= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaEmisionHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaEmisionHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEmision <= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaVencimientoHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaVencimientoHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaVencimiento <= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaVencimientoDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaVencimientoDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaVencimiento >= fecha);
            }

            //if (searcher.CuentaId != "0")
            //{
            //    int cuentaId = Int32.Parse(searcher.CuentaId);
            //    query = query.Where(o => o.CuentaId == cuentaId);
            //}

            if (!string.IsNullOrEmpty(searcher.Importe))
                query = query.Where(o => o.Importe == double.Parse(searcher.Importe));


            if (!string.IsNullOrEmpty(searcher.RazonSocial))
            {
                query = from q in query
                        join c in SqlContext.ClientesBis on q.ClienteId equals c.Id into CS
                        from c in CS.DefaultIfEmpty()
                        join p in SqlContext.Proveedores on q.ProveedorId equals p.Id into PS
                        from p in PS.DefaultIfEmpty()
                        where (c.RazonSocial.Contains(searcher.RazonSocial)
                                || c.ApellidoNombre.Contains(searcher.RazonSocial))
                                || p.RazonSocial.Contains(searcher.RazonSocial)
                        select q;

            }



            return ChequesToModel(query).OrderBy(o => o.FechaVencimiento).ToList();
        }

    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class Cheques
    {
        public string ClienteDescripcion { get; set; }
        public string ProveedorDescripcion { get; set; }
        public string BancoDescripcion { get; set; }
        public string EstadoDescripcion { get; set; }
        public string ProveedorRazonSocial { get; set; }
        //public int? CuentaId { get; set; }
        public string CuentaDescripcion { get; set; }

        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaVencimientoStr
        {
            get
            {
                return String.Format(formatoFecha, FechaVencimiento);
            }
            set
            {
                FechaVencimiento = DateTime.ParseExact(FechaVencimientoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string FechaEmisionStr
        {
            get
            {
                return String.Format(formatoFecha, FechaEmision);
            }
            set
            {
                FechaEmision = DateTime.ParseExact(FechaEmisionStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }



        public double Saldo { get; set; }

        public string SaldoStr
        {
            get
            {
                return System.Math.Round((double)Saldo, 2).ToString("C");
            }

        }
    }

    public class ChequesSearcher
    {
        public string NroCheque { get; set; }
        public string FechaVencimientoDesde { get; set; }
        public string FechaVencimientoHasta { get; set; }
        public string FechaEmisionDesde { get; set; }
        public string FechaEmisionHasta { get; set; }
        public string RazonSocial { get; set; }
        public string Importe { get; set; }
        public string CuentaId { get; set; }
        public string CuentaDescripcion { get; set; }
        public string EstadoId { get; set; }
    }
}