using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;
using System.Linq.Expressions;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;

namespace Mapeos.Web
{
    public partial class Desc_Fuentes : System.Web.UI.Page
    {
        Colecciones listas = new Colecciones();

        Usuario usuario
        {
            get { return (Usuario)Session["_usuario"]; }
            set { Session["_usuario"] = value; }
        }

        Fuentes descripcionFuente
        {
            get { return (Fuentes)Session["_descripcionFuente"]; }
            set { Session["_descripcionFuente"] = value; }
        }

        Relacion relacion
        {
            get { return (Relacion)Session["_relacion"]; }
            set { Session["_relacion"] = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFuentes();
                CargarDdl();
            }
        }

        private void CargarDdl()
        {
            ddlSistemas.DataSource = listas.ListaSistemas();
            ddlSistemas.DataBind();
            ddlSistemas.Items.Insert(0, "--Seleccione Sistema--");
            ddlSistemas.SelectedIndex = 0;
        }

        private void CargarFuentes()
        {
            gvFuentes.DataSource = listas.ListaFuentes();
            gvFuentes.DataBind();
        }

        protected void gvFuentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (chbSistemas.Checked == false)
            {
                gvFuentes.PageIndex = e.NewPageIndex;
                CargarFuentes();
            }
            if (chbSistemas.Checked == true)
            {
                gvFuentes.PageIndex = e.NewPageIndex;
                gvFuentes.DataSource = listas.ListasFuentesPersonalizadas(ddlSistemas.SelectedItem.ToString());
                gvFuentes.DataBind();
            }
        }

        protected void gvFuentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = gvFuentes.SelectedRow.Cells[1].Text;
        }

        protected void btnSeleccionar_onclick(object sender, System.EventArgs e)
        {
            if (usuario.Tipo_Usuario == 3)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Su perfil no permite editar fuentes.');",
                      true);
            }
            else
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                string codigo = row.Cells[1].Text;

                Fuentes fuente = new Fuentes()
                {
                    Numero_Fuente = int.Parse(codigo),
                };
                fuente.Read();
                descripcionFuente = fuente;

                Relacion x = new Relacion()
                {
                    Id_Tipo_Relacion = int.Parse(codigo),
                };
                x.Read();
                relacion = x;

                Response.BufferOutput = true;
                Response.Redirect("Mant_Fuentes.aspx");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (chbSistemas.Checked == true)
            {
                if (ddlSistemas.SelectedIndex != 0)
                {
                    gvFuentes.DataSource = listas.ListasFuentesPersonalizadas(ddlSistemas.SelectedItem.ToString());
                    gvFuentes.DataBind();
                }
                else
                {
                    CargarFuentes();
                }
            }
        }

        protected void gvFuentes_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
        {
            string Excelfilename = "TestExcelExport" + DateTime.Now;
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition:", "attachment; filename=" + Excelfilename + ".xls");
            Response.Charset = "";
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

            gvFuentes.AllowPaging = false;
            CargarFuentes();


            gvFuentes.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();

            gvFuentes.AllowPaging = true;
            CargarFuentes();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvFuentes.PageSize = int.Parse(ddlPaginas.SelectedValue);
            CargarFuentes();
        }
    }
}