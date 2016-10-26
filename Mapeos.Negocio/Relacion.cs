using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Relacion
    {
        public int Id_Tipo_Relacion { get; set; }
        public int Numero_Fuente { get; set; }
        public int Numero_Fuente_Relacionada { get; set; }

        public Relacion()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Tipo_Relacion = 0;
            Numero_Fuente = 0;
            Numero_Fuente_Relacionada = 0;
        }

        public bool Create()
        {
            DALC.relacion rel = new DALC.relacion();

            try
            {
                //CommonBC.Modelo.InsertarPrecedencia(Id_Tipo_Relacion, Numero_Fuente, Numero_Fuente_Relacionada);
                rel.id_tipo_relacion = Id_Tipo_Relacion;
                rel.numero_fuente = Numero_Fuente;
                rel.numero_fuente_relacionada = Numero_Fuente_Relacionada;

                CommonBC.Modelo.AddTorelacion(rel);
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
                DALC.relacion fue = CommonBC.Modelo.relacion.First(f => f.numero_fuente == Numero_Fuente);

                Id_Tipo_Relacion = fue.id_tipo_relacion;
                Numero_Fuente = fue.numero_fuente;
                Numero_Fuente_Relacionada = fue.numero_fuente_relacionada;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            try
            {
                DALC.relacion rel = CommonBC.Modelo.relacion.First(r => r.numero_fuente == Numero_Fuente && r.numero_fuente_relacionada == Numero_Fuente_Relacionada && r.id_tipo_relacion == Id_Tipo_Relacion);

                CommonBC.Modelo.relacion.DeleteObject(rel);
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
