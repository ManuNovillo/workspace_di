
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Casa
{
    class Tarea
    {
        static void Main(String[] args)
        {
            int[,] ints = {
                {1, 2, 3, 4, },
                {5, 6, 7, 8, },
                {9, 10, 11, 12,}
            };
            int[,] toroide = Toroide(ints, -7, 2);
            for (int i = 0; i < toroide.GetLength(0); i++)
            {
                for (int j = 0; j < toroide.GetLength(1); j++)
                {
                    Console.Write($"{toroide[i, j]}, ");
                }
                Console.WriteLine();
            }
        }

        //Ejercicio 1

        /// <summary>
        /// Determina si un número es primo o no, y devuelve true o false en consecuencia
        /// </summary>
        /// <param name="num">El número a evaluar</param>
        /// <returns>true si es primo, false si no es primo</returns>
        /// <exception cref="ArgumentException">Si hay lados negativos</exception>
        static bool EsPrimo(int num)
        {
            //Casos especiales

            //El 1 no es primo
            if (num == 1) return false;
            //El 2 es el primer número primo
            if (num == 2) return true;

            //Un número n solo puede ser divisible por otro número x tal que x <= n/2
            //Empezamos en 2 porque todo número es divisible entre 1
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0) return false;
            }
            //Si finaliza el bucle, es que no era divisible entre ningún número, por lo que es primo
            return true;
        }

        //Ejercicio 2

        /// <summary>
        /// Devuelve un String con el tipo de triángulo correspondiente dados sus lados (en cualquier orden), 
        /// o "No es un triángulo" si no es posible formar un triángulo con esas longitudes.
        /// </summary>
        /// <param name="a">El primer lado</param>
        /// <param name="b">El segundo lado</param>
        /// <param name="c">El tercer lado</param>
        /// <returns>Un String de la forma "Es un triángulo " + el tipo, por ejemplo: "Es un triángulo rectángulo",
        /// o "No es un triángulo" si no es posible formar un triángulo con esas longitudes.
        /// </returns>
        /// <exception cref="ArgumentException">Si hay lados negativos</exception>
        static String TipoTriangulo(float a, float b, float c)
        {
            //Ordenar por longitudes para poder comparar el lado más largo con los otros dos más cortos
            if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentException("Los lados no pueden ser menores o iguales a 0");
            float[] longitudes = { a, b, c };
            Array.Sort(longitudes);
            if (longitudes[2] * longitudes[2] == longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo rectángulo";
            if (longitudes[2] * longitudes[2] > longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo obtusángulo";
            if (longitudes[2] * longitudes[2] < longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo acutángulo";
            //Si no se cumple ninguna opción anterior, no es un triángulo
            return "No es un triángulo";
        }

        //Ejercicio 3

        /// <summary>
        /// Escribe en consola todos los números de la serie de Fibonacci hasta la posición <c>index</c>
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentException"></exception>
        static void Fibonacci(int index)
        {
            if (index < 1) throw new ArgumentException("index no puede ser menor que 1");
            int a = 1;
            int b = 1;
            int c = 1;
            Console.WriteLine(c);
            for (int i = 0; i < index - 2; i++)
            {
                //Escribir en consola y realizar el algoritmo
                Console.WriteLine(c);
                c = a + b;
                a = b;
                b = c;
            }
            //Para evitar que escriba 1 dos veces si index es 1
            if (index != 1) Console.WriteLine(c);
        }

        /// <summary>
        /// Devuelve el número en la posición <c>index</c> de la serie de Fibonacci
        /// </summary>
        /// <param name="index">El puesto del número que se quiere calcular</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static int FibonacciRecursivo(int index)
        {
            if (index < 1) throw new ArgumentException("index no puede ser menor que 1");
            //Casos base
            if (index == 1 || index == 2) return 1;
            //Caso recursivo
            return FibonacciRecursivo(index - 1) + FibonacciRecursivo(index - 2);
        }

        //Ejercicio 4

        /// <summary>
        /// Devuelve un array unidimensional con los datos de la submatriz más grande cuya esquina superior izquierda viene especificada por <c>a/c> y <c>b</c>.
        /// La matriz devuelta puede no ser cuadrada, esto dependerá de <c>matriz</c>
        /// </summary>
        /// <param name="matriz">La matriz de la que se quiere sacar una submatriz</param>
        /// <param name="a">Primera coordenada de la submatriz, es decir, primera posición de <c>matriz</c></param>
        /// <param name="b">Segunda coordenada de la submatriz, es decir, Segunda posición de <c>matriz</c></param>
        /// <returns></returns>
        static int[] GetSubMatriz(int[,] matriz, int a, int b)
        {
            if (matriz is null) throw new ArgumentNullException("matriz no puede ser nulo");
            //Crear una lista para guardar los números en ella, pues no se sabe cuántos habrá que guardar
            List<int> list = new List<int>();
            //Recorrer la matriz a partir de las coordenadas aportadas
            for (int i = a; i < matriz.Length; i++)
            {
                for (int j = b; j < matriz.GetLength(1); j++)
                {
                    list.Add(matriz[i, j]);
                }
            }
            return list.ToArray();
        }

        //Ejercicio 5

        /// <summary>
        /// Devuelve <c>s</c> pero sin cualquier caracter de espacio
        /// </summary>
        /// <param name="s">El String al que se le quieren quitar los espacios</param>
        /// <returns>Un String idéntico a <c>s</c> pero sin espacios</returns>
        /// <exception cref="ArgumentNullException">Si <c>s</c> es nulo</exception>
        static String EliminarEspacios(String s)
        {
            if (s is null) throw new ArgumentNullException("s no puede ser nulo");
            //Crear un StringBuilder para ir metiendo los caracteres para luego construir un String
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in s)
            {
                //Si el caracter no es un espacio, añadirlo al StringBuilder
                if (c != ' ') stringBuilder.Append(c);
            }
            //Convertir el StringBuilder a String
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Convierte el número binario de <c>array</c> a decimal.
        /// <example>
        /// Por ejemplo, 
        /// <c>BinToDec(new int[1,0])</c>
        /// devolverá <c>2</c>
        /// </example>
        /// </summary>
        /// <param name="array">El número a convertir, cada cifra en una posición del array</param>
        /// <returns>El número convertido a decimal. Si <c>array</c> está vacío, devuelve 0</returns>
        /// <exception cref="ArgumentException">Si <c>array</c> contiene números que no sean 0 o 1.</exception>
        static int BinToDec(int[] array)
        {
            //Variable donde iremos sumando para tener el resultado final
            int num = 0;
            //Recorremos el array de final a principio para que sea como al hacerlo a mano, de derecha a izquierda
            for (int i = array.Length - 1; i >= 0; i--)
            {
                //Si es 1, hay que sumar
                if (array[i] == 1)
                {
                    //array.Length - 1 - i da el resultado al que queremos elevar. 0 para la primera cifra, 1 para la segunda, array.Length - 1 para la primera
                    num += (int)Math.Pow(2, array.Length - 1 - i);

                    //Si no es 1 y tampoco es 0, lanzar ArgumentException
                }
                else if (array[i] != 0) throw new ArgumentException("array solo puede contener 0 y 1");
            }
            return num;
        }
        //Ejercicio 7

        static bool EsPalindromo(String s1, String s2)
        {
            return Reverse(s1).Equals(s2);
        }
        /// <summary>
        /// Da la vuelta de manera
        /// </summary>
        /// <param name="s1"></param>
        /// <returns></returns>
        static String Reverse(String s1)
        {
            if (s1.Length == 0 || s1.Length == 1) return s1;
            char primero = s1[0];
            char ultimo = s1[s1.Length - 1];
            return ultimo + Reverse(s1.Substring(1, s1.Length - 2)) + primero;
        }

        //Ejercicio 8

        /// <summary>
        /// Imprime en consola la cantidad de monedas de cada tipo a dar para el resto, o "Error" si <c><paramref name="cantidad"/></c> < <c><paramref name="precio"/></c>
        /// </summary>
        /// <param name="precio">Precio de la lata, en euros</param>
        /// <param name="cantidad">Cantidad introducida, en euros</param>
        static void ShowCambio(float precio, float cantidad)
        {
            //Convertir los euros a céntimos para facilitar el trabajo, y calcular el resto
            int resto = (int)(100 * (cantidad - precio));
            //El resto no puede ser menor que 0 porque entonces la cantidad es menor que el precio
            if (resto < 0)
            {
                //Mostrar error
                Console.WriteLine("Error");
            }
            else
            {
                //Calcular cuántas monedas de cada tiene que dar
                int monedas200 = resto / 200;
                resto = resto % 200;
                int monedas100 = resto / 100;
                resto = resto % 100;
                int monedas50 = resto / 50;
                resto = resto % 50;
                int monedas20 = resto / 20;
                resto = resto % 20;
                int monedas10 = resto / 10;
                resto = resto % 10;
                int monedas5 = resto / 5;
                resto = resto % 5;
                int monedas2 = resto / 2;
                resto = resto % 2;
                int monedas1 = resto;

                //Imprimir resultado en consola
                Console.WriteLine($"Monedas de 2€: {monedas200}\n" +
                                  $"Monedas de 1€: {monedas100}\n" +
                                  $"Monedas de 50 cént.: {monedas50}\n" +
                                  $"Monedas de 20 cént.: {monedas20}\n" +
                                  $"Monedas de 10 cént.: {monedas10}\n" +
                                  $"Monedas de 5 cént.: {monedas5}\n" +
                                  $"Monedas de 2 cént.: {monedas2}\n" +
                                  $"Monedas de 1 cént.: {monedas1}");
            }
        }

        //Ejercicio 9

        /// <summary>
        /// Desplaza cada elemento de <c><paramref name="matriz"/></c> veces en el eje vertical y 
        /// <c><paramref name="moveSegundaDim"/></c> en el eje horizontal
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="movePrimeraDim"></param>
        /// <param name="moveSegundaDim"></param>
        /// <returns></returns>
        static int[,] Toroide(int[,] matriz, int movePrimeraDim, int moveSegundaDim)
        {
            int[,] toroide = new int[matriz.GetLength(0), matriz.GetLength(1)];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    
                    int newI = getNuevaCoord(matriz, movePrimeraDim, 0, i);
                    int newJ = getNuevaCoord(matriz, moveSegundaDim, 1, j);
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
        /// <returns></returns>
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