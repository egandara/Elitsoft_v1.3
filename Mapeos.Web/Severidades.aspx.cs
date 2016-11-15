using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;

namespace Mapeos.Web
{
    public partial class Severidades : System.Web.UI.Page
    {
        Colecciones listas = new Colecciones();

        Negocio.Severidades severidades
        {
            get { return (Negocio.Severidades)Session["_severidades"]; }
            set { Session["_severidades"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                LimpiarControles();
            }
        }

        protected void txtBuscarSeveridad_Click(object sender, EventArgs e)
        {
            if (txtBuscarSeveridades.Text == string.Empty)
            {
                lblTesting.Text = "Ingrese un Número de Fuente";
            }else{
                BuscarSeveridad();
            }   
        }

        private void BuscarSeveridad()
        {
            gvSeveridad.DataSource = listas.ListarSeveridad(int.Parse(txtBuscarSeveridades.Text));
            gvSeveridad.DataBind();
        }

        protected void gvSeveridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = gvSeveridad.SelectedRow.Cells[1].Text;
        }

        protected void btnSeleccionar_onclick(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string codigo = row.Cells[2].Text;
            Negocio.Severidades sever = new Negocio.Severidades()
            {
                Id_Severidades = int.Parse(codigo), 
            };
            sever.Read();
            severidades = sever;
            Response.BufferOutput = true;
            Response.Redirect("Mant_Severidades.aspx");
        }


        private void LimpiarControles()
        {
            txtBuscarSeveridades.Text = string.Empty;
        }

        protected void gvSeveridad_RowCreated(object sender, GridViewRowEventArgs e)
        {
            foreach (TableRow row in gvSeveridad.Controls[0].Controls)
            {
                row.Cells[1].Visible = false;
                row.Cells[2].Visible = false;
            }
        }
    }
}