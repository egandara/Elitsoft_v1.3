using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;

namespace Mapeos.Web
{
    public partial class Mant_Severidades : System.Web.UI.Page
    {
        Colecciones listas = new Colecciones();

        Negocio.Severidades severidades
        {
            get { return (Negocio.Severidades)Session["_severidades"]; }
            set { Session["_severidades"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                    string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);

                    if (previousPageName == "Severidades.aspx")
                    {
                        CargarDdl();
                        CargaFromTabla();
                        txtNumeroFuente.Focus();
                    }
                    else
                    {
                        LimpiarControles();
                        txtNumeroFuente.Text = string.Empty;
                        previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                        previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                        CargarDdl();
                        txtNumeroFuente.Focus();
                    }
                }
            }
            /*
            if (!IsPostBack)
            {
                CargarDdl();
                LimpiarControles();
                CargaFromTabla();
            }
             * */
        }

        private void CargarDdl()
        {
            ddlQualityTypeCd.DataSource = listas.Tipo_Calidad_ReadAll().Select(p => p.Nombre_Calidad);
            ddlQualityTypeCd.DataBind();
            ddlQualityTypeCd.Items.Insert(0, "--Seleccione Quality Type--");
            ddlQualityTypeCd.SelectedIndex = 0;
        }

        protected void btAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Severidades sev = new Negocio.Severidades()
                {    
                    Numero_Fuente = int.Parse(txtNumeroFuente.Text)
                    ,Data = int.Parse(txtData.Text)
                    ,Destination_Table_Name = txtDestionTableName.Text
                    ,Source_Column_Name = txtSourceColumnName.Text
                    ,Fuente_Destino = int.Parse(txtFuenteDestino.Text)
                    ,Ref_Table_Name = txtRefTableName.Text
                    ,Ref_Column_Name = txtRefColumnName.Text
                    ,Business_Rule_Cd = int.Parse(txtBusinessRuleCd.Text)
                    ,Business_Rule_Desc = txtBusinessRuleDesc.Text
                    ,Id_Quality_Type = listas.IdQualityTypePorNombre(ddlQualityTypeCd.SelectedValue.ToString())
                    ,Estado = ChbEstado.Checked
                    
                };
                if (sev.Create())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Severidad para el N° de fuente: " + sev.Numero_Fuente + ", creada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No puede crearse la severidad.";
                }

            }catch(Exception ex){
                lblMensaje.Text = "Error al crear nueva severidad.";
            }
        }

        protected void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Severidades sev = new Negocio.Severidades()
                {
                    Numero_Fuente = int.Parse(txtNumeroFuente.Text)
                    ,Data = int.Parse(txtData.Text)
                    ,Destination_Table_Name = txtDestionTableName.Text
                    ,Source_Column_Name = txtSourceColumnName.Text
                    ,Fuente_Destino = int.Parse(txtFuenteDestino.Text)
                    ,Ref_Table_Name = txtRefTableName.Text
                    ,Ref_Column_Name = txtRefColumnName.Text
                    ,Business_Rule_Cd = int.Parse(txtBusinessRuleCd.Text)
                    ,Business_Rule_Desc = txtBusinessRuleDesc.Text
                    ,Id_Quality_Type = listas.IdPeriodicidadPorNombre(ddlQualityTypeCd.SelectedValue.ToString())
                    ,Estado = ChbEstado.Checked
                    
                };
                if (sev.Update())
                {
                    LimpiarControles();
                    lblMensaje.Text = "Severidad para el N° de fuente: " + txtNumeroFuente.Text + ", actualizada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No puede actualizarse la severidad.";
                }
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al actulizar la severidad.";
            }
        }

        protected void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al eliminar la severidad.";
            }
        }

        private void LimpiarControles()
        {
            txtNumeroFuente.Text = string.Empty;
            txtData.Text = string.Empty;
            txtDestionTableName.Text = string.Empty;
            txtSourceColumnName.Text = string.Empty;
            txtFuenteDestino.Text = string.Empty;
            txtRefColumnName.Text = string.Empty;
            txtRefTableName.Text = string.Empty;
            txtBusinessRuleCd.Text = string.Empty;
            txtBusinessRuleDesc.Text = string.Empty;
            ddlQualityTypeCd.SelectedIndex = 0;
            ChbEstado.Checked = false;        
        }

        private void CargaFromTabla()
        {
            if (Session["_severidades"] != null)
            {
                txtIdSeveridad.Text = severidades.Id_Severidades.ToString();
                Negocio.Severidades ser = new Negocio.Severidades()
                {
                    Id_Severidades = int.Parse(txtIdSeveridad.Text)
                };
                if (ser.Read())
                {
                    txtIdSeveridad.Text = ser.Id_Severidades.ToString();
                    txtNumeroFuente.Text = ser.Numero_Fuente.ToString();
                    txtData.Text = ser.Data.ToString();
                    txtDestionTableName.Text = ser.Destination_Table_Name;
                    txtSourceColumnName.Text = ser.Source_Column_Name;
                    txtFuenteDestino.Text = ser.Fuente_Destino.ToString();
                    txtRefColumnName.Text = ser.Ref_Column_Name;
                    txtRefTableName.Text = ser.Ref_Table_Name;
                    txtBusinessRuleCd.Text = ser.Business_Rule_Cd.ToString();
                    txtBusinessRuleDesc.Text = ser.Business_Rule_Desc;
                    ddlQualityTypeCd.SelectedValue = listas.IdQualityTypePorId(ser.Id_Quality_Type);
                    if (ser.Estado == true)
                    {
                        ChbEstado.Checked = true;
                    }
                    else
                    {
                        ChbEstado.Checked = false;
                    }
                }
            }
        }

    }
}