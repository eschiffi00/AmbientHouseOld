using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

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
                RatiosDetail.ExperienciaBarraCodigo = Ratios.ExperienciaBarra;
                if (Ratios.ExperienciaBarra.Substring(0, 3) == "BAR")
                {
                    RatiosDetail.ExperienciaBarra = TiposBarrasOperator.GetOneByParameter("Id", Ratios.ExperienciaBarra.Substring(3)).Descripcion;
                }
                else
                {
                    RatiosDetail.ExperienciaBarra = TipoCateringOperator.GetOneByParameter("Id", Ratios.ExperienciaBarra.Substring(4)).Descripcion;
                }
                RatiosDetail.ItemDetalle = ItemsOperator.GetOneByIdentity(Ratios.ItemId).Detalle;
                RatiosDetail.TipoRatio = Ratios.TipoRatio;
                RatiosDetail.DetalleTipo = Ratios.DetalleTipo;
                RatiosDetail.ValorRatio = Ratios.ValorRatio;
                RatiosDetail.TopeRatio = Ratios.TopeRatio;
                RatiosDetail.Adultos = Ratios.Adultos;
                RatiosDetail.Menores3 = Ratios.Menores3;
                RatiosDetail.Menores3y8 = Ratios.Menores3y8;
                RatiosDetail.Adolescentes = Ratios.Adolescentes;
                RatiosDetail.AdicionalRatio = Ratios.AdicionalRatio;
                RatiosDetail.EstadoId = Ratios.EstadoId;

                RatiosDetail.Estado = EstadosOperator.GetOneByIdentity(RatiosDetail.EstadoId).Descripcion;

                lista.Add(RatiosDetail);
            }
            return lista;
        }
        ////GetAllByParameter////
        // Inputs: nombrecampo / valor 
        // funciona tanto para campos int como para campos string y realiza la conversion
        
        // Ratio Validation //
        // recibe un list con los campos ItemId,CategoriaId,TipoRatio,DetalleTipo 
        // deben estar en ese orden
        public static bool RatioValidation(List<string> key)
        {
            bool result = false;
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where  ItemId = " + key[0]
                                                                                       + "and ExperienciaBarra = \'" + key[1] + "\'"
                                                                                       + "and CategoriaId = " + key[2]
                                                                                       + "and TipoRatio = \'" + key[3] + "\'"
                                                                                       + "and DetalleTipo = \'" + key[4] + "\'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static int GetRatioId(List<string> key)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where  ItemId = " + key[0]
                                                                                       + "and ExperienciaBarra = \'" + key[1] + "\'"
                                                                                       + "and CategoriaId = " + key[2]
                                                                                       + "and TipoRatio = \'" + key[3] + "\'"
                                                                                       + "and DetalleTipo = \'" + key[4] + "\'").Tables[0];
            var id = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    string value = dt.Rows[0]["Id"].ToString();
                    id = int.Parse(value);
                }

            }

            return id;
        }
    }
}
