using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using DbEntidades.Entities;
using System.Data.SqlClient;
using LibDB2;

namespace DbEntidades.Operators
{
    public partial class RatiosOperator
    {
        public static List<RatiosListado> GetAllWithDetails()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<RatiosListado> lista = new List<RatiosListado>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Ratios Ratios = new Ratios();
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Ratios, value, null); }
                    catch (System.ArgumentException) { }
                }
                RatiosListado RatiosDetail = new RatiosListado();
                RatiosDetail.Id = Ratios.Id;
                RatiosDetail.ItemId = Ratios.ItemId;
                RatiosDetail.ItemDetalle = ItemsOperator.GetOneByIdentity(Ratios.ItemId).Detalle;
                RatiosDetail.CategoriaId = Ratios.CategoriaId;
                RatiosDetail.CategoriaDetalle = CategoriasOperator.GetOneByIdentity(Ratios.CategoriaId).Descripcion;
                RatiosDetail.TipoDependencia = Ratios.TipoDependencia;
                RatiosDetail.DetalleDependencia = Ratios.DetalleDependencia;
                RatiosDetail.TopeRatio = Ratios.TopeRatio;
                RatiosDetail.Menores = Ratios.Menores;
                RatiosDetail.AdicionalRatio = Ratios.AdicionalRatio;
                RatiosDetail.EstadoId = Ratios.EstadoId;

                if (EstadosOperator.GetHablitadoID("Ratios") > 0)
                {
                    RatiosDetail.Estado = "Activo";
                }
                else { RatiosDetail.Estado = "Inactivo"; }
                
                lista.Add(RatiosDetail);
            }
            return lista;
        }
    }
}
