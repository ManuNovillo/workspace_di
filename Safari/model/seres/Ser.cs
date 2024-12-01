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
        protected int pasosDesdeUltimaReproduccion;

        protected int pasosVividos;

        public void reproducirse()
        {
            Console.WriteLine($"EL SER {this} {num} SE HA REPRODUCIDO");
            //puedeReproducirse = false;
            pasosDesdeUltimaReproduccion = 1;
        }

        public Ser()
        {
            pasosDesdeUltimaReproduccion = 1;
            pasosVividos = 0;
           // puedeReproducirse = false;
            num = numStatic;
            numStatic++;
        }

        public bool debeReproducirse()
        {
            //Console.WriteLine($"{this} {num} comprobando reproduccion, diasDesdeUltimaReproduccion = {diasDesdeUltimaReproduccion}");
            //Console.WriteLine(diasVividos > 0 && (diasVividos == periodoReproduccion || diasDesdeUltimaReproduccion >= periodoReproduccion));
            //Console.WriteLine(diasDesdeUltimaReproduccion >= periodoReproduccion);
            Console.WriteLine($"diasDesdeUltimaReproduccion = {pasosDesdeUltimaReproduccion}");
            Console.WriteLine($"periodoReproduccion {periodoReproduccion}");
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
