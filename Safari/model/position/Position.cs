using Safari.model.seres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.model.position
{
    internal class Position
    {

        /// <summary>
        /// Coordenada x, siendo 0 el borde izquierdo de la pantalla y cada vez más grande
        /// al desplazarnos hacia la derecha
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Coordenada y, siendo 0 el borde superior de la pantalla y cada vez más grande
        /// al desplazarnos hacia abajo
        /// </summary>
        public int Y { get; set; }

        internal List<Position> getEmptySurroundingPos()
        {
            return new List<Position>();

        }
    }
}
