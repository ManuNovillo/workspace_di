using Safari.model.position;
using Safari.model.seres;
using System.Diagnostics;

namespace Safari.model
{
    public class MiSafari
    {
        private Parcela parcela;

        private int numeroPlantas;

        private int numeroGacelas;

        private int numeroLeones;

        private int numeroSeres;

        private int pasos;

        /*
         * leones: 1/9
         * gacelas: 2/9
         * plantas: 6/9
         */

        public int NumeroPlantas { get => numeroPlantas; }

        public int NumeroGacelas { get => numeroGacelas; }

        public int NumeroLeones { get => numeroLeones; }

        public int NumeroSeres { get => numeroSeres; }

        public int Pasos { get => pasos; }

        public MiSafari()
        {
            parcela = new Parcela();
        }

        private void setNumeroPlantas()
        {
            setNumero(typeof(Planta), out numeroPlantas);

            Console.WriteLine($"NUMPLANT {numeroPlantas}");
        }

        private void setNumeroGacelas()
        {
            setNumero(typeof(Gacela), out numeroGacelas);
        }

        private void setNumeroLeones()
        {
            setNumero(typeof(Leon), out numeroLeones);
        }

        private void setNumeroSeres()
        {
            numeroSeres = numeroGacelas + numeroLeones + numeroPlantas;
        }

        private void setNumero(Type type, out int numOut)
        {
            var num = 0;
            foreach (var ser in parcela.posiciones.Values)
            {
                if (ser?.GetType() == type) num++;
            }
            numOut = num;
        }

        public void setDimensiones(int filas, int columnas)
        {
            parcela.filas = filas;
            parcela.columnas = columnas;
        }

        public void fillParcela()
        {
            parcela.fillParcela();
        }

        public Dictionary<Position, Ser?> getSeres()
        {
            return parcela.posiciones;
        }

        public int getFilasMaximas()
        {
            return Parcela.filasMaximas;
        }

        public int getColumnasMaximas()
        {
            return Parcela.columnasMaximas;
        }

        public int getFilasMinimas()
        {
            return Parcela.filasMinimas;
        }

        public int getColumnasMinimas()
        {
            return Parcela.columnasMinimas;
        }

