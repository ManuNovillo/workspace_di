using Safari.model.position;
using Safari.model.seres;
using System;

namespace Safari.model
{
    public class MiSafari
    {
        private Parcela parcela { get; set; }
        
        public MiSafari() 
        {
            parcela = new Parcela();
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
            foreach (var key in keys)
            {
                Console.WriteLine(key);
                var ser = parcela.posiciones[key];
                if (ser == null) continue;
                if (seresRecorridos.Contains(ser)) continue;
                seresRecorridos.Add(ser);
                var posicionesAlrededor = parcela.getSurroundingPositions(key);
                var posicionesVacias = getPosicionesVacias(posicionesAlrededor);
                var posicionesConComida = new List<Position>();
                var random = new Random();
                if (ser is Animal)
                {
                    Animal animal = (Animal) ser;
                    posicionesConComida.AddRange(getPosicionesConComida(animal.getTipoComida(), posicionesAlrededor));
                    if (posicionesConComida.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesConComida.Count);
                        var posicionElegida = posicionesConComida[numAleatorio];
                        mover(key, posicionElegida);
                    }
                    else if (posicionesVacias.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesVacias.Count);
                        var posicionElegida = posicionesVacias[numAleatorio];
                        mover(key, posicionElegida);
                    }
                }
            }
        }

        private void eliminarSerEnPosicion(Position posicionElegida)
        {
            parcela.posiciones[posicionElegida] = null;
        }

        private void mover(Position origen, Position destino)
        {
            Console.WriteLine($"ORIGEN: {origen}");
            Ser ser = parcela.posiciones[origen];
            eliminarSerEnPosicion(origen);
            parcela.posiciones[destino] = ser;
            Console.WriteLine($"DESTINO: {destino}");
            Console.WriteLine($"SER: {ser?.ToString() + ser?.num}");
        }

        private List<Position> getPosicionesConComida(Type tipoComida, List<Position> posiciones)
        {
            var posicionesConComida = new List<Position>();
            posiciones.ForEach (pos => {
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
                Ser? ser;
                parcela.posiciones.TryGetValue(pos, out ser);
                if (ser == null) posicionesVacias.Add(pos);
               
            });
            return posicionesVacias;
        }
    }
}
