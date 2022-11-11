using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class EmpresasDatos
    {

        public AmbientHouseEntities SqlContext { get; set; }

        public EmpresasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Empresas> ObtenerEmpresas()
        {


            var query = from Tm in SqlContext.Empresas
                        select new
                        {
                            Id = Tm.Id,
                            RazonSocial = Tm.RazonSocial,
                            Cuit = Tm.Cuit
                        };



            List<Empresas> Salida = new List<Empresas>();
            foreach (var item in query)
            {

                Empresas cat = new Empresas();

                cat.Id = item.Id;
                cat.RazonSocial = item.RazonSocial;
                cat.Cuit = item.Cuit;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RazonSocial).ToList();


        }

        public virtual List<Empresas> ObtenerEmpresasBlanco()
        {
            var query = from Tm in SqlContext.Empresas
                        where Tm.TipoEmpresa == true
                        select new
                        {
                            Id = Tm.Id,
                            RazonSocial = Tm.RazonSocial,
                            Cuit = Tm.Cuit,
                            TipoEmpresa = Tm.TipoEmpresa
                        };



            List<Empresas> Salida = new List<Empresas>();
            foreach (var item in query)
            {

                Empresas cat = new Empresas();

                cat.Id = item.Id;
                cat.RazonSocial = item.RazonSocial;
                cat.Cuit = item.Cuit;
                cat.TipoEmpresa = item.TipoEmpresa;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RazonSocial).ToList();
        }

        public List<Empresas> ObtenerEmpresasBlancoProveedores()
        {
            var query = from Tm in SqlContext.Empresas
                        where Tm.CondicionIva.ToUpper() != "MONOTRIBUTO".ToUpper()
                        select new
                        {
                            Id = Tm.Id,
                            RazonSocial = Tm.RazonSocial,
                            Cuit = Tm.Cuit,
                            TipoEmpresa = Tm.TipoEmpresa
                        };



            List<Empresas> Salida = new List<Empresas>();
            foreach (var item in query)
            {

                Empresas cat = new Empresas();

                cat.Id = item.Id;
                cat.RazonSocial = item.RazonSocial;
                cat.Cuit = item.Cuit;
                cat.TipoEmpresa = item.TipoEmpresa;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RazonSocial).ToList();
        }

        public DateTime ObtenerFechaCierreIvaPorEmpresa(int empresaId)
        {
            //var query = from c in SqlContext.CierreComprobantesIva
            //            where c.EmpresaId == empresaId
            //            select c;

            //return query.OrderBy(o=>o.FechaCierre).Select(s => s.FechaCierre).Max();
            return System.DateTime.Now;

        }

    }
}
