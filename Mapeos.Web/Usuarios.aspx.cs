using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Web.UI.HtmlControls;

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
                CargarUsuarios();
                CargarDdl();
            }
        }

        private void CargarUsuarios()
        {
            gvUsuarios.DataSource = listas.ListaUsuarios();
            gvUsuarios.DataBind();
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

        protected void btnSeleccionar_onClick(object sender, System.EventArgs e)
        {
            if (usuario.Tipo_Usuario != 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Su perfil no permite editar usuarios.');",
                      true);
            }
            else
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                string codigo = row.Cells[1].Text;
                string[] cadena = codigo.Split('-');

                Usuario usu = new Usuario()
                {
                    Rut = int.Parse(cadena[0].TrimEnd('-'))
                };

                if (usu.Read())
                {
                    txtRut.Text = usu.Rut.ToString();
                    txtDv.Text = usu.Dv.ToString();
                    txtNombre.Text = usu.Nombre;
                    txtUsername.Text = usu.UserName;
                    ddlPerfil.SelectedValue = listas.NombreTipoUsuarioPorId(usu.Tipo_Usuario);
                    if (usu.Estado == true)
                    {
                        btnDesactivar.Text = "Desactivar";
                    }
                    if (usu.Estado == false)
                    {
                        btnDesactivar.Text = "Activar";
                    }
                }
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            string strFileName = "GridviewExcel_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString() + ".csv";
            //builder.Append("RUT ,Nombre, UserName" + Environment.NewLine);
            string header = gvUsuarios.HeaderRow.Cells[1].Text + "," + gvUsuarios.HeaderRow.Cells[2].Text + "," + gvUsuarios.HeaderRow.Cells[3].Text;
            //builder.Append(gvUsuarios.HeaderRow.Cells[1].Text + Environment.NewLine);
            builder.Append(header + Environment.NewLine);
            foreach (GridViewRow row in gvUsuarios.Rows)
            {
                string rut = row.Cells[1].Text;
                string nombre = row.Cells[2].Text;
                string username = row.Cells[3].Text;
                builder.Append(rut + "," + nombre + "," + username + Environment.NewLine);
            }
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            Response.Write(builder.ToString());
            Response.End();
        }

        public static string RemoverTildes(string texto)
        {
            string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            StringBuilder textoSinAcentos = new StringBuilder(texto.Length);
            int indexConAcento;
            foreach (char caracter in texto)
            {
                indexConAcento = consignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos.Append(sinsignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos.Append(caracter);
            }
            return textoSinAcentos.ToString();
        }

        public static string RemoveSpecialCharacters(string str)
        {
            string result = Regex.Replace(str, @"[^\w\d]", ",");

            return result;
        }

        protected void btnExportarPrueba_Click(object sender, EventArgs e)
        {
            ExportarExcel("Informe.xls", gvUsuarios);
        }

        private void ExportarExcel(string nombreReporte, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);

            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nombreReporte);

            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 0)
            {
                for (int i = 1; i > e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].CssClass = "wordwrap";
                }
            }
            e.Row.Cells[0].CssClass = "sno";
        }

    }
}