        public void step()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($"PASO {pasos}");
            var keys = parcela.posiciones.Keys.ToList();
            var seresRecorridos = new List<Ser>();
            foreach (var posicionActual in keys)
            {
                var ser = parcela.posiciones[posicionActual];
                if (ser == null) continue;
                if (seresRecorridos.Contains(ser)) continue;
                Console.WriteLine();
                Console.WriteLine("***************************");
                Console.WriteLine($"SER: {ser.ToString() + ser.num}");
                //Console.WriteLine($"POSICION INICIAL: {posicionActual}");
                seresRecorridos.Add(ser);
                var posicionesAlrededor = parcela.getSurroundingPositions(posicionActual);
                var posicionesVacias = getPosicionesVacias(posicionesAlrededor);
                var seHaReproducido = false;

                // Comprobar si se debe reproducir
                Console.WriteLine($"POSICIONES VACIAS == {posicionesVacias.Count != 0}");
                Console.WriteLine(ser.debeReproducirse());
                Console.WriteLine($"CONDICION IF: {ser.debeReproducirse() && posicionesVacias.Count != 0} ");
                if (ser.debeReproducirse() && posicionesVacias.Count != 0)
                {
                    Console.WriteLine("SE DEBE REPRODUCIR");
                    Position? posicionHijo = reproducir(ser, posicionesVacias);
                    // Eliminar posición del hijo de la lista para que el ser, en caso de poder moverse, no se ponga encima del hijo
                    if (posicionHijo != null)
                    {
                        Console.WriteLine("SE HA REPRODUCIDO");
                        posicionesVacias.Remove(posicionHijo);
                        seHaReproducido = true;
                        Ser hijo = parcela.posiciones[posicionHijo];
                        seresRecorridos.Add(hijo); // Evitar que el hijo haga algo en este turno
                        
                    }
                }
                if (ser is Animal)
                {
                    Animal animal = (Animal)ser;
                    if (animal.debeMorirDeInanicion())
                    {
                        //Console.WriteLine("DEBE MORIR DE INANCICION");
                        matarSerEnPosicion(posicionActual);
                        if (animal.GetType() == typeof(Gacela))
                        {
                            //Console.WriteLine("GACELA MUERTA");
                            numeroGacelas--;
                        }
                        else if (animal.GetType() == typeof(Leon))
                        {
                            //Console.WriteLine("LEON MUERTO");
                            numeroLeones--;
                        }
                    }
                    else
                    {
                        var posicionesConComida = getPosicionesConComida(animal.getTipoComida(), posicionesAlrededor);
                        handleAnimal((Animal) ser, posicionActual, posicionesConComida, posicionesVacias);
                    }

                    /*var random = new Random();
                    bool seHaReproducido = false;
                    var posicionesConComida = new List<Position>();

                    if (ser is Animal)
                    {
                        Animal animal = (Animal)ser;
                        if (animal.debeMorirDeInanicion())
                        {
                            matarSerEnPosicion(posicionActual); 
                        } 
                        else
                        {

                            bool haComido = false;
                            Type tipoComida = animal.getTipoComida();
                            posicionesConComida.AddRange(getPosicionesConComida(tipoComida, posicionesAlrededor));
                            var nuevaPosicion = posicionActual;
                            if (posicionesConComida.Count != 0)
                            {
                                int numAleatorio = random.Next(posicionesConComida.Count);
                                var posicionElegida = posicionesConComida[numAleatorio];
                                comer(posicionActual, posicionElegida);
                                nuevaPosicion = posicionElegida;
                                haComido = true;
                            }
                            else if (posicionesVacias.Count != 0)
                            {
                                int numAleatorio = random.Next(posicionesVacias.Count);
                                var posicionElegida = posicionesVacias[numAleatorio];
                                nuevaPosicion = posicionElegida;
                            }
                            if (!haComido) animal.incrementarDiasSinComer();

                        }
                    }
                    if (ser.debeReproducirse() && posicionesVacias.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesVacias.Count);
                        var posicionElegida = posicionesVacias[numAleatorio];
                        reproducir(ser, posicionElegida);
                        posicionesVacias.Remove(posicionElegida);
                        seHaReproducido = true;

                    }
                    if (!posicionActual.Equals(nuevaPosicion)) mover(posicionActual, nuevaPosicion);*/
                }
                ser.incrementarPasosVividos();
                if (!seHaReproducido) ser.incrementarPasosDesdeUltimaReproduccion();
            }
            pasos++;
        }

        /*private void handleLeon(Leon leon, Position posicionActual, List<Position> posicionesAlrededor)
        {
            handleAnimal(leon, posicionActual, posicionesAlrededor);
        }

        private void handleGacela(Gacela gacela, Position posicionActual, List<Position> posicionesAlrededor)
        {
            handleAnimal(gacela, posicionActual, posicionesAlrededor);
        }*/

        /// <summary>
        /// Hace todo el comportamiento del animal (comer y moverse)
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="posicionActual"></param>
        /// <param name="posicionesConComida"></param>
        /// <param name="posicionesVacias"></param>
        private void handleAnimal(Animal animal, Position posicionActual, List<Position> posicionesConComida, List<Position> posicionesVacias)
        {
            Position? nuevaPosicion = null;
            bool haComido = false;
           
            if (posicionesConComida.Count != 0)
            {
                nuevaPosicion = comer(posicionActual, posicionesConComida);
                haComido = true;
            }
            else if (posicionesVacias.Count != 0)
            {
                var random = new Random();
                int numAleatorio = random.Next(posicionesVacias.Count);
                nuevaPosicion = posicionesVacias[numAleatorio];
            }

            if (!haComido) animal.incrementarDiasSinComer();
            if (nuevaPosicion != null)
            {
                mover(posicionActual, nuevaPosicion);
            }
        }

