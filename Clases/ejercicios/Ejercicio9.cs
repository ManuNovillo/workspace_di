using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio9 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Ejercicio 9");
            int[,] matriz = {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12}
            };
            Console.WriteLine("Introduce cuánto te quieres mover en la primera dimensión");
            String movPrimDimString = Console.ReadLine();
            Console.WriteLine("Introduce cuánto te quieres mover en la segunda dimensión");
            String movSegDimString = Console.ReadLine();

            int movePrimDim, moveSegDim;
            //Intentar convertir a número, si se puede ejecutar método, si no, imprimir que hay un error 
            if (int.TryParse(movPrimDimString, out movePrimDim) && int.TryParse(movSegDimString, out moveSegDim))
            {
                int[,] toroide = Toroide(matriz, movePrimDim, moveSegDim);
                for (int i = 0; i < toroide.GetLength(0); i++)
                {
                    for (int j = 0; j < toroide.GetLength(1); j++)
                    {
                        Console.Write($"{toroide[i, j]}, ");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Revisa los datos introducidos");


        }
        /// <summary>
        /// Desplaza cada elemento de <c><paramref name="matriz"/></c> veces en el eje vertical y 
        /// <c><paramref name="moveSegundaDim"/></c> en el eje horizontal
        /// </summary>
        /// <param name="matriz">La matriz que se quiere modificar</param>
        /// <param name="movePrimeraDim">El movimiento vertical. Positivo es hacia abajo, negativo es hacia arriba</param>
        /// <param name="moveSegundaDim">El movimiento horizontal. Positivo es hacia la derecha, negativo es hacia la izquierda</param>
        /// <returns>La matriz desplazada</returns>
        static int[,] Toroide(int[,] matriz, int movePrimeraDim, int moveSegundaDim)
        {
            //Crear una nueva matriz para devolver
            int[,] toroide = new int[matriz.GetLength(0), matriz.GetLength(1)];

            //Recorrer la matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    //Calcular las nuevas posiciones
                    int newI = getNuevaCoord(matriz, movePrimeraDim, 0, i);
                    int newJ = getNuevaCoord(matriz, moveSegundaDim, 1, j);

                    //Guardar en la nueva matriz el dato en la nueva posición
                    toroide[newI, newJ] = matriz[i, j];
                }
            }
            return toroide;
        }

        /// <summary>
        /// Devuelve la nueva fila o columna de una posición de <c><paramref name="matriz"/></c> dado el número de movimientos, 
        /// el eje (vertical u horizontal), y la posición original en ese eje
        /// </summary>
        /// <param name="matriz">La matriz de donde se leerá y se calculará la nueva posición</param>
        /// <param name="movimientos">Cuántos movimientos se quieren realizar. Si son positivos, son hacia la derecha o hacia abajo.
        /// Si son negativos, son hacia arriba o hacia la izquierda</param>
        /// <param name="eje">0 para vertical, 1 para horizontal</param>
        /// <param name="posOriginal">La posición donde se encuentra originalmente en ese eje</param>
        /// <returns>La nueva coordenada en ese eje</returns>
        private static int getNuevaCoord(int[,] matriz, int movimientos, int eje, int posOriginal)
        {
            //Determinar si está yendo en el sentido positivo o el negativo
            bool positivo = movimientos > 0;

            //Variable donde se guardan los movimientos que quedan por realizar. Al principio quedan todos por realizar
            int movimientosRestantes = movimientos;

            //Posición en la que se va a acabar. Por defecto, iniciamos en el extremo hacia el que nos dirijimos
            int pos = positivo ? 0 : matriz.GetLength(eje) - 1;

            //Guardamos donde hemos empezado, ya que pos irá cambiando
            int inicio = pos;

            //Como nos hemos desplazado antes en sentido contrario, tendremos que movernos aún más en el sentido que se pretende
            movimientosRestantes += posOriginal - inicio;

            //Mientras el número de movimientos sea mayor (en valor absoluto) que lo que realmente nos podemos mover sin dar la vuelta
            while (Math.Abs(movimientosRestantes) > matriz.GetLength(eje) - 1)
            {
                //Restar la longitud del eje para que sea como dar una vuelta
                movimientosRestantes += positivo ? -matriz.GetLength(eje) : matriz.GetLength(eje);
            }

            //A pos hay que sumarle los movimientos restantes para llegar a la posición final
            pos += movimientosRestantes;

            return pos;
        }
    }
}
