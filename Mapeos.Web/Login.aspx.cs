using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mapeos.Negocio;
using System.Web.Security;

namespace Mapeos.Web
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario usuario
        {
            get { return (Usuario)Session["_usuario"]; }
            set { Session["_usuario"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lgnMapeos.Focus();
        }

        protected void lgnMapeos_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Usuario user = new Usuario()
            {
                UserName = lgnMapeos.UserName,
                Clave = Encriptacion.Encriptar(lgnMapeos.Password)
            };
            user.ValidarActivo();
            if (user.Estado == false)
            {
                lgnMapeos.FailureText = "Usuario desactivado.";
            }
            if (user.Estado == true)
            {
                if (user.ValidarUsuario())
                {
                    FormsAuthentication.RedirectFromLoginPage(user.UserName, false);
                    usuario = user;
                }
            }
        }
    }
}