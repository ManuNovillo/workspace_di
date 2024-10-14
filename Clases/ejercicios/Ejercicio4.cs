using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio4 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Ejercicio 4");
            int[][] matriz = {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6},
                new int[] {7, 8, 9, 10, 11},
                new int[] {11, 12, 13}
            };
            Console.WriteLine("Introduce la fila de la esquina superior izquierda");
            String filaString = Console.ReadLine();
            Console.WriteLine("Introduce la columna de la esquina superior izquierda");
            String columnaString = Console.ReadLine();
            int fila, columna;
            //Intentar convertir a número, si se puede ejecutar método, si no, imprimir que hay un error 
            if (int.TryParse(filaString, out fila) && int.TryParse(columnaString, out columna))
            {
                int[] submatriz = GetSubMatriz(matriz, fila, columna);
                foreach (int num in submatriz)
                {
                    Console.WriteLine(num);
                }
            }
            else Console.WriteLine("Revisa los datos introducidos");

        }
        /// <summary>
        /// Devuelve un array unidimensional con los datos de la submatriz más grande cuya esquina superior izquierda viene 
        /// especificada por <c><paramref name="a"/></c> y <c><paramref name="b"/></c>.
        /// La matriz devuelta puede ser cuadrada o rectangular
        /// </summary>
        /// <param name="matriz">La matriz de la que se quiere sacar una submatriz</param>
        /// <param name="a">Primera coordenada de la submatriz, es decir, primera posición de <c><paramref name="matriz"/></c></param>
        /// <param name="b">Segunda coordenada de la submatriz, es decir, Segunda posición de <c><paramref name="matriz"/></c></param>
        /// <returns>Un array unidimensional con los contenidos de la submatriz</returns>
        static int[] GetSubMatriz(int[][] matriz, int a, int b)
        {
            //Crear una lista para guardar los números en ella, pues no se sabe cuántos habrá que guardar
            List<int> list = new List<int>();
            //Recorrer la matriz a partir de las coordenadas aportadas
            for (int i = a; i < matriz.Length; i++)
            {
                for (int j = b; j < matriz[i].Length; j++)
                {
                    list.Add(matriz[i][j]);
                }
            }
            return list.ToArray();
        }
    }
}
