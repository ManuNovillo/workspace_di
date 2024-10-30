using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio9 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 9");
            Console.Write("\n\nDime el número de filas que quieres en la Matriz de origen: ");
            int filas = LeerDato.LeerEntero();
            Console.Write("Dime el número de columnas que quieres en la Matriz de origen: ");
            int colum = LeerDato.LeerEntero();
            int[,] matriz = new int[filas, colum];
            int valor = 0;
            // Recorro la matriz y la inicializo con valores por defecto
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    matriz[i, j] = valor;
                    valor++;
                }
            }

            // Muestro la matriz con sus valores iniciales.
            mostrarMatriz(matriz);
            Console.WriteLine("Introduce cuánto te quieres mover en el eje x");
            int movePrimeraDim = LeerDato.LeerEntero();
            Console.WriteLine("Introduce cuánto te quieres mover en el eje y");
            int moveSegundaDim = LeerDato.LeerEntero();
            int[,] toroide = Toroide(matriz, movePrimeraDim, moveSegundaDim);
            mostrarMatriz(toroide);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();

        }
        /// <summary>
        /// Desplaza cada elemento de <c><paramref name="matriz"/></c> veces en el eje vertical y 
        /// <c><paramref name="moveSegundaDim"/></c> en el eje horizontal
        /// </summary>
        /// <param name="matriz">La matriz que se quiere modificar</param>
        /// <param name="movePrimeraDim">El movimiento vertical. Positivo es hacia abajo, negativo es hacia arriba</param>
        /// <param name="moveSegundaDim">El movimiento horizontal. Positivo es hacia la derecha, negativo es hacia la izquierda</param>
        /// <returns>La matriz desplazada</returns>
        int[,] Toroide(int[,] matriz, int movePrimeraDim, int moveSegundaDim)
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

        private void mostrarMatriz(int[,] matriz)
        {
            Console.WriteLine("\n\nLa matriz es:\n[");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(" " + matriz[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("]\n");
        }
    }
}

