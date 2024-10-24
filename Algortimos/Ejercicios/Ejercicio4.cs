using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio4 : Ejercicio
    {

        public Ejercicio4()
        {

        }

        /*
         * Método que realiza la opción 4 del menú,
         * sacar un array con una submatriz de una matriz.
         * No recibe ni devuelve ningún valor.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a sacar una Submatriz de una Matriz");
            int filas, colum; // Número de filas y columnas de la matriz
            int x, y; // Posición inicial de la submatriz
            // Pido al usuario el tamaño de la matriz
            Console.Write("\n\nDime el número de filas que quieres en la Matriz de origen: ");
            filas = LeerDato.LeerEntero();
            Console.Write("Dime el número de columnas que quieres en la Matriz de origen: ");
            colum = LeerDato.LeerEntero();
            int[,] matOrin = new int[filas, colum];
            int valor = 0;
            // Recorro la matriz y la inicializo con valores por defecto
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    matOrin[i, j] = valor;
                    valor++;
                }
            }

            // Muestro la matriz con sus valores iniciales.
            mostrarMatriz(matOrin);

            // Pido la posición de la submatriz al usuario
            Console.Write("\n\nDame la posición x de la submatriz: ");
            x = LeerDato.LeerEntero();
            Console.Write("Dame la posición y de la submatriz: ");
            y = LeerDato.LeerEntero();

  

            // Después muestro el array llamando a un método para ello.
            Console.WriteLine("\n\nAhora puedes ver el Array resultante: ");
            mostrarArray(GetSubMatriz(matOrin, x ,y));
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /*
         * Método que recibe un array de 2 dimensiones, lo recorre y muestra sus valores.
         * No devuelve ningún valor.
         */
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

        /*
         * Método que recibe un array unidimensional, lo recorre y muestra sus valores.
         * No devuelve ningún valor.
         */
        private void mostrarArray(int[] array)
        {
            Console.Write("\n\nEl Array es:\n[ ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("]\n");
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
        static int[] GetSubMatriz(int[,] matriz, int a, int b)
        {
            //Crear una lista para guardar los números en ella, pues no se sabe cuántos habrá que guardar
            List<int> list = new List<int>();
            //Recorrer la matriz a partir de las coordenadas aportadas
            for (int i = a; i < matriz.GetLength(0); i++)
            {
                for (int j = b; j < matriz.GetLength(1); j++)
                {
                    list.Add(matriz[i, j]);
                }
            }
            return list.ToArray();
        }
    }


}
