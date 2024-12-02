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

        private bool simulacionTerminada;

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

        public bool SimulacionTerminada { get => simulacionTerminada; }

        public MiSafari()
        {
            parcela = new Parcela();
            simulacionTerminada = false;
        }

        public void startSafari()
        {
            parcela.fillParcela();
            setNumerosDelSafari();
        }

        private void setNumerosDelSafari()
        {
            setNumeroPlantas();
            setNumeroGacelas();
            setNumeroLeones();
            setNumeroSeres();
        }

        private void setNumeroPlantas()
        {
            setNumero(typeof(Planta), out numeroPlantas);
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
            foreach (var ser in parcela.Posiciones.Values)
            {
                if (ser?.GetType() == type) num++;
            }
            numOut = num;
        }

        public void setDimensiones(int filas, int columnas)
        {
            parcela.Filas = filas;
            parcela.Columnas = columnas;
        }

        public Dictionary<Posicion, Ser?> getSeres()
        {
            return parcela.Posiciones;
        }

        public int getFilasMaximas()
        {
            return Parcela.FilasMaximas;
        }

        public int getColumnasMaximas()
        {
            return Parcela.ColumnasMaximas;
        }

        public int getFilasMinimas()
        {
            return Parcela.FilasMinimas;
        }

        public int getColumnasMinimas()
        {
            return Parcela.ColumnasMinimas;
        }

        public void step()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($"PASO {pasos}");
            var keys = parcela.Posiciones.Keys.ToList();
            var seresRecorridos = new List<Ser>();
            foreach (var posicionActual in keys)
            {
                var ser = parcela.Posiciones[posicionActual];
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
                    Posicion? posicionHijo = reproducir(ser, posicionesVacias);
                    // Eliminar posición del hijo de la lista para que el ser, en caso de poder moverse, no se ponga encima del hijo
                    if (posicionHijo != null)
                    {
                        Console.WriteLine("SE HA REPRODUCIDO");
                        posicionesVacias.Remove(posicionHijo);
                        seHaReproducido = true;
                        Ser hijo = parcela.Posiciones[posicionHijo];
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
                        handleAnimal((Animal)ser, posicionActual, posicionesConComida, posicionesVacias);
                    }
                }
                ser.incrementarPasosVividos();
                if (!seHaReproducido) ser.incrementarPasosDesdeUltimaReproduccion();
            }
            pasos++;
            setNumeroSeres();
            if (simulacionDebeTerminar())
            {
                finish();
            }
        }



        private bool simulacionDebeTerminar()
        {
            foreach (var value in parcela.Posiciones.Values)
            {
                // Si aún quedan gacelas o leones, no debe terminar.
                if (value is not null && (
                            value.GetType() == typeof(Gacela) ||
                            value.GetType() == typeof(Leon)
                        )
                    )
                    return false;
            }
            return true;
        }

        private void finish()
        {
            simulacionTerminada = true;
        }

        /// <summary>
        /// Hace todo el comportamiento del animal (comer y moverse)
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="posicionActual"></param>
        /// <param name="posicionesConComida"></param>
        /// <param name="posicionesVacias"></param>
        private void handleAnimal(Animal animal, Posicion posicionActual, List<Posicion> posicionesConComida, List<Posicion> posicionesVacias)
        {
            Posicion? nuevaPosicion = null;
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
        private Posicion? reproducir(Ser ser, List<Posicion> posicionesVacias)
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
            parcela.Posiciones[posicionElegida] = hijo;
            Console.WriteLine($"REPRODUCCION DE {ser.ToString() + ser.num}, GENERANDO A {hijo.ToString() + hijo.num}");
            Console.WriteLine($"POSICION HIJO: {posicionElegida}");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            return posicionElegida;
        }

        private Posicion comer(Posicion posicionActual, List<Posicion> posicionesConComida)
        {
            var random = new Random();
            int numAleatorio = random.Next(posicionesConComida.Count);
            var posicionElegida = posicionesConComida[numAleatorio];
            var animal = (Animal)parcela.Posiciones[posicionActual];
            animal.comer();
            //Console.WriteLine($"SE HA COMIDO A {parcela.posiciones[posicionElegida]} {parcela.posiciones[posicionElegida].num}");
            parcela.Posiciones[posicionElegida] = null;
            Type tipoComida = animal.getTipoComida();
            if (tipoComida == typeof(Gacela))
            {

                numeroGacelas--;
            }
            else if (tipoComida == typeof(Planta))
            {
                numeroPlantas--;
            }
            return posicionElegida;

        }

        private void matarSerEnPosicion(Posicion posicionElegida)
        {
            parcela.Posiciones[posicionElegida] = null;
        }

        private void mover(Posicion origen, Posicion destino)
        {
            Ser ser = parcela.Posiciones[origen];
            matarSerEnPosicion(origen);
            Ser? serEnDestino = parcela.Posiciones[destino];
            parcela.Posiciones[destino] = ser;
            //Console.WriteLine($"DESTINO: {destino}");
            //Console.WriteLine($"SER QUE HABIA EN DESTINO: {serEnDestino?.ToString() + serEnDestino?.num}");
        }

        private List<Posicion> getPosicionesConComida(Type tipoComida, List<Posicion> posiciones)
        {
            var posicionesConComida = new List<Posicion>();
            posiciones.ForEach(pos =>
            {
                Ser? ser = parcela.Posiciones[pos];
                if (ser != null && ser.GetType().Equals(tipoComida)) posicionesConComida.Add(pos);
            });
            return posicionesConComida;
        }

        private List<Posicion> getPosicionesVacias(List<Posicion> posiciones)
        {
            var posicionesVacias = new List<Posicion>();
            posiciones.ForEach(pos =>
            {
                Ser? ser = parcela.Posiciones[pos];
                if (ser == null)
                {
                    posicionesVacias.Add(pos);
                }

            });
            return posicionesVacias;
        }

        public void restart()
        {
            parcela.limpiarParcela();
            parcela.fillParcela();
            setNumerosDelSafari();
        }
    }
}
