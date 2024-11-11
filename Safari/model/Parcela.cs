using System;
using Safari.model.seres;

namespace Safari.model
{
    internal class Parcela
    {
        private Ser[,] parcela;
        internal Parcela(int filas, int columnas) { 
            parcela = new Ser[filas, columnas];
        }

        internal void fillParcela()
        {
            // Variable con la que determinar aleatoriamente qué ser poner en cada posición
            Random random = new Random();
            for (int i = 0; i < parcela.GetLength(0); i++)
            {
                for(int j = 0; j < parcela.GetLength(1); j++)
                {
                    long num = random.NextInt64(0, 4);
                    Ser ser;
                    switch (num)
                    {
                        case 0:
                            ser = new Gacela();
                    }
                }
            }
        }
    }
}
