using System;


namespace DomainAmbientHouse.Servicios
{
    public class RemotePost
    {
        System.Collections.Specialized.NameValueCollection _Inputs = new System.Collections.Specialized.NameValueCollection();
        string _Url = "";
        string _Method = "post";
        string _FormName = "form1";

        /// <summary>
        /// Devuelve o setea la url del medio de pago
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        /// <summary>
        /// Agrega inputs hidden al formulario
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value)
        {
            _Inputs.Add(name, value);
        }

        /// <summary>
        /// Imprime en el cliente el formulario de compra
        /// </summary>
        /// <summary>
        /// Imprime en el cliente el formulario de compra
        /// </summary>
        public void Post()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("");
            System.Web.HttpContext.Current.Response.Write(String.Format("<html><head></head><body onload=\"document.{0}.submit()\">", _FormName));
            System.Web.HttpContext.Current.Response.Write(String.Format("<center><form target=\"_self\" name=\"{0}\" method=\"{1}\" action=\"{2}\" >", _FormName, _Method, Url));

            for (int i = 0; i < _Inputs.Keys.Count; i++)
            {
                System.Web.HttpContext.Current.Response.Write(String.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", _Inputs.Keys[i], _Inputs[_Inputs.Keys[i]]));
            }
            System.Web.HttpContext.Current.Response.Write("</form></center></body></html>");

        }
    }



}


