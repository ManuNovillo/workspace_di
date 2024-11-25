using Safari.model.position;
using Safari.model.seres;
using System;
using System.Reflection;
using System.Windows.Forms;

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

        public int NumeroPlantas { get => numeroPlantas; }

        public int NumeroGacelas { get => numeroGacelas; }

        public int NumeroLeones { get => numeroLeones; }

        public int NumeroSeres { get => numeroSeres; }

        public int Pasos { get => pasos; }

        public MiSafari()
        {
            parcela = new Parcela();
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
            foreach (var ser in parcela.posiciones.Values)
            {
                if (ser.GetType() == type) num++;
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
            var keys = parcela.posiciones.Keys.ToList();
            var seresRecorridos = new List<Ser>();
            foreach (var posicionActual in keys)
            {
                var ser = parcela.posiciones[posicionActual];
                if (ser == null) continue;
                if (seresRecorridos.Contains(ser)) continue;
                Console.WriteLine($"SER: {ser.ToString() + ser.num}");
                Console.WriteLine($"POSICION INICIAL: {posicionActual}");
                seresRecorridos.Add(ser);
                var posicionesAlrededor = parcela.getSurroundingPositions(posicionActual);
                var posicionesVacias = getPosicionesVacias(posicionesAlrededor);
                var random = new Random();
                if (ser.debeReproducirse() && posicionesVacias.Count != 0)
                {
                    int numAleatorio = random.Next(posicionesVacias.Count);
                    var posicionElegida = posicionesVacias[numAleatorio];
                    reproducir(ser, posicionElegida);
                   

                }
               
                var posicionesConComida = new List<Position>();
                
                if (ser is Animal)
                {
                    Animal animal = (Animal)ser;
                    Type tipoComida = animal.getTipoComida();
                    posicionesConComida.AddRange(getPosicionesConComida(tipoComida, posicionesAlrededor));
                    var nuevaPosicion = posicionActual;
                    if (posicionesConComida.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesConComida.Count);
                        var posicionElegida = posicionesConComida[numAleatorio];
                        comer(posicionActual, posicionElegida);
                        nuevaPosicion = posicionElegida;

                    }
                    else if (posicionesVacias.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesVacias.Count);
                        var posicionElegida = posicionesVacias[numAleatorio];
                        nuevaPosicion = posicionElegida;
                    }

                    mover(posicionActual, nuevaPosicion);

                    if (animal.debeMorirDeInanicion())
                    {
                        matarSerEnPosicion(nuevaPosicion); //nuevaPosicion porque ya se ha movido (si ha podido)
                    }
                    animal.incrementarDiasSinComer();
                }
            }
        }

        private void reproducir(Ser ser, Position posicionElegida)
        {
            Ser hijo = (Ser)ser.GetType().GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<Type>());
            ser.reproducirse();
            parcela.posiciones[posicionElegida] = hijo;
        }

        private Position comer(Position posicionActual, Position posicionElegida)
        {
            var animal = (Animal)parcela.posiciones[posicionActual];
            animal.comer();
            Console.WriteLine("COMIDA");
            return posicionElegida;
        }

        /*public int getNumeroPlantas()
        {
            return 0;
        }*/

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
            Console.WriteLine($"DESTINO: {destino}");
            Console.WriteLine($"SER QUE HABIA EN DESTINO: {serEnDestino?.ToString() + serEnDestino?.num}");
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
                if (ser == null) posicionesVacias.Add(pos);

            });
            return posicionesVacias;
        }
    }
}
