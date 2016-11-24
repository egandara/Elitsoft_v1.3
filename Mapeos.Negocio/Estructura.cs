using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Estructura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Niludad { get; set; }
        public string Descripcion { get; set; }
        public string Usar { get; set; }
        public bool Estado { get; set; }
        public int Numero { get; set; }

        public Estructura()
        {
            this.Init();

        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
            Tipo = string.Empty;
            Niludad = string.Empty;
            Descripcion = string.Empty;
            Usar = string.Empty;
            Estado = true;
            Numero = 0;
        }

        public bool Create()
        {
            DALC.estructura est = new DALC.estructura();

            try
            {
                est.id_estructura = Id;
                est.nombre = Nombre;
                est.tipo = Tipo;
                est.niludad = Niludad;
                est.descripcion = Descripcion;
                est.usar = Usar;
                est.estado = Estado;
                est.numero_fuente = Numero;

                CommonBC.Modelo.estructura.AddObject(est);
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
                DALC.estructura est = CommonBC.Modelo.estructura.First(e => e.id_estructura == Id);

                Nombre = est.nombre;
                Tipo = est.tipo;
                Niludad = est.niludad;
                Descripcion = est.descripcion = Descripcion;
                Usar = est.usar;
                Estado = est.estado;
                Numero = est.numero_fuente;

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
                DALC.estructura est = CommonBC.Modelo.estructura.First(e => e.id_estructura == Id);

                est.nombre = Nombre;
                est.tipo = Tipo;
                est.niludad = Niludad;
                est.descripcion = Descripcion;
                est.usar = Usar;
                est.estado = Estado;
                est.numero_fuente = Numero;

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
                DALC.estructura est = CommonBC.Modelo.estructura.First(e => e.id_estructura == Id);
                CommonBC.Modelo.DeleteObject(est);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

    }
}
