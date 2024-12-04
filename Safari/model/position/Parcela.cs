using Safari.model.seres;

namespace Safari.model.position
{
    internal class Parcela
    {
        /// <summary>
        /// Diccionario donde se almacena cada posición y el ser que hay en ella (puede ser null)
        /// </summary>
        private Dictionary<Posicion, Ser?> posiciones;

        public Dictionary<Posicion, Ser?> Posiciones { get; }

        public const int FilasMaximas = 10;

        public const int ColumnasMaximas = 20;

        public const int FilasMinimas = 5;

        public const int ColumnasMinimas = 5;
        
        public Parcela()
        {
            Posiciones = new Dictionary<Posicion, Ser?>();
        }

        public int Filas { get; set; }
        public int Columnas { get; set; }


        internal void limpiarParcela()
        {
            Posiciones.Clear();
        }
        public void fillParcela()
        {
            // LLenar la parcela con nulos
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    Posicion pos = new Posicion(i, j);
                    Posiciones.Add(pos, null);
                }
            }

            // Proporciones que debe haber de cada ser y de huecos vacíos
            int numPlantas = Filas * Columnas / 3;
            int numGacelas = 2 * Filas * Columnas / 9;
            int numLeones = Filas * Columnas / 9;
            int numVacios = Filas * Columnas / 3;

            List<Posicion> posicionesConSer = new List<Posicion>();
            llenarConTipoDeSer(typeof(Leon), numLeones);
            llenarConTipoDeSer(typeof(Gacela), numGacelas);
            llenarConTipoDeSer(typeof(Planta), numPlantas);

        }

        private void llenarConTipoDeSer(Type type, int numObjetivo)
        {
            var random = new Random();
            for (var i = 0; i < numObjetivo; i++)
            {
                Posicion? pos = null;
                do
                {
                    var filaRandom = random.Next(Filas);
                    var columnaRandom = random.Next(Columnas);
                    pos = new Posicion(filaRandom, columnaRandom);
                } while (Posiciones[pos] is not null);
                Posiciones[pos] = (Ser) type.GetConstructor([]).Invoke([]);
            }
        }

        public List<Posicion> getSurroundingPositions(Posicion pos)
        {
            List<Posicion> posiciones = new List<Posicion>();

            var fila = pos.fila;
            int filaNueva;
            int columnaNueva;
            var columna = pos.columna;
            for (int i = -1; i <= 1; i++)
            {
                filaNueva = fila + i;
                if (filaNueva < 0) filaNueva = this.Filas - 1;
                else if (filaNueva >= this.Filas) filaNueva = 0;
                for (int j = -1; j <= 1; j++)
                {
                    columnaNueva = columna + j;
                    if (columnaNueva < 0) columnaNueva = this.Columnas - 1;
                    else if (columnaNueva >= this.Columnas) columnaNueva = 0;
                    if (filaNueva == fila && columnaNueva == columna) continue;
                    Posicion position = new Posicion(filaNueva, columnaNueva);
                    posiciones.Add(position);
                }
            }
            
            return posiciones;
        }
    }
}