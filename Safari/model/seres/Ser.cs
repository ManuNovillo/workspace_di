using Safari.model.position;

namespace Safari.model.seres
{
    public abstract class Ser
    {
        /// <summary>
        /// Número de días que tienen que pasar para que se pueda reproducir
        /// </summary>
        protected static int periodoReproduccion;

        protected bool puedeReproducirse;

        static int numStatic = 0;
        public int num;

        /// <summary>
        /// Días que han pasado desde la última reproducción
        /// </summary>
        protected int diasDesdeUltimaReproduccion;

        protected int diasVividos;

        public void checkReproduccion()
        {
            if (diasVividos == periodoReproduccion ||
                diasDesdeUltimaReproduccion == periodoReproduccion)
                puedeReproducirse = true;
        }

        public void reproducirse()
        {
            puedeReproducirse = false;
            diasDesdeUltimaReproduccion = 0;
        }

        public Ser()
        {
            diasDesdeUltimaReproduccion = 0;
            diasVividos = 0;
            puedeReproducirse = false;
            num = numStatic;
            numStatic++;
        }

        public bool debeReproducirse()
        {
            return puedeReproducirse;
        }

        public void aumentarDiasVividos()
        {
            diasVividos++;

        }

    }
}
