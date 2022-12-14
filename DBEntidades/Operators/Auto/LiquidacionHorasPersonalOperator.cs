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
    public partial class LiquidacionHorasPersonalOperator
    {

        public static LiquidacionHorasPersonal GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from LiquidacionHorasPersonal where Id = " + Id.ToString()).Tables[0];
            LiquidacionHorasPersonal liquidacionHorasPersonal = new LiquidacionHorasPersonal();
            foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(liquidacionHorasPersonal, value, null); }
                catch (System.ArgumentException) { }
            }
            return liquidacionHorasPersonal;
        }

        public static List<LiquidacionHorasPersonal> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<LiquidacionHorasPersonal> lista = new List<LiquidacionHorasPersonal>();
            DataTable dt = db.GetDataSet("select " + columnas + " from LiquidacionHorasPersonal").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                LiquidacionHorasPersonal liquidacionHorasPersonal = new LiquidacionHorasPersonal();
                foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(liquidacionHorasPersonal, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(liquidacionHorasPersonal);
            }
            return lista;
        }
        public static LiquidacionHorasPersonal GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from LiquidacionHorasPersonal where  " + campo + " = \'" + valor + "\'").Tables[0];
            LiquidacionHorasPersonal LiquidacionHorasPersonal = new LiquidacionHorasPersonal();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(LiquidacionHorasPersonal, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return LiquidacionHorasPersonal;
        }
        public static List<LiquidacionHorasPersonal> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
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
                    queryStr = "select " + columnas + " from LiquidacionHorasPersonal where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from LiquidacionHorasPersonal where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<LiquidacionHorasPersonal> lista = new List<LiquidacionHorasPersonal>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    LiquidacionHorasPersonal entidad = new LiquidacionHorasPersonal();
                    foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
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

		public static List<LiquidacionHorasPersonal> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<LiquidacionHorasPersonal> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<LiquidacionHorasPersonal> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<LiquidacionHorasPersonal> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int Descripcion { get; set; } = 200;


        }

        public static LiquidacionHorasPersonal Save(LiquidacionHorasPersonal liquidacionHorasPersonal)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalSave")) throw new PermisoException();
            if (liquidacionHorasPersonal.Id == -1) return Insert(liquidacionHorasPersonal);
            else return Update(liquidacionHorasPersonal);
        }

        public static LiquidacionHorasPersonal Insert(LiquidacionHorasPersonal liquidacionHorasPersonal)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalSave")) throw new PermisoException();
            string sql = "insert into LiquidacionHorasPersonal(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(liquidacionHorasPersonal, null));
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
            liquidacionHorasPersonal.Id = Convert.ToInt32(resp);
            return liquidacionHorasPersonal;
        }

        public static LiquidacionHorasPersonal Update(LiquidacionHorasPersonal liquidacionHorasPersonal)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLiquidacionHorasPersonalSave")) throw new PermisoException();
            string sql = "update LiquidacionHorasPersonal set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(LiquidacionHorasPersonal).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(liquidacionHorasPersonal, null));
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
            sql += " where Id = " + liquidacionHorasPersonal.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return liquidacionHorasPersonal;
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
