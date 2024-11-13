using System;
using Safari.model.seres;

namespace Safari.model.position
{
    public class Parcela
    {
        /// <summary>
        /// Diccionario donde se almacena cada posición y el ser que hay en ella (puede no haber ninguno)
        /// </summary>

        public Dictionary<Position, Ser?> Posiciones { get; set; }
        public Parcela()
        {
            Posiciones = new Dictionary<Position, Ser?>();
        }

        public int Filas { get; set; }
        public int Columnas { get; set; }

        public void fillParcela()
        {
            // Variable con la que determinar aleatoriamente qué ser poner en cada posición
            Random random = new Random();
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
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
                    Posiciones.Add(pos, ser);
                }
            }
        }
    }
}