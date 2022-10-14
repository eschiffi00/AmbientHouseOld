using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Web;
using DbEntidades.Entities;
using DbEntidades.Operators;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.SessionState;

namespace AmbientHouse.Herramientas.UploadExcel
{
    public partial class UploadExcel
    {
        public static DataSet UploadToExcel (FileUpload fileUpload)
        {
            //Get path from web.config file to upload
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            string filename = string.Empty;
            //To check whether file is selected or not to uplaod
            try
            {
                string[] allowdFile = { ".xls", ".xlsx" };
                //Here we are allowing only excel file so verifying selected file pdf or not
                string FileExt = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);
                //Check whether selected file is valid extension or not
                bool isValidFile = allowdFile.Contains(FileExt);
                if (!isValidFile)
                {
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                    //lblMsg.Text = "Please upload only Excel";
                }
                else
                {
                    // Get size of uploaded file, here restricting size of file
                    int FileSize = fileUpload.PostedFile.ContentLength;
                    Console.WriteLine("este es el peso" + FileSize);
                    if (FileSize <= 1048576)//1048576 byte = 1MB
                    {
                        //Get file name of selected file
                        filename = Path.GetFileName(System.Web.HttpContext.Current.Server.MapPath(fileUpload.FileName));
                            
                        //Save selected file into server location
                        fileUpload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FilePath) + filename);
                        //Get file path
                        string filePath = System.Web.HttpContext.Current.Server.MapPath(FilePath) + filename;
                        //Open the connection with excel file based on excel version
                        OleDbConnection con = null;
                        //if (FileExt == ".xls")
                        //{
                            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

                        //}
                        //else if (FileExt == ".xlsx")
                        //{
                        //    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");
                        //}
                        con.Open();
                        //Get the list of sheet available in excel sheet
                        DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        //Get first sheet name
                        string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
                        //Select rows from first sheet in excel sheet and fill into dataset
                        OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT * FROM [" + getExcelSheetName + @"]", con);
                        OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                        DataSet ExcelDataSet = new DataSet();
                        ExcelAdapter.Fill(ExcelDataSet);
                        con.Close();
                        //Bind the dataset into gridview to display excel contents
                        return ExcelDataSet;
                        //GridView1.DataSource = ExcelDataSet;
                        //GridView1.DataBind();
                    }
                    else
                    {
                        DataSet ExcelDataSet = new DataSet();
                        return ExcelDataSet;
                        //lblMsg.Text = "Attachment file size should not be greater then 1 MB!";
                    }
                }
            }
            catch (Exception ex)
            {
                DataSet ExcelDataSet = new DataSet();
                return ExcelDataSet;
            }
            DataSet ExcelDataSet2 = new DataSet();
            return ExcelDataSet2;

        }
        public static void DeleteUploads(string filename)
        {
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(FilePath), filename);
            DirectoryInfo di = new DirectoryInfo(path);

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException ev)
                {
                    //Console.WriteLine(ev.Message);
                    return;
                }
            }
            Console.WriteLine("Files deleted successfully");
        }
    }
    
}
