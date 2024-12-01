using System;

namespace Safari.model.seres
{
    internal abstract class Animal : Ser
    {
        public abstract Type getTipoComida();

        protected int diasSinComer;

        protected int periodoMuerteInanicion;

        public Animal()
        {
            diasSinComer = 0;
            periodoMuerteInanicion = 3;
        }

        public int getDiasSinComer()
        {
            return diasSinComer;
        }

        public void comer()
        {
            diasSinComer = 0;
        }

        public bool debeMorirDeInanicion()
        {
            return diasSinComer >= periodoMuerteInanicion;
        }

        internal void incrementarDiasSinComer()
        {
            diasSinComer++;
        }
    }
}
