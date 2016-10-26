using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Fuentes:IPersistente
    {
        public int Numero_Fuente { get; set; }
        public string Archivo_Fuente { get; set; }
        public string Sistema_Fuente { get; set; }
        public string Contenido { get; set; }
        public int Cantidad_Registros { get; set; }
        public int Periodicidad { get; set; }
        public int Tipo_Extractor { get; set; }
        public string Nombre { get; set; }

        public Fuentes()
        {
            this.Init();
        }

        private void Init()
        {
            Numero_Fuente = 0;
            Archivo_Fuente = string.Empty;
            Sistema_Fuente = string.Empty;
            Contenido = string.Empty;
            Cantidad_Registros = 0;
            Periodicidad = 0;
            Tipo_Extractor = 0;
            Nombre = string.Empty;
        }

        public bool Create()
        {
            DALC.desc_fuente fue = new DALC.desc_fuente();

            try
            {
                fue.numero_fuente = Numero_Fuente;
                fue.archivo_fuente = Archivo_Fuente;
                fue.sistema_fuente = Sistema_Fuente;
                fue.contenido = Contenido;
                fue.cantidad_registros = Cantidad_Registros;
                fue.id_periodicidad = Periodicidad;
                fue.id_extractor = Tipo_Extractor;
                fue.nombre = Nombre;

                CommonBC.Modelo.desc_fuente.AddObject(fue);
                //CommonBC.Modelo.InsertarFuente(Num_Fuente, Archivo_Fuente, Sistema_Fuente, Contenido, Cantidad_Registros, Periodicidad, Tipo_Extractor);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.desc_fuente fue = CommonBC.Modelo.desc_fuente.First(f => f.numero_fuente == Numero_Fuente);

                Archivo_Fuente = fue.archivo_fuente;
                Sistema_Fuente = fue.sistema_fuente;
                Contenido = fue.contenido;
                Cantidad_Registros = fue.cantidad_registros;
                Periodicidad = fue.id_periodicidad;
                Tipo_Extractor = fue.id_extractor;
                Nombre = fue.nombre;

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
                DALC.desc_fuente fue = CommonBC.Modelo.desc_fuente.First(f => f.numero_fuente == Numero_Fuente);

                fue.archivo_fuente = Archivo_Fuente;
                fue.sistema_fuente = Sistema_Fuente;
                fue.contenido = Contenido;
                fue.cantidad_registros = Cantidad_Registros;
                fue.id_periodicidad = Periodicidad;
                fue.id_extractor = Tipo_Extractor;
                fue.nombre = Nombre;

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
                DALC.desc_fuente fue = CommonBC.Modelo.desc_fuente.First(f => f.numero_fuente == Numero_Fuente);

                CommonBC.Modelo.desc_fuente.DeleteObject(fue);
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
