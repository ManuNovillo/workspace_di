using System;
using Safari.model.seres;

namespace Safari.model.position
{
    public class Parcela
    {
        /// <summary>
        /// Diccionario donde se almacena cada posición y el ser que hay en ella (puede no haber ninguno)
        /// </summary>
        public Dictionary<Position, Ser?> posiciones { get; set; }

        public const int filasMaximas = 8;

        public const int columnasMaximas = 15;

        public const int filasMinimas = 2;

        public const int columnasMinimas = 2;
        public Parcela()
        {
            posiciones = new Dictionary<Position, Ser?>();
        }

        public int filas { get; set; }
        public int columnas { get; set; }

        public void fillParcela()
        {
            // Variable con la que determinar aleatoriamente qué ser poner en cada posición
            Random random = new Random();
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Decidir aleatoriamente qué ser añadir a la posición, o si no añadir ninguno
                    long num = random.NextInt64(0, 4);
                    Ser? ser;
                    switch (num)
                    {
                        case 0:
                            ser = new Gacela();
                            break;
                        case 1:
                            ser = new Leon();
                            break;
                        case 2:
                            ser = new Planta();
                            break;
                        default:
                            ser = null;
                            break;
                    }
                    Position pos = new Position(i, j);
                    posiciones.Add(pos, ser);
                }
            }
        }

        public List<Position> getSurroundingPositions(Position pos)
        {
            List<Position> posiciones = new List<Position>();

            var fila = pos.fila;
            var columna = pos.columna;
            for (int i = 0; i < 4; i++)
            {

            }
            
            return posiciones;
        }
    }
}