using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;

namespace Mapeos.Web
{
    public partial class Mant_Fuentes : System.Web.UI.Page
    {
        Colecciones listas = new Colecciones();

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
                if (Request.UrlReferrer != null)
                {
                    string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                    string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);

                    if (previousPageName == "Desc_Fuentes.aspx")
                    {
                        CargarDdl();
                        CargaFromTabla();
                        txtNumero.Focus();
                    }
                    else
                    {
                        LimpiarControles();
                        txtNumero.Text = string.Empty;
                        previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                        previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                        CargarDdl();
                        txtNumero.Focus();
                    }
                }
            }
            DobleClic();
        }

        private void DobleClic()
        {
            try
            {
                if (Request.Params["lbPrecedenciasHidden"] != null && (string)Request.Params["lbPrecedenciasHidden"] == "doubleclicked")
                {
                    string[] cadena = lbPrecedencias.SelectedItem.Text.Split(' ');
                    int.Parse(cadena[0].TrimEnd(' '));

                    Fuentes fue = new Fuentes()
                    {
                        Numero_Fuente = int.Parse(cadena[0].TrimEnd(' '))
                    };

                    if (IsPostBack)
                    {
                        if (fue.Read())
                        {
                            LimpiarControles();
                            txtNumero.Text = fue.Numero_Fuente.ToString();
                            txtArchivo.Text = fue.Archivo_Fuente;
                            txtSistema.Text = fue.Sistema_Fuente;
                            txtContenido.Text = fue.Contenido;
                            txtCantidad.Text = fue.Cantidad_Registros.ToString();
                            ddlPeriodicidad.SelectedValue = listas.NombrePeriodicidadPorId(fue.Periodicidad);
                            ddlExtractor.SelectedValue = listas.NombreExtractorPorId(fue.Tipo_Extractor);

                            CargarRelaciones();
                        }
                        else
                        {
                            LimpiarControles();
                            lblNumeroFuente.Text = "Fuente no encontrada.";
                            txtArchivo.Focus();
                        }
                    }
                }

                if (Request.Params["lbDestinosHidden"] != null && (string)Request.Params["lbDestinosHidden"] == "doubleclicked")
                {
                    string[] cadena = lbDestinos.SelectedItem.Text.Split(' ');
                    int.Parse(cadena[0].TrimEnd(' '));

                    Fuentes fue = new Fuentes()
                    {
                        Numero_Fuente = int.Parse(cadena[0].TrimEnd(' '))
                    };

                    if (IsPostBack)
                    {
                        if (fue.Read())
                        {
                            LimpiarControles();
                            txtNumero.Text = fue.Numero_Fuente.ToString();
                            txtArchivo.Text = fue.Archivo_Fuente;
                            txtSistema.Text = fue.Sistema_Fuente;
                            txtContenido.Text = fue.Contenido;
                            txtCantidad.Text = fue.Cantidad_Registros.ToString();
                            ddlPeriodicidad.SelectedValue = listas.NombrePeriodicidadPorId(fue.Periodicidad);
                            ddlExtractor.SelectedValue = listas.NombreExtractorPorId(fue.Tipo_Extractor);

                            CargarRelaciones();
                        }
                        else
                        {
                            LimpiarControles();
                            lblNumeroFuente.Text = "Fuente no encontrada.";
                            txtArchivo.Focus();
                        }
                    }
                }

                if (Request.Params["lbMinorsHidden"] != null && (string)Request.Params["lbMinorsHidden"] == "doubleclicked")
                {
                    string[] cadena = lbMinors.SelectedItem.Text.Split(' ');
                    int.Parse(cadena[0].TrimEnd(' '));

                    Fuentes fue = new Fuentes()
                    {
                        Numero_Fuente = int.Parse(cadena[0].TrimEnd(' '))
                    };

                    if (IsPostBack)
                    {
                        if (fue.Read())
                        {
                            LimpiarControles();
                            txtNumero.Text = fue.Numero_Fuente.ToString();
                            txtArchivo.Text = fue.Archivo_Fuente;
                            txtSistema.Text = fue.Sistema_Fuente;
                            txtContenido.Text = fue.Contenido;
                            txtCantidad.Text = fue.Cantidad_Registros.ToString();
                            ddlPeriodicidad.SelectedValue = listas.NombrePeriodicidadPorId(fue.Periodicidad);
                            ddlExtractor.SelectedValue = listas.NombreExtractorPorId(fue.Tipo_Extractor);

                            CargarRelaciones();
                        }
                        else
                        {
                            LimpiarControles();
                            lblNumeroFuente.Text = "Fuente no encontrada.";
                            txtArchivo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CargarDdl()
        {
            ddlPeriodicidad.DataSource = listas.Periodicidad_ReadAll().Select(p => p.Nombre_Periodicidad);
            ddlPeriodicidad.DataBind();
            ddlPeriodicidad.Items.Insert(0, "--Seleccione periodicidad--");
            ddlPeriodicidad.SelectedIndex = 0;
            ddlExtractor.DataSource = listas.Extractor_ReadAll().Select(e => e.Nombre_Extractor);
            ddlExtractor.DataBind();
            ddlExtractor.Items.Insert(0, "--Seleccione extractor--");
            ddlExtractor.SelectedIndex = 0;

            ddlPrecedencias.DataSource = listas.DescripcionFuente_ReadAll().Select(f => f.Nombre);
            ddlPrecedencias.DataBind();
            ddlPrecedencias.Items.Insert(0, "--Seleccione precedencia--");
            ddlPrecedencias.SelectedIndex = 0;
            ddlDestinos.DataSource = listas.DescripcionFuente_ReadAll().Select(f => f.Nombre);
            ddlDestinos.DataBind();
            ddlDestinos.Items.Insert(0, "--Seleccione destino--");
            ddlDestinos.SelectedIndex = 0;
            ddlMinors.DataSource = listas.DescripcionFuente_ReadAll().Select(f => f.Nombre);
            ddlMinors.DataBind();
            ddlMinors.Items.Insert(0, "--Seleccione minor--");
            ddlMinors.SelectedIndex = 0;
        }

        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            Fuentes fue = new Fuentes()
            {
                Numero_Fuente = int.Parse(txtNumero.Text)
            };

            if (IsPostBack)
            {
                if (fue.Read())
                {
                    LimpiarControles();
                    txtArchivo.Text = fue.Archivo_Fuente;
                    txtSistema.Text = fue.Sistema_Fuente;
                    txtContenido.Text = fue.Contenido;
                    txtCantidad.Text = fue.Cantidad_Registros.ToString();
                    ddlPeriodicidad.SelectedValue = listas.NombrePeriodicidadPorId(fue.Periodicidad);
                    ddlExtractor.SelectedValue = listas.NombreExtractorPorId(fue.Tipo_Extractor);

                    CargarRelaciones();
                }
                else
                {
                    LimpiarControles();
                    lblNumeroFuente.Text = "Fuente no encontrada.";
                    txtArchivo.Focus();
                }
            }
        }

        private void CargarRelaciones()
        {
            //lbPrecedencias.DataSource = listas.ListaRelacionesPrecedenciasPorId(int.Parse(txtNumero.Text));
            lbPrecedencias.DataSource = listas.ListaPrecedenciasLB(int.Parse(txtNumero.Text), 1);
            lbPrecedencias.DataBind();
            //ddlPrecedencias.DataSource = listas.ListaPrecedenciasNoAsociadas(int.Parse(txtNumero.Text));
            ddlPrecedencias.DataSource = listas.ListaPrecedencias(int.Parse(txtNumero.Text));
            ddlPrecedencias.DataBind();
            ddlPrecedencias.Items.Insert(0, "--Seleccione precedencia--");
            ddlPrecedencias.SelectedIndex = 0;

            //lbDestinos.DataSource = listas.ListaRelacionesDestinosPorId(int.Parse(txtNumero.Text));
            lbDestinos.DataSource = listas.ListaPrecedenciasLB(int.Parse(txtNumero.Text), 2);
            lbDestinos.DataBind();
            //ddlDestinos.DataSource = listas.ListaDestinosNoAsociados(int.Parse(txtNumero.Text));
            ddlDestinos.DataSource = listas.ListaPrecedencias(int.Parse(txtNumero.Text));
            ddlDestinos.DataBind();
            ddlDestinos.Items.Insert(0, "--Seleccione destino--");
            ddlDestinos.SelectedIndex = 0;

            //lbMinors.DataSource = listas.ListaRelacionesMinorPorId(int.Parse(txtNumero.Text));
            lbMinors.DataSource = listas.ListaPrecedenciasLB(int.Parse(txtNumero.Text), 3);
            lbMinors.DataBind();
            //ddlMinors.DataSource = listas.ListaMinorsNoAsociadas(int.Parse(txtNumero.Text));
            ddlMinors.DataSource = listas.ListaPrecedencias(int.Parse(txtNumero.Text));
            ddlMinors.DataBind();
            ddlMinors.Items.Insert(0, "--Seleccione minor--");
            ddlMinors.SelectedIndex = 0;
        }

        private void LimpiarControles()
        {
            txtArchivo.Text = string.Empty;
            txtSistema.Text = string.Empty;
            txtContenido.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            ddlPeriodicidad.SelectedIndex = 0;
            ddlExtractor.SelectedIndex = 0;
            lblMensaje.Text = string.Empty;

            lbPrecedencias.Items.Clear();
            lbDestinos.Items.Clear();
            lbMinors.Items.Clear();

            ddlPrecedencias.SelectedIndex = 0;
            ddlDestinos.SelectedIndex = 0;
            ddlMinors.SelectedIndex = 0;

            lblNumeroFuente.Text = string.Empty;
            lblPrecedencias.Text = string.Empty;
            lblDestinos.Text = string.Empty;
            lblMinors.Text = string.Empty;
            lblMinors.Text = string.Empty;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Fuentes fue = new Fuentes()
                {
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Archivo_Fuente = txtArchivo.Text,
                    Sistema_Fuente = txtSistema.Text,
                    Contenido = txtContenido.Text,
                    Cantidad_Registros = int.Parse(txtCantidad.Text),
                    Periodicidad = listas.IdPeriodicidadPorNombre(ddlPeriodicidad.SelectedValue.ToString()),
                    Tipo_Extractor = listas.IdExtractorPorNombre(ddlExtractor.SelectedValue.ToString()),
                    Nombre = txtSistema.Text + "_" + txtArchivo.Text
                };

                if (fue.Create())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Fuente N°: " + txtNumero.Text + ", creada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No puede crearse la fuente.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear fuente nueva.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Fuentes fue = new Fuentes()
                {
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Archivo_Fuente = txtArchivo.Text,
                    Sistema_Fuente = txtSistema.Text,
                    Contenido = txtContenido.Text,
                    Cantidad_Registros = int.Parse(txtCantidad.Text),
                    Periodicidad = listas.IdPeriodicidadPorNombre(ddlPeriodicidad.SelectedValue.ToString()),
                    Tipo_Extractor = listas.IdExtractorPorNombre(ddlExtractor.SelectedValue.ToString()),
                    Nombre = txtSistema.Text + "_" + txtArchivo.Text
                };

                if (fue.Update())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Fuente N°: " + txtNumero.Text + ", actualizada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No se puede actualizar la fuente.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar fuente.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int idFuente = int.Parse(txtNumero.Text);

                Fuentes fue = new Fuentes()
                {
                    Numero_Fuente = idFuente
                };

                if(fue.Delete())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Fuente N°: " + idFuente + ", eliminada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No se puede eliminar la fuente.";
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar fuente.";
            }
        }

        protected void btnCreatePrecedencia_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = ddlPrecedencias.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 1,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                if (rel.Create())
                {
                    lblPrecedencias.Text = "Precedencia agregada correctamente.";
                    CargarRelaciones();
                }
                else
                {
                    lblPrecedencias.Text = "Precedencia no agregada.";
                }
            }
            catch (Exception ex)
            {
                lblPrecedencias.Text = "Error al agregar precedencia.";
            }
        }

        protected void btnDeletePrecedencia_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = lbPrecedencias.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 1,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                if (rel.Delete())
                {
                    lblPrecedencias.Text = "Precedencia eliminada correctamente.";
                    CargarRelaciones();
                }
                else
                {
                    lblPrecedencias.Text = "Precedencia no eliminada.";
                }
            }
            catch (Exception ex)
            {
                lblPrecedencias.Text = "Error al eliminar precedencia.";
            }
        }

        protected void btnCreateDestino_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = ddlDestinos.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 2,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                Relacion rel2 = new Relacion()
                {
                    Id_Tipo_Relacion = 1,
                    Numero_Fuente = int.Parse(cadena[0].TrimEnd(' ')),
                    Numero_Fuente_Relacionada = int.Parse(txtNumero.Text)
                };

                if (rel.Create() && rel2.Create())
                {
                    lblDestinos.Text = "Destino agregado correctamente.";
                    CargarRelaciones();
                }
                else
                {
                    lblDestinos.Text = "Destino no agregado.";
                }
            }
            catch (Exception ex)
            {
                lblDestinos.Text = "Error al agregar destino.";
            }
        }

        protected void btnDeleteDestino_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = lbDestinos.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 2,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                Relacion rel2 = new Relacion()
                {
                    Id_Tipo_Relacion = 1,
                    Numero_Fuente = int.Parse(cadena[0].TrimEnd(' ')),
                    Numero_Fuente_Relacionada = int.Parse(txtNumero.Text)
                };

                if (rel.Delete())
                {
                    if (rel2.Read())
                    {
                        rel2.Delete();
                        lblDestinos.Text = "Destino eliminado correctamente.";
                        CargarRelaciones();
                    }
                    else
                    {
                        lblDestinos.Text = "Destino eliminado correctamente.";
                        CargarRelaciones();
                    }
                }
                else
                {
                    lblDestinos.Text = "Destino no eliminado.";
                }
            }
            catch (Exception ex)
            {
                lblDestinos.Text = "Error al eliminar Destino.";
            }
        }

        protected void btnCreateMinor_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = ddlMinors.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 3,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                if (rel.Create())
                {
                    lblMinors.Text = "Minor agregada correctamente.";
                    CargarRelaciones();
                }
                else
                {
                    lblMinors.Text = "Minor no agregada.";
                }
            }
            catch (Exception ex)
            {
                lblMinors.Text = "Error al agregar Minor.";
            }
        }

        protected void btnDeleteMinor_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cadena = lbMinors.SelectedItem.Text.Split(' ');

                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = 3,
                    Numero_Fuente = int.Parse(txtNumero.Text),
                    Numero_Fuente_Relacionada = int.Parse(cadena[0].TrimEnd(' '))
                };

                if (rel.Delete())
                {
                    lblMinors.Text = "Minor eliminada correctamente.";
                    CargarRelaciones();
                }
                else
                {
                    lblMinors.Text = "Minor no eliminada.";
                }
            }
            catch (Exception ex)
            {
                lblMinors.Text = "Error al eliminar Minor.";
            }
        }


        private void CargaFromTabla()
        {
            if (Session["_relacion"] != null)
            {
                txtNumero.Text = relacion.Id_Tipo_Relacion.ToString();
                Fuentes fue = new Fuentes()
                {
                    Numero_Fuente = int.Parse(txtNumero.Text)
                };
                if (fue.Read())
                {
                    txtArchivo.Text = fue.Archivo_Fuente;
                    txtSistema.Text = fue.Sistema_Fuente;
                    txtContenido.Text = fue.Contenido;
                    txtCantidad.Text = fue.Cantidad_Registros.ToString();
                    ddlPeriodicidad.SelectedIndex = fue.Periodicidad;
                    ddlExtractor.SelectedIndex = fue.Tipo_Extractor;
                    CargarRelaciones();
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtNumero.Text = string.Empty;
        }

    }
}