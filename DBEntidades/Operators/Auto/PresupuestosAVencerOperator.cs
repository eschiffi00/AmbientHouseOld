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
    public partial class PresupuestosAVencerOperator
    {

        public static PresupuestosAVencer GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from PresupuestosAVencer where  = " + .ToString()).Tables[0];
            PresupuestosAVencer presupuestosAVencer = new PresupuestosAVencer();
            foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(presupuestosAVencer, value, null); }
                catch (System.ArgumentException) { }
            }
            return presupuestosAVencer;
        }

        public static List<PresupuestosAVencer> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<PresupuestosAVencer> lista = new List<PresupuestosAVencer>();
            DataTable dt = db.GetDataSet("select " + columnas + " from PresupuestosAVencer").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                PresupuestosAVencer presupuestosAVencer = new PresupuestosAVencer();
                foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(presupuestosAVencer, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(presupuestosAVencer);
            }
            return lista;
        }
        public static PresupuestosAVencer GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from PresupuestosAVencer where  " + campo + " = \'" + valor + "\'").Tables[0];
            PresupuestosAVencer PresupuestosAVencer = new PresupuestosAVencer();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(PresupuestosAVencer, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return PresupuestosAVencer;
        }
        public static List<PresupuestosAVencer> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
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
                    queryStr = "select " + columnas + " from PresupuestosAVencer where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from PresupuestosAVencer where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<PresupuestosAVencer> lista = new List<PresupuestosAVencer>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    PresupuestosAVencer entidad = new PresupuestosAVencer();
                    foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
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

		public static List<PresupuestosAVencer> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<PresupuestosAVencer> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<PresupuestosAVencer> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<PresupuestosAVencer> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int ApellidoNombre { get; set; } = 100;
			public static int CARACTERISTICA { get; set; } = 50;
			public static int LOCACION { get; set; } = 50;
			public static int SECTOR { get; set; } = 50;
			public static int JORNADA { get; set; } = 50;
			public static int HorarioEvento { get; set; } = 50;
			public static int Estado { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 50;
			public static int RazonSocial { get; set; } = 200;
			public static int EstadoPresupuesto { get; set; } = 50;
			public static int Vencimiento { get; set; } = 18;


        }

        public static PresupuestosAVencer Save(PresupuestosAVencer presupuestosAVencer)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerSave")) throw new PermisoException();
            if (presupuestosAVencer. == -1) return Insert(presupuestosAVencer);
            else return Update(presupuestosAVencer);
        }

        public static PresupuestosAVencer Insert(PresupuestosAVencer presupuestosAVencer)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerSave")) throw new PermisoException();
            string sql = "insert into PresupuestosAVencer(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(presupuestosAVencer, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted. values (" + valores + ")";
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
            presupuestosAVencer. = Convert.ToInt32(resp);
            return presupuestosAVencer;
        }

        public static PresupuestosAVencer Update(PresupuestosAVencer presupuestosAVencer)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestosAVencerSave")) throw new PermisoException();
            string sql = "update PresupuestosAVencer set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(PresupuestosAVencer).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(presupuestosAVencer, null));
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
            sql += " where  = " + presupuestosAVencer.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return presupuestosAVencer;
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
