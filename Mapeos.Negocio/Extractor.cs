using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Extractor
    {
        public int Id_Extractor { get; set; }
        public string Nombre_Extractor { get; set; }

        public Extractor()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Extractor = 0;
            Nombre_Extractor = string.Empty;
        }
    }
}
