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
    public partial class TipoPagoEmpleadosOperator
    {

        public static TipoPagoEmpleados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoPagoEmpleados where Id = " + Id.ToString()).Tables[0];
            TipoPagoEmpleados tipoPagoEmpleados = new TipoPagoEmpleados();
            foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tipoPagoEmpleados, value, null); }
                catch (System.ArgumentException) { }
            }
            return tipoPagoEmpleados;
        }

        public static List<TipoPagoEmpleados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoPagoEmpleados> lista = new List<TipoPagoEmpleados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoPagoEmpleados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoPagoEmpleados tipoPagoEmpleados = new TipoPagoEmpleados();
                foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tipoPagoEmpleados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tipoPagoEmpleados);
            }
            return lista;
        }
        public static TipoPagoEmpleados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoPagoEmpleados where  " + campo + " = \'" + valor + "\'").Tables[0];
            TipoPagoEmpleados TipoPagoEmpleados = new TipoPagoEmpleados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TipoPagoEmpleados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TipoPagoEmpleados;
        }
        public static List<TipoPagoEmpleados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
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
                    queryStr = "select " + columnas + " from TipoPagoEmpleados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TipoPagoEmpleados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TipoPagoEmpleados> lista = new List<TipoPagoEmpleados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TipoPagoEmpleados entidad = new TipoPagoEmpleados();
                    foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
                    {
                        object value = dr[prop.Name];
                        if (value == DBNull.Value) value = null;
                        try { prop.SetValue(entidad, value, null); }
                        catch (System.ArgumentException) { }
                    }
                    lista.Add(entidad);
                }
                return lista;
            }



        public class MaxLength
        {
			public static int Descripcion { get; set; } = 50;


        }

        public static TipoPagoEmpleados Save(TipoPagoEmpleados tipoPagoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosSave")) throw new PermisoException();
            if (tipoPagoEmpleados.Id == -1) return Insert(tipoPagoEmpleados);
            else return Update(tipoPagoEmpleados);
        }

        public static TipoPagoEmpleados Insert(TipoPagoEmpleados tipoPagoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosSave")) throw new PermisoException();
            string sql = "insert into TipoPagoEmpleados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoPagoEmpleados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted.Id values (" + valores + ")";
            DB db = new DB();
            List<object> parametros = new List<object>();
            for (int i = 0; i < param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
            }
            //object resp = db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            tipoPagoEmpleados.Id = Convert.ToInt32(resp);
            return tipoPagoEmpleados;
        }

        public static TipoPagoEmpleados Update(TipoPagoEmpleados tipoPagoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoPagoEmpleadosSave")) throw new PermisoException();
            string sql = "update TipoPagoEmpleados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoPagoEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoPagoEmpleados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            sql += columnas;
            List<object> parametros = new List<object>();
            for (int i = 0; i<param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
        }
            sql += " where Id = " + tipoPagoEmpleados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tipoPagoEmpleados;
    }

        private static string GetComilla(string tipo)
        {
            switch (tipo) //son tipos de c#
            {
                case "Int32": return "";
                case "String": return "'";
                case "DateTime": return "'";
                case "Nullable`1": return "'";
            }
            return "";
        }

        public static string VerificaStringNull(string v)
        {
            return v == string.Empty ? null : v;
        }
    }
}
