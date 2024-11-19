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
            foreach (var entry in parcela.posiciones)
            {
                var posicionInicio = entry.Key;
                var ser = entry.Value;
                var posicionesAlrededor = parcela.getSurroundingPositions(posicionInicio);
                Console.WriteLine($"ORIGINAL: {posicionInicio}");
                posicionesAlrededor.ForEach(pos =>
                {
                    Console.WriteLine($"{pos} en el este");
                });
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
                        mover(posicionInicio, posicionElegida);
                    }
                    else if (posicionesVacias.Count != 0)
                    {
                        int numAleatorio = random.Next(posicionesVacias.Count);
                        var posicionElegida = posicionesVacias[numAleatorio];
                        mover(posicionInicio, posicionElegida);
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
            Ser ser = parcela.posiciones[origen];
            eliminarSerEnPosicion(origen);
            parcela.posiciones[destino] = ser;
        }

        private List<Position> getPosicionesConComida(Type tipoComida, List<Position> posiciones)
        {
            var posicionesConComida = new List<Position>();
            posiciones.ForEach (pos => {
                Console.WriteLine(pos);
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
