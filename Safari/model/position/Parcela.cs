using System;
using Safari.model.seres;

namespace Safari.model.position
{
    internal class Parcela
    {
        /// <summary>
        /// Diccionario donde se almacena cada posición y el ser que hay en ella (puede no haber ninguno)
        /// </summary>
        public Dictionary<Position, Ser?> posiciones { get; set; }

        public const int filasMaximas = 10;

        public const int columnasMaximas = 20;

        public const int filasMinimas = 5;

        public const int columnasMinimas = 5;
        
        public Parcela()
        {
            posiciones = new Dictionary<Position, Ser?>();
        }

        public int filas { get; set; }
        public int columnas { get; set; }

        public void fillParcela()
        {
            
            posiciones.Clear();
           
            // LLenar la parcela con nulos
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Position pos = new Position(i, j);
                    posiciones.Add(pos, null);
                }
            }

            int numPlantas = filas * columnas / 3;
            int numGacelas = 2 * filas * columnas / 9;
            int numLeones = filas * columnas / 9;
            int numVacios = filas * columnas / 3;

            Console.WriteLine($"numPlantas {numPlantas}");
            Console.WriteLine($"numGacelas {numGacelas}");
            Console.WriteLine($"numLeones {numLeones}");
            Console.WriteLine($"numVacios {numVacios}");


            List<Position> posicionesConSer = new List<Position>();
            llenarConTipoDeSer(typeof(Leon), numLeones);
            llenarConTipoDeSer(typeof(Gacela), numGacelas);
            llenarConTipoDeSer(typeof(Planta), numPlantas);

        }

        private void llenarConTipoDeSer(Type type, int numObjetivo)
        {
            var random = new Random();
            for (var i = 0; i < numObjetivo; i++)
            {
                Position? pos = null;
                do
                {
                    var filaRandom = random.Next(filas);
                    var columnaRandom = random.Next(columnas);
                    pos = new Position(filaRandom, columnaRandom);
                } while (posiciones[pos] is not null);
                posiciones[pos] = (Ser) type.GetConstructor([]).Invoke([]);
            }
        }

        public List<Position> getSurroundingPositions(Position pos)
        {
            List<Position> posiciones = new List<Position>();

            var fila = pos.fila;
            int filaNueva;
            int columnaNueva;
            var columna = pos.columna;
            for (int i = -1; i <= 1; i++)
            {
                filaNueva = fila + i;
                if (filaNueva < 0) filaNueva = this.filas - 1;
                else if (filaNueva >= this.filas) filaNueva = 0;
                for (int j = -1; j <= 1; j++)
                {
                    columnaNueva = columna + j;
                    if (columnaNueva < 0) columnaNueva = this.columnas - 1;
                    else if (columnaNueva >= this.columnas) columnaNueva = 0;
                    if (filaNueva == fila && columnaNueva == columna) continue;
                    Position position = new Position(filaNueva, columnaNueva);
                    posiciones.Add(position);
                }
            }
            
            return posiciones;
        }
    }
}