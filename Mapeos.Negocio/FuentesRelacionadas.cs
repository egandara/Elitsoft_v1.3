using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class FuentesRelacionadas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public FuentesRelacionadas()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }
    }
}
