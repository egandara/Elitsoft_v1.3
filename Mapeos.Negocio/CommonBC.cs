using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class CommonBC
    {
        private static DALC.MapeoEntities _modelo;

        public static DALC.MapeoEntities Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new DALC.MapeoEntities();
                }
                return _modelo;
            }
        }
    }
}
