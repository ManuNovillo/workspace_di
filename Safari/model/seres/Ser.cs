using Safari.model.position;

namespace Safari.model.seres
{
    public abstract class Ser
    {
        /// <summary>
        /// Número de días que tienen que pasar para que se pueda reproducir
        /// </summary>
        protected int periodoReproduccion;

        //protected bool puedeReproducirse;

        static int numStatic = 0;
        public int num;

        /// <summary>
        /// Días que han pasado desde la última reproducción
        /// </summary>
        protected int diasDesdeUltimaReproduccion;

        protected int diasVividos;

        

        public void reproducirse()
        {
            Console.WriteLine($"EL SER {this} {num} SE HA REPRODUCIDO");
            //puedeReproducirse = false;
            diasDesdeUltimaReproduccion = 0;
        }

        public Ser()
        {
            diasDesdeUltimaReproduccion = 0;
            diasVividos = 0;
           // puedeReproducirse = false;
            num = numStatic;
            numStatic++;
        }

        public bool debeReproducirse()
        {
            //Console.WriteLine($"{this} {num} comprobando reproduccion, diasDesdeUltimaReproduccion = {diasDesdeUltimaReproduccion}");
            //Console.WriteLine(diasVividos > 0 && (diasVividos == periodoReproduccion || diasDesdeUltimaReproduccion >= periodoReproduccion));
            //Console.WriteLine(diasDesdeUltimaReproduccion >= periodoReproduccion);
            Console.WriteLine($"diasDesdeUltimaReproduccion = {diasDesdeUltimaReproduccion}");
            Console.WriteLine($"periodoReproduccion {periodoReproduccion}");
            return diasVividos > 0 && (diasVividos == periodoReproduccion || diasDesdeUltimaReproduccion >= periodoReproduccion);
        }

        public void incrementarDiasVividos()
        {
            diasVividos++;

        }

        public void incrementarDiasDesdeUltimaReproduccion()
        {
            diasDesdeUltimaReproduccion++;
        }

    }
}
