using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Web;
using System.Web.SessionState;

namespace AmbientHouse.Presupuestos
{
    /// <summary>
    /// Summary description for PipeDrivePost
    /// </summary>
    public class PipeDrivePost : IHttpHandler, IRequiresSessionState
    {

        private Negocio NegociosPipeDrive
        {
            get { return (Negocio)HttpContext.Current.Session["NuevoNegocio"]; }
            set { HttpContext.Current.Session["NuevoNegocio"] = value; }
        }

        public void ProcessRequest(HttpContext context)
        {

            RemotePost myremotepost = new RemotePost();
            myremotepost.Url = "https://grupolahusen.pipedrive.com/v1/deals?api_token=d063057f2a70f91619815dd9e7a4ec673d34b80f";
            myremotepost.Add("title", NegociosPipeDrive.titulo);
            myremotepost.Add("value", NegociosPipeDrive.valor);
            myremotepost.Add("currency", NegociosPipeDrive.moneda);
            myremotepost.Add("user_id", NegociosPipeDrive.usuario.ToString());
            myremotepost.Add("person_id", NegociosPipeDrive.persona.ToString());
            myremotepost.Add("33085a196d55d33ea6673283bfb35eb671463920", NegociosPipeDrive.nroEvento.ToString());
            myremotepost.Add("6c3d4a27197f2a3430359353d17bd592704c2db2", NegociosPipeDrive.nroPresupuesto.ToString());
            myremotepost.Add("e617cf36dd7890dbedfd1bd2f8dff91a90322dcb", NegociosPipeDrive.fechaEvento.ToString());

            myremotepost.Post();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}