using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Tipo_Relacion
    {
        public int IdTipoRelacion { get; set; }
        public string NombreTipoRelacion { get; set; }

        public Tipo_Relacion()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoRelacion = 0;
            NombreTipoRelacion = string.Empty;
        }
    }
}
