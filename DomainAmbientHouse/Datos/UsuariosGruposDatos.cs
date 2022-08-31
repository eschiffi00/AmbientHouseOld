using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class UsuariosGruposDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public UsuariosGruposDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<UsuariosGrupos> ObtenerGrupos()
        {

            var query = from c in SqlContext.UsuariosGrupos
                        //join b in SqlContext.Bancos on c.BancoId equals b.Id
                        //join p in SqlContext.Proveedores on c.ProveedorId equals p.Id into ps
                        //from p in ps.DefaultIfEmpty()
                        //join e in SqlContext.Estados on c.EstadoId equals e.Id
                        select new
                        {
                            Id = c.Id,
                            Nombre = c.Nombre

                        };

            List<UsuariosGrupos> Salida = new List<UsuariosGrupos>();
            foreach (var item in query)
            {

                UsuariosGrupos cat = new UsuariosGrupos();

                cat.Id = item.Id;
                cat.Nombre = item.Nombre;
             

                Salida.Add(cat);
            }

            return Salida.ToList();

           

        }

        //public virtual void NuevosCheques(Cheques cheque)
        //{
        //    if (cheque.Id > 0)
        //    {
        //        Cheques editCheque = SqlContext.Cheques.Where(o => o.Id == cheque.Id).FirstOrDefault();

        //        editCheque.NroCheque = cheque.NroCheque;
        //        editCheque.Importe = cheque.Importe;
        //        editCheque.FechaEmision = cheque.FechaEmision;
        //        editCheque.FechaVencimiento = cheque.FechaVencimiento;
        //        editCheque.BancoId = cheque.BancoId;
        //        editCheque.Observaciones = cheque.Observaciones;
        //        editCheque.TipoCheque = cheque.TipoCheque;
        //        editCheque.EstadoId = cheque.EstadoId;
        //        editCheque.ProveedorId = cheque.ProveedorId;
        //        editCheque.ClienteId = cheque.ClienteId;

        //        SqlContext.SaveChanges();
        //    }
        //    else
        //    {
        //        SqlContext.Cheques.Add(cheque);
        //        SqlContext.SaveChanges();
        //    }

        //}


        //public void GrabarChequePagoProveedor(ChequesPagosProveedores chequesPagos)
        //{
        //    SqlContext.ChequesPagosProveedores.Add(chequesPagos);
        //    SqlContext.SaveChanges();

        //}
    }
}
