using Safari.model.position;

namespace Safari.model.seres
{
    public abstract class Ser
    {
        /// <summary>
        /// Número de días que tienen que pasar para que se pueda reproducir
        /// </summary>
        protected static int periodoReproduccion;

        protected bool debeReproducirse;

        /// <summary>
        /// Días que han pasado desde la última reproducción
        /// </summary>
        protected int diasDesdeReproduccion;

        protected int diasVividos;

        public void checkReproduccion()
        {
            if (diasVividos == periodoReproduccion ||
                diasDesdeReproduccion == periodoReproduccion)
                debeReproducirse = true;
        }

        public void reproducirse()
        {
            debeReproducirse = false;
            diasDesdeReproduccion = 0;
        }

        public Ser()
        {
            diasDesdeReproduccion = 0;
            diasVividos = 0;
            debeReproducirse = false;
        }

    }
}