        /// <summary>
        /// Hace que <paramref name="ser"/> se intente reproducir, y devuelve la posición del hijo en caso de reproducirse, o null si no tiene hueco para ello
        /// </summary>
        /// <param name="ser">El ser que se va a reproducir</param>
        /// <param name="posicionesVacias">Las posiciones alrededor de <paramref name="ser"/> que están vacías, donde se puede poner al hijo</param>
        /// <returns>La posición del hijo en caso de reproducirse, o null si no tiene hueco para ello</returns>
        private Position? reproducir(Ser ser, List<Position> posicionesVacias)
        {
            Console.WriteLine($"{ser} {ser.num} SE VA A REPRODUCIR");
            if (posicionesVacias.Count == 0) return null;
            var random = new Random();
            var numAleatorio = random.Next(posicionesVacias.Count);
            var posicionElegida = posicionesVacias[numAleatorio];
            Ser? hijo = null;
            if (ser is Planta)
            {
                hijo = new Planta();
                Console.WriteLine("AUMENTADO PLANTAS");
                numeroPlantas++;
            }
            else if (ser is Leon)
            {
                hijo = new Leon();
                Console.WriteLine("AUMENTADO LEONES");
                numeroLeones++;
            }
            else if (ser is Gacela)
            {
                Console.WriteLine("AUMENTADO GACELAS");
                hijo = new Gacela();
                numeroGacelas++;
            }
            ser.reproducirse();
            parcela.posiciones[posicionElegida] = hijo;
            Console.WriteLine($"REPRODUCCION DE {ser.ToString() + ser.num}, GENERANDO A {hijo.ToString() + hijo.num}");
            Console.WriteLine($"POSICION HIJO: {posicionElegida}");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            return posicionElegida;
        }

        private Position comer(Position posicionActual, List<Position> posicionesConComida)
        {
            var random = new Random();
            int numAleatorio = random.Next(posicionesConComida.Count);
            var posicionElegida = posicionesConComida[numAleatorio];
            var animal = (Animal) parcela.posiciones[posicionActual];
            animal.comer();
            //Console.WriteLine($"SE HA COMIDO A {parcela.posiciones[posicionElegida]} {parcela.posiciones[posicionElegida].num}");
            parcela.posiciones[posicionElegida] = null;
            Type tipoComida = animal.getTipoComida();
            if (tipoComida == typeof(Gacela))
            {

                numeroGacelas--;
            }
            else if (tipoComida == typeof (Planta))
            {
                numeroPlantas--;
            }
            return posicionElegida;

        }

        private void matarSerEnPosicion(Position posicionElegida)
        {
            parcela.posiciones[posicionElegida] = null;
        }

        private void mover(Position origen, Position destino)
        {
            Ser ser = parcela.posiciones[origen];
            matarSerEnPosicion(origen);
            Ser? serEnDestino = parcela.posiciones[destino];
            parcela.posiciones[destino] = ser;
            //Console.WriteLine($"DESTINO: {destino}");
            //Console.WriteLine($"SER QUE HABIA EN DESTINO: {serEnDestino?.ToString() + serEnDestino?.num}");
        }

        private List<Position> getPosicionesConComida(Type tipoComida, List<Position> posiciones)
        {
            var posicionesConComida = new List<Position>();
            posiciones.ForEach(pos =>
            {
                Ser? ser = parcela.posiciones[pos];
                if (ser != null && ser.GetType().Equals(tipoComida)) posicionesConComida.Add(pos);
            });
            return posicionesConComida;
        }       

        private List<Position> getPosicionesVacias(List<Position> posiciones)
        {
            var posicionesVacias = new List<Position>();
            posiciones.ForEach(pos =>
            {
                Ser? ser = parcela.posiciones[pos];
                if (ser == null)
                {
                    posicionesVacias.Add(pos);
                    //Console.WriteLine(pos);
                }

            });
            return posicionesVacias;
        }

        internal void startSafari()
        {
            fillParcela();
            setNumeroPlantas();
            setNumeroGacelas();
            setNumeroLeones();
            setNumeroSeres();
        }
    }
}
