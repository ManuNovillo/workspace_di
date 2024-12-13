namespace Safari.model.seres
{
    // Examen 1 (no tenia clase herbivoro antes)
    internal abstract class Herbivoro : Animal
    {
        public Herbivoro() {
            this.periodoReproduccion = 4;
        }
        public override Type getTipoComida()
        {
            return typeof(Planta);
        }
    }
}
