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

        public const int filasMinimas = 3;

        public const int columnasMinimas = 3;
        
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
            posiciones.Clear();
            int numPlantas = filas * columnas / 3;
            int numGacelas = 2 * filas * columnas / 9;
            int numLeones =  filas * columnas / 9;
            int numVacios = filas * columnas / 3;
            Console.WriteLine($"numPlantas {numPlantas}");
            Console.WriteLine($"numGacelas {numGacelas}");
            Console.WriteLine($"numLeones {numLeones}");
            Console.WriteLine($"numVacios {numVacios}");
            int leonesPuestos = 0;
            int gacelasPuestas = 0;
            int plantasPuestas = 0;
            int vaciosPuestos = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Decidir aleatoriamente qué ser añadir a la posición, o si no añadir ninguno
                    Ser? ser = null;
                    var hayQueRepetir = true;
                    while (hayQueRepetir)
                    {
                        var num = random.Next(4);
                        switch (num)
                        {
                            case 0:
                                if (gacelasPuestas < numGacelas)
                                {
                                    Console.WriteLine("DENTRO GACELAS");
                                    ser = new Gacela();
                                    gacelasPuestas++;
                                    hayQueRepetir = false;
                                }
                                break;
                            case 1:
                                if (plantasPuestas < numPlantas)
                                {
                                    Console.WriteLine("DENTRO PLANTAS");
                                    ser = new Planta();
                                    plantasPuestas++;
                                    hayQueRepetir = false;
                                }
                                break;
                            case 2:
                                if (leonesPuestos < numLeones)
                                {
                                    Console.WriteLine("DENTRO LEONES");
                                    ser = new Leon();
                                    leonesPuestos++;
                                    hayQueRepetir = false;
                                }
                                break;
                            case 3:
                                if (vaciosPuestos < numVacios)
                                {
                                    Console.WriteLine("DENTRO VACIOS");
                                    ser = null;
                                    vaciosPuestos++;
                                    hayQueRepetir = false;
                                }
                                break;
                        }
                    }
                    
                    Position pos = new Position(i, j);
                    posiciones.Add(pos, ser);
                }
                Console.WriteLine("FUERA DE TODO");
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