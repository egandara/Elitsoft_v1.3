using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;

namespace Mapeos.Web
{
    public partial class MasterMapeos : System.Web.UI.MasterPage
    {
        Colecciones listas = new Colecciones();

        Usuario usuario
        {
            get { return (Usuario)Session["_usuario"]; }
            set { Session["_usuario"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTipoUsuario.Text = listas.NombreTipoUsuarioPorId(usuario.Tipo_Usuario);
            }
            /*
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
             * */
        }

        protected void linkCambioPass_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }

        private void MostrarControles()
        {
            lblClaveActual.Visible = true;
            lblNuevaClave.Visible = true;
            lblRepetirNuevaClave.Visible = true;
            txtClaveActual.Visible = true;
            txtNuevaClave.Visible = true;
            txtRepetirNuevaClave.Visible = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void OcultarControles()
        {
            lblClaveActual.Visible = false;
            lblNuevaClave.Visible = false;
            lblRepetirNuevaClave.Visible = false;
            txtClaveActual.Visible = false;
            txtNuevaClave.Visible = false;
            txtRepetirNuevaClave.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = string.Empty;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario()
                {
                    Rut = usuario.Rut
                };

                usu.Read();

                if (usu.Clave == Encriptacion.Encriptar(txtClaveActual.Text) && usu.CambiarClave(Encriptacion.Encriptar(txtNuevaClave.Text)))
                {
                    OcultarControles();
                    lblMensaje.Text = "Cambio de clave exitoso.";
                }
                else
                {
                    lblMensaje.Text = "No se pudo realizar cambio de clave. Intente nuevamente.";
                    txtClaveActual.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al realizar cambio de clave.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }
    }
}