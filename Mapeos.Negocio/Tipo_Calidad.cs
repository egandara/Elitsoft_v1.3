using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Tipo_Calidad
    {
        public int Id_Quality_Type { get; set; }
        public string Nombre_Calidad { get; set; }

        public Tipo_Calidad()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Quality_Type = 0;
            Nombre_Calidad = string.Empty;
        }

    }
}
