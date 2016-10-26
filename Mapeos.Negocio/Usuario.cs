using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Usuario:IPersistente
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public int Tipo_Usuario { get; set; }
        public bool Estado { get; set; }

        public Usuario()
        {
            this.Init();
        }

        private void Init()
        {
            Rut = 0;
            Dv = ' ';
            Nombre = string.Empty;
            UserName = string.Empty;
            Clave = string.Empty;
            Tipo_Usuario = 0;
            Estado = true;
        }

        public bool ValidarUsuario()
        {
            try
            {
                DALC.login log = CommonBC.Modelo.login.First(u => u.usuario == UserName && u.clave == Clave);
                Rut = log.rut;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ValidarActivo()
        {
            try
            {
                DALC.login log = CommonBC.Modelo.login.First(u => u.usuario == UserName);

                Tipo_Usuario = log.id_tipo_usuario;
                Estado = log.estado;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DesactivarUsuario()
        {
            try
            {
                DALC.login usu = CommonBC.Modelo.login.First(u => u.rut == Rut && u.estado == true);
                usu.estado = false;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActivarUsuario()
        {
            try
            {
                DALC.login usu = CommonBC.Modelo.login.First(u => u.rut == Rut && u.estado == false);
                usu.estado = true;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CambiarClave(string nuevaClave)
        {
            try
            {
                DALC.login log = CommonBC.Modelo.login.First(u => u.usuario == UserName);
                log.clave = nuevaClave;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create()
        {
            DALC.login usu = new DALC.login();

            try
            {
                usu.rut = Rut;
                usu.dv = Dv.ToString();
                usu.nombre_usuario = Nombre;
                usu.usuario = UserName;
                usu.clave = Clave;
                usu.id_tipo_usuario = Tipo_Usuario;
                usu.estado = Estado;

                CommonBC.Modelo.login.AddObject(usu);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.login usu = CommonBC.Modelo.login.First(u => u.rut == Rut);
                Dv = char.Parse(usu.dv);
                Nombre = usu.nombre_usuario;
                UserName = usu.usuario;
                Clave = usu.clave;
                Tipo_Usuario = usu.id_tipo_usuario;
                Estado = usu.estado;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.login usu = CommonBC.Modelo.login.First(u => u.rut == Rut);

                usu.dv = Dv.ToString();
                usu.nombre_usuario = Nombre;
                usu.usuario = UserName;
                usu.clave = Clave;
                usu.id_tipo_usuario = Tipo_Usuario;
                usu.estado = Estado;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                DALC.login usu = CommonBC.Modelo.login.First(u => u.rut == Rut);

                CommonBC.Modelo.login.DeleteObject(usu);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
