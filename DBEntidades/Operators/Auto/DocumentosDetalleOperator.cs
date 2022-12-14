using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class DocumentosDetalleOperator
    {

        public static DocumentosDetalle GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoDocumentosDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from DocumentosDetalle where Id = " + Id.ToString()).Tables[0];
            DocumentosDetalle documentosDetalle = new DocumentosDetalle();
            foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(documentosDetalle, value, null); }
                catch (System.ArgumentException) { }
            }
            return documentosDetalle;
        }

        public static List<DocumentosDetalle> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoDocumentosDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<DocumentosDetalle> lista = new List<DocumentosDetalle>();
            DataTable dt = db.GetDataSet("select " + columnas + " from DocumentosDetalle").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                DocumentosDetalle documentosDetalle = new DocumentosDetalle();
                foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(documentosDetalle, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(documentosDetalle);
            }
            return lista;
        }



        public class MaxLength
        {


        }

        public static DocumentosDetalle Save(DocumentosDetalle documentosDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoDocumentosDetalleSave")) throw new PermisoException();
            if (documentosDetalle.Id == -1) return Insert(documentosDetalle);
            else return Update(documentosDetalle);
        }

        public static DocumentosDetalle Insert(DocumentosDetalle documentosDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoDocumentosDetalleSave")) throw new PermisoException();
            string sql = "insert into DocumentosDetalle(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(documentosDetalle, null));
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
            documentosDetalle.Id = Convert.ToInt32(resp);
            return documentosDetalle;
        }

        public static DocumentosDetalle Update(DocumentosDetalle documentosDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoDocumentosDetalleSave")) throw new PermisoException();
            string sql = "update DocumentosDetalle set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(DocumentosDetalle).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(documentosDetalle, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            sql += columnas;
            List<object> parametros = new List<object>();
            for (int i = 0; i < param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
            }
            sql += " where Id = " + documentosDetalle.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return documentosDetalle;
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
