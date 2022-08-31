using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DomainAmbientHouse.Servicios
{
    public class HtmlHelpers
    {

        public HtmlString RetornarLi(string titulo, List<DomainAmbientHouse.Entidades.Tiempos> list)
        {
            //var result = "<!DOCTYPE html>";

            //result = result + "<html xmlns='http://www.w3.org/1999/xhtml>'";
            //result = result + "<head> <style> ul { column-count: 2;} </style> <title></title></head><body>";

            //result = result + "<p>" + titulo + "</p>";
            var result =  "<ul>";

            foreach (var item in list)
            {
                result = result + string.Format("<li>{0}</li>", item.Descripcion);
            }

            result = result + "</ul>";
            return new HtmlString(result);

        }

    }
}
