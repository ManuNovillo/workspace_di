using Safari.model.position;
using System;

namespace Safari.model.seres
{
    internal abstract class Ser
    {
        /// <summary>
        /// Número de días que tienen que pasar para que se pueda reproducir
        /// </summary>
        protected static int periodoReproduccion;

        protected bool debeReproducirse;

        protected Position position;

        protected bool checkReproduccion()
        {
            position.X = 0;
            return position.getEmptySurroundingPos().Count() != 0;
        }
    }
}
