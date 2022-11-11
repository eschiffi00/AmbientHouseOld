using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Datos
{
    public class TransferenciasDatos
    {

        public AmbientHouseEntities SqlContext { get; set; }

        public TransferenciasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public Transferencias Get(int Id)
        {
            return SqlContext.Transferencias.Where(o => o.Id == Id).Single();
        }

        public List<Transferencias> List(TransferenciasSearcher searcher)
        {
            var query = from p in SqlContext.Transferencias
                        select p;

            return query.ToList();
        }

        public bool Save(Transferencias transferencia)
        {
            if (transferencia.Id > 0)
            {
                Transferencias edit = SqlContext.Transferencias.Where(o => o.Id == transferencia.Id).First();

                edit.BancoId = transferencia.BancoId;
                edit.ClienteId = transferencia.ClienteId;
                edit.Comprobante = transferencia.Comprobante;
                edit.ComprobanteExtension = transferencia.ComprobanteExtension;
                edit.FechaTransferencia = transferencia.FechaTransferencia;
                edit.FechaUpdate = System.DateTime.Now;
                edit.Importe = transferencia.Importe;
                edit.NombreArchivo = transferencia.NombreArchivo;
                edit.NroTransferencia = transferencia.NroTransferencia;
                edit.ProveedorId = transferencia.ProveedorId;

                try
                {
                    SqlContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }


            }
            else
            {
                transferencia.FechaCreate = System.DateTime.Now;

                try
                {
                    SqlContext.Transferencias.Add(transferencia);
                    SqlContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }


            }


        }

    }
}

namespace Domain.Entidades
{
    public partial class TransferenciasSearcher
    {


    }
}
