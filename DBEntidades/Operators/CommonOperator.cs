using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using DbEntidades.Entities;
using System.Data.SqlClient;
using LibDB2;
using System.Windows.Media;

namespace DbEntidades.Operators
{
    public partial class CommonOperator
    {
        //VALIDACION COMUN PARA TODAS//

        public static bool CommonValidation(string tableName,List<string> fields,List<string> values)
        {
            bool result = false;
            string columnas = string.Empty;
            List<string> tipo = new List<string>();
            string classname = "DbEntidades.Entities."+tableName;
            
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
            querystring ="select " + columnas + " from " +tableName+" where ";
            for (var i = 0; i < fields.Count; i++)
            {
                //valido si es el ultimo campo de la query
                if (i > (fields.Count - 1))
                {
                    //valido formato del campo para agregar comillas
                    if (tipo[i] == "String")
                        {querystring = querystring + " " + fields[i] + "= \'" + values[i]+ "\'" + "and";}
                    else
                        {querystring = querystring + " " + fields[i] + "= " + values[i] + "and";}     
                }
                else
                {
                    //valido formato del campo pra agregar comillas
                    if (tipo[i] == "String")
                        {querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'";}
                    else
                        {querystring = querystring + " " + fields[i] + "= " + values[i];}
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
                if (i > (fields.Count - 1))
                {
                    //valido formato del campo para agregar comillas
                    if (tipo[i] == "String")
                    { querystring = querystring + " " + fields[i] + "= \'" + values[i] + "\'" + "and"; }
                    else
                    { querystring = querystring + " " + fields[i] + "= " + values[i] + "and"; }
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

    }
}