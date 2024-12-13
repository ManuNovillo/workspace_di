using Safari.model.position;
using Safari.model.seres;

namespace Safari.model
{
    public class MiSafari
    {
        private Parcela parcela;

        private int numeroPlantas;

        private int numeroGacelas;

        private int numeroLeones;

        private int numeroSeres;

        private int numeroPasos;

        private bool simulacionTerminada;

        public int NumeroPlantas { get => numeroPlantas; }

        public int NumeroGacelas { get => numeroGacelas; }

        public int NumeroLeones { get => numeroLeones; }

        public int NumeroSeres { get => numeroSeres; }

        public int NumeroPasos { get => numeroPasos; }

        public bool SimulacionTerminada { get => simulacionTerminada; }

        public MiSafari()
        {
            parcela = new Parcela();
            simulacionTerminada = false;
        }

        public void startSafari()
        {
            parcela.fillParcela();
            setNumerosInicialesDelSafari();
        }

        private void setNumerosInicialesDelSafari()
        {
            setNumeroGacelas();
            setNumeroPlantas();
            setNumeroLeones();
            updateNumeroSeres();
            numeroPasos = 0;
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

        private void updateNumeroSeres()
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

        public List<String> getSeres()
        {
            List<String> seresTexto = new List<String>();
            foreach (var entry in parcela.Posiciones)
            {
                var ser = entry.Value;
                var tipoSer = entry.Value is null ? "Vacio" : entry.Value.ToString();
                var fila = entry.Key.fila;
                var columna = entry.Key.columna;
                seresTexto.Add($"{tipoSer} {fila} {columna}");
            }
            return seresTexto;
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
            var keys = parcela.Posiciones.Keys.ToList();
            var seresRecorridos = new List<Ser>();
            foreach (var posicionActual in keys)
            {
                var ser = parcela.Posiciones[posicionActual];
                if (ser == null) continue; // Si es vacío, pasar al siguiente
                if (seresRecorridos.Contains(ser)) continue; // Si el ser ya se ha recorrido, pasar al siguiente
                seresRecorridos.Add(ser);
                var posicionesAlrededor = parcela.getSurroundingPositions(posicionActual);
                var posicionesVacias = getPosicionesVacias(posicionesAlrededor);
                var seHaReproducido = false;

                if (ser is Animal)
                {
                    Animal animal = (Animal)ser;
                    if (animal.debeMorirDeInanicion())
                    {
                        matarSerEnPosicion(posicionActual);
                        if (animal.GetType() == typeof(Gacela))
                        {
                            numeroGacelas--;
                        }
                        else if (animal.GetType() == typeof(Leon))
                        {
                            numeroLeones--;
                        }
                        continue;
                    }
                }

                // Comprobar si se debe reproducir
                if (ser.debeReproducirse() && posicionesVacias.Count != 0)
                {
                    Posicion? posicionHijo = reproducir(ser, posicionesVacias);

                    if (posicionHijo != null)
                    {
                        posicionesVacias.Remove(posicionHijo);  // Eliminar posición del hijo de la lista para que el ser, en caso de poder moverse,
                                                                // no se ponga encima del hijo
                        seHaReproducido = true;
                        Ser hijo = parcela.Posiciones[posicionHijo];
                        seresRecorridos.Add(hijo); // Evitar que el hijo haga algo en este turno

                    }
                }


                if (ser is Animal)
                {
                    Animal animal = (Animal) ser;
                    var posicionesConComida = getPosicionesConComida(animal.getTipoComida(), posicionesAlrededor);
                    handleAnimal(animal, posicionActual, posicionesConComida, posicionesVacias);
                }
                ser.incrementarPasosVividos();
                if (!seHaReproducido) ser.incrementarPasosDesdeUltimaReproduccion();
            }
            numeroPasos++;
            updateNumeroSeres();
            if (simulacionDebeTerminar())
            {
                terminarSimulacion();
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

        private void terminarSimulacion()
        {
            simulacionTerminada = true;
        }

        /// <summary>
        /// Hace todo el comportamiento especial del animal (comer y moverse)
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

            if (!haComido) animal.incrementarPasosSinComer();
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
            if (posicionesVacias.Count == 0) return null;
            var random = new Random();
            var numAleatorio = random.Next(posicionesVacias.Count);
            var posicionElegida = posicionesVacias[numAleatorio];
            Ser? hijo = null;
            if (ser is Planta)
            {
                hijo = new Planta();
                numeroPlantas++;
            }
            else if (ser is Leon)
            {
                hijo = new Leon();
                numeroLeones++;
            }
            else if (ser is Gacela)
            {
                hijo = new Gacela();
                numeroGacelas++;
            }
            ser.reproducirse();
            parcela.Posiciones[posicionElegida] = hijo;
            return posicionElegida;
        }

        private Posicion comer(Posicion posicionActual, List<Posicion> posicionesConComida)
        {
            var random = new Random();
            int numAleatorio = random.Next(posicionesConComida.Count);
            var posicionElegida = posicionesConComida[numAleatorio];
            var animal = (Animal)parcela.Posiciones[posicionActual];
            animal.comer();
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

        /// <summary>
        /// Dada una lista de posiciones, devuelve otra lista con aquellas posiciones que estén vacías
        /// (que en el diccionario de posiciones, el valor sea null)
        /// </summary>
        /// <param name="posiciones"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Reinicia el safari
        /// </summary>
        public void restart()
        {
            parcela.limpiarParcela();
            parcela.fillParcela();
            simulacionTerminada = false;
            setNumerosInicialesDelSafari();
        }
    }
}
