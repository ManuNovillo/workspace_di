namespace Safari.model.seres
{
    internal class Gacela : Animal
    {
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
