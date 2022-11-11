using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TransferenciasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public ClientesDatos DatosClientes;
        public ProveedoresDatos DatosProveedores;

        public TransferenciasDatos()
        {
            SqlContext = new AmbientHouseEntities();

            DatosClientes = new ClientesDatos();
            DatosProveedores = new ProveedoresDatos();
        }

        public virtual List<Transferencias> ObtenerTransferencias()
        {

            var query = from c in SqlContext.Transferencias
                        select c;



            return TransferenciaToModel(query).ToList();

        }

        private List<Transferencias> TransferenciaToModel(IQueryable<Transferencias> query)
        {
            List<Transferencias> list = new List<Transferencias>();

            foreach (var item in query)
            {
                Transferencias salida = new Transferencias();

                salida.Id = item.Id;
                salida.FechaTransferencia = item.FechaTransferencia;
                salida.Importe = item.Importe;
                salida.NroTransferencia = item.NroTransferencia;
                salida.BancoId = item.BancoId;
                salida.BancoDescripcion = SqlContext.Bancos.Where(o => o.Id == item.BancoId).SingleOrDefault().Descripcion;
                salida.ClienteId = item.ClienteId;
                salida.ClienteDescripcion = DatosClientes.ValidarCliente(item.ClienteId);
                salida.ProveedorId = item.ClienteId;
                salida.ProveedorDescripcion = DatosProveedores.ValidarProveedores(item.ProveedorId);
                salida.ProveedorId = item.ProveedorId;
                salida.Comprobante = item.Comprobante;
                salida.ComprobanteExtension = item.ComprobanteExtension;


                list.Add(salida);
            }

            return list;
        }





        public virtual bool GrabarTransferencias(Transferencias transferencia)
        {

            try
            {

                if (transferencia.Id > 0)
                {
                    Transferencias edit = SqlContext.Transferencias.Where(o => o.Id == transferencia.Id).FirstOrDefault();

                    edit.ClienteId = transferencia.ClienteId;
                    edit.ProveedorId = transferencia.ProveedorId;
                    edit.FechaTransferencia = transferencia.FechaTransferencia;
                    edit.NroTransferencia = transferencia.NroTransferencia;
                    edit.Comprobante = transferencia.Comprobante;
                    edit.ComprobanteExtension = transferencia.ComprobanteExtension;
                    edit.Importe = transferencia.Importe;
                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    transferencia.FechaCreate = System.DateTime.Now;

                    SqlContext.Transferencias.Add(transferencia);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Transferencias BuscarTransferencia(int id)
        {

            var query = from t in SqlContext.Transferencias
                        where t.Id == id
                        select t;


            return TransferenciaToModel(query).SingleOrDefault();

        }

        public bool ElimnarTransferencia(int id)
        {
            if (id > 0)
            {
                Transferencias edit = BuscarTransferencia(id);

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

        public Transferencias BuscarTransferencia(string filtro)
        {
            //filtro.IndexOf("|");

            //string condicion = filtro.StartsWith(

            return new Transferencias();

        }

        public Transferencias BuscarTransferenciaPorNroComprobante(string nroComprobante)
        {
            return SqlContext.Transferencias.Where(o => o.NroTransferencia.Equals(nroComprobante)).FirstOrDefault();
        }

        public List<Transferencias> ListarTransferencias(TransferenciasSearcher searcher)
        {
            var query = from t in SqlContext.Transferencias
                        select t;


            if (!string.IsNullOrEmpty(searcher.NroTransferencia))
                query = query.Where(o => o.NroTransferencia.Contains(searcher.NroTransferencia));

            if (!string.IsNullOrEmpty(searcher.FechaTransferencia))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaTransferencia, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaTransferencia == fecha);
            }

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
            if (!string.IsNullOrEmpty(searcher.Cuit))
            {

                query = from q in query
                        join c in SqlContext.ClientesBis on q.ClienteId equals c.Id into CS
                        from c in CS.DefaultIfEmpty()
                        join p in SqlContext.Proveedores on q.ProveedorId equals p.Id into PS
                        from p in PS.DefaultIfEmpty()
                        where (c.CUILCUIT.Contains(searcher.Cuit)
                                || p.Cuit.Contains(searcher.Cuit))
                        select q;

            }

            return TransferenciaToModel(query).ToList();
        }

    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class Transferencias
    {
        //public Comun cmd = new Comun();

        public string BancoDescripcion { get; set; }

        public string ClienteDescripcion { get; set; }

        public string ProveedorDescripcion { get; set; }

        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaTransferenciaStr
        {
            get
            {
                return String.Format(formatoFecha, FechaTransferencia);
            }
            set
            {
                FechaTransferencia = DateTime.ParseExact(FechaTransferenciaStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }
    }

    public partial class TransferenciasSearcher
    {
        public string NroTransferencia { get; set; }
        public string FechaTransferencia { get; set; }
        public string RazonSocial { get; set; }
        public string Importe { get; set; }
        public string Cuit { get; set; }

    }
}