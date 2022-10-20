﻿using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.UserModel.Helpers;
using Org.BouncyCastle.X509;
using static System.Net.WebRequestMethods;
using System.Drawing;

namespace WebApplication.app.ItemsNS
{
    public partial class ItemsBrowse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (string.IsNullOrEmpty(Convert.ToString(Session["UsuarioId"]))) Response.Redirect("~/app/Seguridad/UsuarioLogin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                //if (!PermisoOperator.TienePermiso(Convert.ToInt32(Session["UsuarioId"]), GetType().BaseType.FullName)) throw new PermisoException();
                grdItemsBind();
            }
        }

        protected void grdItemsBind()
        {
            List<ItemsListado> ent = ItemsOperator.GetAllWithDetails().ToList();
            grdItems.DataSource = ent;
            
            grdItems.DataBind();
            foreach (GridViewRow fila in grdItems.Rows)
            {
                TableCellCollection fila2;
                fila2 = fila.Cells;
                if (fila2[15].Text == "Inactivo")
                {
                    fila.ControlStyle.BackColor = Color.LightSalmon;
                    fila.ControlStyle.ForeColor = Color.White;
                }
            }
            //grdItems.DataBind();
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevoItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AdmItems/ItemsEdit.aspx");
        }
        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "ID");
            int id = Convert.ToInt32(row.Cells[colindex].Text);

            if (e.CommandName == "CommandNameDelete")
            {
                ItemsOperator.Delete(id);
                grdItemsBind();
            }
            if (e.CommandName == "CommandNameEdit")
            {

                Response.Redirect("../../Configuracion/AdmItems/ItemsEdit.aspx?Id="+id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}