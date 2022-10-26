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
        ////GetAllWithDetails////
        // Inputs:
        // Obtiene todos los registros al igual que GetAll
        // pero los pasa a una clase con datos extras para mostrar en pantalla
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
                RatiosDetail.CategoriaDetalle = CategoriasItemOperator.GetOneByIdentity(Ratios.CategoriaId).Descripcion;
                RatiosDetail.TipoRatio = Ratios.TipoRatio;
                RatiosDetail.DetalleTipo = Ratios.DetalleTipo;
                RatiosDetail.ValorRatio = Ratios.ValorRatio;
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
        ////GetAllByParameter////
        // Inputs: nombrecampo / valor 
        // funciona tanto para campos int como para campos string y realiza la conversion
        public static List<Ratios> GetAllByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            var tipo = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
            {
                if (prop.Name == campo)
                {
                    tipo = prop.PropertyType.Name.ToString();
                }
                if (prop.Name == "Delete")
                {
                    columnas += "[" + prop.Name + "]" + ", ";
                }
                else
                {
                    columnas += prop.Name + ", ";
                }

            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            var queryStr = string.Empty;
            if (tipo == "String")
            {
                queryStr = "select " + columnas + " from Ratios where " + campo + " = \'" + valor.ToString() + "\'";
            }
            else
            {
                queryStr = "select " + columnas + " from Ratios where " + campo + " = " + valor.ToString();
            }
            DataTable dt = db.GetDataSet(queryStr).Tables[0];
            List<Ratios> lista = new List<Ratios>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                Ratios comprobante = new Ratios();
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(comprobante, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(comprobante);
            }
            return lista;
        }
        // Ratio Validation //
        // recibe un list con los campos ItemId,CategoriaId,TipoRatio,DetalleTipo 
        // deben estar en ese orden
        public static bool RatioValidation(List<string> key)
        {
            bool result = true;
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where  ItemId = " + key[0]
                                                                                       + "and CategoriaId = " + key[1]
                                                                                       + "and TipoRatio = \'" + key[2] + "\'"
                                                                                       + "and DetalleTipo = \'" + key[3] + "\'").Tables[0];
            
            if (dt.Rows.Count > 0)
            {
                result = false;
            }
            return result;
        }
    }
}
