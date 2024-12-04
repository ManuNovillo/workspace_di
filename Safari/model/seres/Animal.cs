namespace Safari.model.seres
{
    internal abstract class Animal : Ser
    {
        protected int pasosSinComer;

        /// <summary>
        /// Cuántos pasos sin comer tiene que estar para morir
        /// </summary>
        protected int periodoMuerteInanicion;

        public Animal()
        {
            pasosSinComer = 0;
            periodoMuerteInanicion = 3;
        }

        public abstract Type getTipoComida();

        public int getDiasSinComer()
        {
            return pasosSinComer;
        }

        public void comer()
        {
            pasosSinComer = 0;
        }

        public bool debeMorirDeInanicion()
        {
            return pasosSinComer >= periodoMuerteInanicion;
        }

        internal void incrementarPasosSinComer()
        {
            pasosSinComer++;
        }
    }
}
