using DomainAmbientHouse.Servicios;
using System;
using System.Security.Permissions;
using System.Web.UI.WebControls;

namespace AmbientHouse.Herramientas.Corporativos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarHerramientas();
            }
        }
        private void BuscarHerramientas()
        {
            GridViewHerramientas.DataSource = servicios.ObtenerHerramientas();
            GridViewHerramientas.DataBind();

            UpdatePanelGrillaHerramientas.Update();
        }


        protected void ButtonDescargar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Herramientas/Corporativos/VisualizaArchivo.aspx");


        }

        private string GetContentType(string FileExtension)
        {
            // Convertimos la extensión en minúsculas
            string ext = FileExtension.ToLower(
                System.Threading.Thread.CurrentThread.CurrentCulture);
            // Verificamos que contenga el punto de
            // otra manera habría que agregarlo para 
            // poder obtener los resultados esperados
            if (!ext.StartsWith("."))
                ext = String.Concat(".", ext);
            // Se declara un permisos pata obtener
            // acceso de solo lectura al registro
            // NOTA: Se está utilizando: using System.Security.Permissions;
            RegistryPermission Reg = new RegistryPermission(
            RegistryPermissionAccess.Read, "HKEY_CLASSES_ROOT\\");
            // Creamos un llave de registro para
            // HKEY_CLASSES_ROOT
            Microsoft.Win32.RegistryKey regKey =
                Microsoft.Win32.Registry.ClassesRoot;
            // Intentamos crear una llave de registro
            // a partir de la extensión
            Microsoft.Win32.RegistryKey regKeyExt =
                regKey.OpenSubKey(ext);
            // Si la extensión existe como sub llave de registro
            // entonces devolveremos su valor de lo contrario
            // se devuelve el valor predeterminado
            if (regKeyExt == null)
                return "application/octet-stream";
            else
                return regKeyExt.GetValue("Content Type",
            "application/octet-stream").ToString();
        }

        protected void ButtonEliminarArchivo_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.Herramientas herramienta = new DomainAmbientHouse.Entidades.Herramientas();

            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            int id = Convert.ToInt32(GridViewHerramientas.DataKeys[rowIndex].Value);

            herramienta = servicios.TraerArchivo(id);

            servicios.EliminarArchivo(herramienta);

            BuscarHerramientas();
        }

        protected void GridViewHerramientas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHerramientas.PageIndex = e.NewPageIndex;
            BuscarHerramientas();
        }

        protected void ButtonNuevaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/Corporativos/NuevaCarpeta.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/Corporativos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Default.aspx");
        }






    }
}