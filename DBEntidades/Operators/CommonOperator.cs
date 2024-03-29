using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class CommonOperator
    {
        //VALIDACION COMUN PARA TODAS//

        public static bool CommonValidation(string tableName, List<string> fields, List<string> values)
        {
            bool result = false;
            string columnas = string.Empty;
            List<string> tipo = new List<string>();
            string classname = "DbEntidades.Entities." + tableName;

            foreach (PropertyInfo prop in Type.GetType(classname).GetProperties())
            {
                if (fields.Contains(prop.Name))
                {
                    tipo.Add(prop.PropertyType.Name.ToString());
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
            string querystring = "";
            querystring = "select " + columnas + " from " + tableName + " where ";
            for (var i = 0; i < fields.Count; i++)
            {
                //valido si es el ultimo campo de la query
                if (i < (fields.Count - 1))
                {
                    //valido formato del campo para agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'" + " and "; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i] + " and "; }
                }
                else
                {
                    //valido formato del campo pra agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'"; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i]; }
                }
            }
            DB db = new DB();
            DataTable dt = db.GetDataSet(querystring).Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }

        public static List<string> CommonGetString(string tableName, List<string> fields, List<string> getFields, List<string> values)
        {
            string columnas = string.Empty;
            List<string> tipo = new List<string>();
            List<string> returnField = new List<string>();
            string classname = "DbEntidades.Entities." + tableName;
            foreach (PropertyInfo prop in Type.GetType(classname).GetProperties())
            {
                if (fields.Contains(prop.Name))
                {
                    tipo.Add(prop.PropertyType.Name.ToString());
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
            string querystring = "";
            querystring = "select " + columnas + " from " + tableName + " where ";
            for (var i = 0; i < fields.Count; i++)
            {
                //valido si es el ultimo campo de la query
                if (i < (fields.Count - 1))
                {
                    //valido formato del campo para agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'" + " and "; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i] + " and "; }
                }
                else
                {
                    //valido formato del campo pra agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'"; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i]; }
                }
            }
            DB db = new DB();
            DataTable dt = db.GetDataSet(querystring).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (var field in getFields)
                {
                    var value = dt.Rows[0][field].ToString();
                    returnField.Add(value);

                }
            }
            return returnField;
        }
        public static List<List<string>> CommonGetRecords(string tableName, List<string> fields, List<string> getFields, List<string> values)
        {
            string columnas = string.Empty;
            List<string> tipo = new List<string>();
            List< List<string>> returnList = new List<List<string>>();
            string classname = "DbEntidades.Entities." + tableName;
            foreach (PropertyInfo prop in Type.GetType(classname).GetProperties())
            {
                if (fields.Contains(prop.Name))
                {
                    tipo.Add(prop.PropertyType.Name.ToString());
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
            string querystring = "";
            querystring = "select " + columnas + " from " + tableName + " where ";
            for (var i = 0; i < fields.Count; i++)
            {
                //valido si es el ultimo campo de la query
                if (i < (fields.Count - 1))
                {
                    //valido formato del campo para agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'" + " and "; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i] + " and "; }
                }
                else
                {
                    //valido formato del campo pra agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'"; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i]; }
                }
            }
            DB db = new DB();
            DataTable dt = db.GetDataSet(querystring).Tables[0];
            List<string> list = new List<string>();

            foreach (DataRow dr in dt.AsEnumerable())
            {
                if (getFields.Count > 0)
                {
                    foreach (var field in getFields)
                    {
                        var value = dt.Rows[0][field].ToString();
                        list.Add(value);
                    }
                }
                else if (getFields.Count == 0)
                {

                    foreach (PropertyInfo prop in Type.GetType(classname).GetProperties())
                    {
                        object value = dr[prop.Name];
                        
                        var temp = "";
                        prop.SetValue(temp, value, null);
                        list.Add(temp);
                    }
                    
                }
                returnList.Add(list);
            }
            return returnList;
        }

        public static T GetOneByParameter<T>(string campo, string valor) where T : new()
        {
            if (!DbEntidades.Seguridad.Permiso("Permiso" + typeof(T).Name + "Browse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

            foreach (PropertyInfo prop in typeof(T).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from " + typeof(T).Name + " where  " + campo + " = \'" + valor + "\'").Tables[0];
            T obj = new T();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(obj, value, null); }
                    catch (System.ArgumentException) { }
                }
                return obj;
            }
            return default(T);
        }

        public static T GetOneByMultipleParameter<T>(Dictionary<string, string> parametros) where T : new()
        {
            if (!DbEntidades.Seguridad.Permiso("Permiso" + typeof(T).Name + "Browse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
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
            string where = " where ";
            foreach (KeyValuePair<string, string> kvp in parametros)
            {
                where += kvp.Key + " = '" + kvp.Value + "' and ";
            }
            where = where.Substring(0, where.Length - 4);
            DataTable dt = db.GetDataSet("select " + columnas + " from " + typeof(T).Name + where).Tables[0];
            T obj = new T();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(obj, value, null); }
                    catch (System.ArgumentException) { }
                }
                return obj;
            }
            return default(T);
        }


    }
}