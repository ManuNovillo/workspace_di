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

        public void nextDia()
        {
            foreach (var entry in parcela.posiciones)
            {
                var posicion = entry.Key;
                var posicionesDisponibles = parcela.getSurroundingPositions(posicion);
                foreach (var pos in posicionesDisponibles)
                {
                    Ser ser;
                    if (parcela.posiciones.TryGetValue(pos, out ser))
                    {
                       if ()
                    }
                }
            }
        }
    }
}
