using Safari.model.position;
using Safari.model.seres;
using System;

namespace Safari.model
{
    public class MiSafari
    {
        private Parcela Parcela { get; set; }
        
        public MiSafari() 
        {
            Parcela = new Parcela();
        }

        public void setDimensiones(int filas, int columnas)
        {
            Parcela.Filas = filas;
            Parcela.Columnas = columnas;
        }

        public void fillParcela()
        {
            Parcela.fillParcela();
        }

        public Dictionary<Position, Ser?> getSeres()
        {
            return Parcela.Posiciones;
        }
    }
}
