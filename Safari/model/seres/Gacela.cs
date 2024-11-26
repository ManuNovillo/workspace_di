namespace Safari.model.seres
{
    internal class Gacela : Animal
    {
        public Gacela()
        {
            this.periodoReproduccion = 4;
        }


        public override String ToString()
        {
            return "Gacela";
        }

        public override Type getTipoComida()
        {
            return typeof(Planta);
        }
    }
}
