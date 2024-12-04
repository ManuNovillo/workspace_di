using Safari.model.position;

namespace Safari.model.seres
{
    public abstract class Ser
    {
        /// <summary>
        /// Número de días que tienen que pasar para que se pueda reproducir
        /// </summary>
        protected int periodoReproduccion;


        /// <summary>
        /// Días que han pasado desde la última reproducción
        /// </summary>
        protected int pasosDesdeUltimaReproduccion;

        protected int pasosVividos;

        public void reproducirse()
        {
            pasosDesdeUltimaReproduccion = 1;
        }

        public Ser()
        {
            pasosDesdeUltimaReproduccion = 1;
            pasosVividos = 0;
        }

        public bool debeReproducirse()
        {
            return pasosVividos > 0 && (pasosDesdeUltimaReproduccion >= periodoReproduccion);
        }

        public void incrementarPasosVividos()
        {
            pasosVividos++;

        }

        public void incrementarPasosDesdeUltimaReproduccion()
        {
            pasosDesdeUltimaReproduccion++;
        }

    }
}
