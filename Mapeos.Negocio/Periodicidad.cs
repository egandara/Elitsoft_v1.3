using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Periodicidad
    {
        public int Id_Periodicidad { get; set; }
        public string Nombre_Periodicidad { get; set; }

        public Periodicidad()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Periodicidad = 0;
            Nombre_Periodicidad = string.Empty;
        }
    }
}
