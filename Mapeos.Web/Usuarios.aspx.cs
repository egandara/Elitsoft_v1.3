using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;

namespace Mapeos.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Usuario usuario
        {
            get { return (Usuario)Session["_usuario"]; }
            set { Session["_usuario"] = value; }
        }

        Colecciones listas = new Colecciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (usuario.Tipo_Usuario != 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Su perfil no permite realizar modificaciones en esta página.');",
                      true);
                    DesactivarControles();
                }
                CargarDdl();
            }
        }

        private void CargarDdl()
        {
            ddlPerfil.DataSource = listas.TipoUsuario_ReadAll().Select(t => t.Nombre_Tipo);
            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, "--Seleccione perfil--");
            ddlPerfil.SelectedIndex = 0;
        }

        private void DesactivarControles()
        {
            txtRut.Enabled = false;
            txtDv.Enabled = false;
            txtNombre.Enabled = false;
            txtUsername.Enabled = false;
            txtClave.Enabled = false;
            txtClave2.Enabled = false;
            ddlPerfil.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDesactivar.Enabled = false;
        }

        protected void txtDv_TextChanged(object sender, EventArgs e)
        {
            Usuario usu = new Usuario()
            {
                Rut = int.Parse(txtRut.Text),
                Dv = char.Parse(txtDv.Text)
            };
            if (IsPostBack)
            {
                if (usu.Read())
                {
                    if (usu.Estado == true)
                    {
                        txtNombre.Text = usu.Nombre;
                        txtUsername.Text = usu.UserName;
                        ddlPerfil.SelectedValue = listas.NombreTipoUsuarioPorId(usu.Tipo_Usuario);
                        btnDesactivar.Text = "Desactivar.";
                    }
                    else
                    {
                        txtNombre.Text = usu.Nombre;
                        txtUsername.Text = usu.UserName;
                        ddlPerfil.SelectedValue = listas.NombreTipoUsuarioPorId(usu.Tipo_Usuario);
                        btnDesactivar.Text = "Activar.";
                    }
                }
            }

            if (Digito(int.Parse(txtRut.Text)) == txtDv.Text)
            {
                txtNombre.Focus();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                     "err_msg",
                     "alert('Rut ingresado no es válido.');",
                     true);

                txtRut.Text = string.Empty;
                txtDv.Text = string.Empty;
                txtRut.Focus();
            }
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario()
                {
                    Rut = int.Parse(txtRut.Text),
                    Dv = char.Parse(txtDv.Text),
                    Nombre = txtNombre.Text,
                    UserName = txtUsername.Text,
                    Clave = Encriptacion.Encriptar(txtClave2.Text),
                    Tipo_Usuario = listas.IdTipoUsuarioPorNombre(ddlPerfil.SelectedItem.ToString()),
                    Estado = true
                };

                if (usu.Create())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Usuario " + txtUsername.Text + " creado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Usuario no creado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear nuevo usuario.";
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Text = string.Empty;
            txtUsername.Text = string.Empty;
            ddlPerfil.SelectedIndex = 0;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario()
                {
                    Rut = int.Parse(txtRut.Text),
                    Dv = char.Parse(txtDv.Text),
                    Nombre = txtNombre.Text,
                    UserName = txtUsername.Text,
                    Clave = Encriptacion.Encriptar(txtClave2.Text),
                    Tipo_Usuario = listas.IdTipoUsuarioPorNombre(ddlPerfil.SelectedItem.ToString()),
                    Estado = true
                };

                if (usu.Update())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Usuario " + txtUsername.Text + " actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Usuario no actualizado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar usuario.";
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario()
                {
                    Rut = int.Parse(txtRut.Text)
                };

                if (usu.Read())
                {
                    if (usu.Estado == true)
                    {
                        if (usu.DesactivarUsuario())
                        {
                            LimpiarControles();
                            lblMensaje.Text = "Usuario desactivado correctamente.";
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario no desactivado.";
                        }
                    }
                    if (usu.Estado == false)
                    {
                        if (usu.ActivarUsuario())
                        {
                            LimpiarControles();
                            lblMensaje.Text = "Usuario activado correctamente.";
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario no activado.";
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al desactivar usuario.";
            }
        }
    }
}