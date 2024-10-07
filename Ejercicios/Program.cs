
using System;
using System.Collections.Generic;
using System.Text;

namespace Casa
{
    class Tarea
    {
        static void Main(String[] args)
        {
            Ejercicio10();
        }

        //Ejercicio 1
        static void Ejercicio1()
        {
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Introduce un número para ver si es primo");
            String introducido = Console.ReadLine();
            bool intento = int.TryParse(introducido, out int num);
            if (!intento) Console.WriteLine("No es un número");
            else Console.WriteLine(EsPrimo(num) ? "Es primo" : "No es primo");
        }
        /// <summary>
        /// Determina si un número es primo o no, y devuelve true o false en consecuencia
        /// </summary>
        /// <param name="num">El número a evaluar</param>
        /// <returns>true si es primo, false si no es primo</returns>
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

        static void Ejercicio2()
        {
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Introduce las longitudes del triangulo");
            String lado1s = Console.ReadLine();
            String lado2s = Console.ReadLine();
            String lado3s = Console.ReadLine();
            bool lado1Bien = float.TryParse(lado1s, out float lado1);
            bool lado2Bien = float.TryParse(lado2s, out float lado2);
            bool lado3Bien = float.TryParse(lado3s, out float lado3);
            bool ladosBien = lado1Bien && lado2Bien && lado3Bien;
            if (!ladosBien) Console.WriteLine("Revisa los datos introducidos");
            else Console.WriteLine(TipoTriangulo(lado1, lado2, lado3));
        }

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
            float[] longitudes = { a, b, c };
            Array.Sort(longitudes);
            if (longitudes[2] >= longitudes[0] + longitudes[1]) return "No es un triangulo";
            if (longitudes[2] * longitudes[2] == longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo rectángulo";
            if (longitudes[2] * longitudes[2] > longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo obtusángulo";
            if (longitudes[2] * longitudes[2] < longitudes[0] * longitudes[0] + longitudes[1] * longitudes[1]) return "Es un triángulo acutángulo";
            //Si no se cumple ninguna opción anterior, no es un triángulo
            return "No es un triángulo";
        }

        //Ejercicio 3
        static void Ejercicio3()
        {
            Console.WriteLine("Ejercicio 3");
            Console.WriteLine("Introduce qué número de la serie de Fibonnaci quieres");
            String introducido = Console.ReadLine();
            bool intento = int.TryParse(introducido, out int num);
            if (!intento) Console.WriteLine("No es un número");
            else
            {
                if (num >= 1)
                {
                    Console.WriteLine($"Recursivo:{FibonacciRecursivo(num)}");
                    Console.WriteLine("Serie hasta ese número: ");
                    Fibonacci(num);
                }
                else Console.WriteLine("No puede ser menor que 1");
            }
        }

        /// <summary>
        /// Escribe en consola todos los números de la serie de Fibonacci hasta la posición <c><paramref name="index"/></c>
        /// </summary>
        /// <param name="index"></param>
        static void Fibonacci(int index)
        {
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
        /// Devuelve el número en la posición <c><paramref name="index"/></c> de la serie de Fibonacci
        /// </summary>
        /// <param name="index">El puesto del número que se quiere calcular</param>
        /// <returns>El número en la posición <c><paramref name="index"/></c> de la serie de Fibonacci</returns>
        static int FibonacciRecursivo(int index)
        {
            //Casos base
            if (index == 1 || index == 2) return 1;
            //Caso recursivo
            return FibonacciRecursivo(index - 1) + FibonacciRecursivo(index - 2);
        }

        //Ejercicio 4

        static void Ejercicio4()
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

        //Ejercicio 5
        static void Ejercicio5()
        {
            Console.WriteLine("Ejercicio 5");
            Console.WriteLine("Introduce el texto al que le quieres quitar los espacios");
            String texto = Console.ReadLine();
            Console.WriteLine(EliminarEspacios(texto));
        }
        /// <summary>
        /// Devuelve <c><paramref name="s"/></c> pero sin cualquier caracter de espacio (" ")
        /// </summary>
        /// <param name="s">El String al que se le quieren quitar los espacios</param>
        /// <returns>Un String idéntico a <c>s</c> pero sin espacios</returns>
        static String EliminarEspacios(String s)
        {
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

        //Ejercicio 6
        static void Ejercicio6()
        {
            Console.WriteLine("Ejercicio 6");
            Console.WriteLine("Introduce el número en binario");
            String num = Console.ReadLine();
            int[] numArray = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                numArray[i] = int.Parse(num[i].ToString());
            }
            Console.WriteLine($"Como array: {BinToDec(numArray)}");
            Console.WriteLine($"Como String: {BinToDec(num)}");
        }

        /// <summary>
        /// Convierte el número binario de <c><paramref name="array"/></c> a decimal.
        /// <example>
        /// Por ejemplo, 
        /// <c>BinToDec(new int[1,0])</c>
        /// devolverá <c>2</c>
        /// </example>
        /// </summary>
        /// <param name="array">El número a convertir, cada cifra en una posición del array</param>
        /// <returns>El número convertido a decimal. Si <c><paramref name="array"/></c> está vacío, devuelve 0</returns>
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
                }
            }
            return num;
        }

        /// <summary>
        /// Convierte el número binario de <c><paramref name="numBinario"/></c> a decimal.
        /// <example>
        /// Por ejemplo, 
        /// <c>BinToDec(new int[1,0])</c>
        /// devolverá <c>2</c>
        /// </example>
        /// </summary>
        /// <param name="numBinario">El número a convertir, cada cifra en una posición del array</param>
        /// <returns>El número convertido a decimal. Si <c><paramref name="numBinario"/></c> está vacío, devuelve 0</returns>
        /// <exception cref="ArgumentException">Si <c><paramref name="numBinario"/></c> contiene caracteres que no sean '0' o '1'.</exception>
        static int BinToDec(String numBinario)
        {
            //Variable donde iremos sumando para tener el resultado final
            int num = 0;
            //Recorremos el String de final a principio para que sea como al hacerlo a mano, de derecha a izquierda
            for (int i = numBinario.Length - 1; i >= 0; i--)
            {
                //Si es 1, hay que sumar
                if (numBinario[i] == '1')
                {
                    //array.Length - 1 - i da el resultado al que queremos elevar. 0 para la primera cifra, 1 para la segunda, array.Length - 1 para la primera
                    num += (int)Math.Pow(2, numBinario.Length - 1 - i);

                    //Si no es 1 y tampoco es 0, lanzar ArgumentException
                }
                else if (numBinario[i].Equals("0")) throw new ArgumentException("numBinario solo puede contener 0 y 1");
            }
            return num;
        }
        //Ejercicio 7

        static void Ejercicio7()
        {
            Console.WriteLine("Ejercicio 7");
            Console.WriteLine("Introduce una oracion o palabra");
            String s1 = Console.ReadLine();
            Console.WriteLine("Introduce otra oración o palabra");
            String s2 = Console.ReadLine();
            Console.WriteLine(EsPalindromo(s1, s2) ? "Son palindromos" : "No son palindromos");
        }
        /// <summary>
        /// Devuelve true si <c><paramref name="s1"/></c> y <c><paramref name="s2"/></c> son palíndromos, false si no.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>true si <c><paramref name="s1"/></c> y <c><paramref name="s2"/></c> son palíndromos, false si no.</returns>
        static bool EsPalindromo(String s1, String s2)
        {
            return Reverse(s1).Equals(s2);
        }
        /// <summary>
        /// Da la vuelta a <c><paramref name="s"/></c> de manera recursiva
        /// </summary>
        /// <param name="s"></param>
        /// <returns>El String dado la vuelta</returns>
        static String Reverse(String s)
        {
            if (s.Length == 0 || s.Length == 1) return s;
            char primero = s[0];
            char ultimo = s[s.Length - 1];
            return ultimo + Reverse(s.Substring(1, s.Length - 2)) + primero;
        }

        //Ejercicio 8
        static void Ejercicio8()
        {
            Console.WriteLine("Ejercicio 8");
            Console.WriteLine("Introduce el precio del bote");
            String precioString = Console.ReadLine();
            Console.WriteLine("Introduce la cantidad que vas a pagar");
            String introducidoString = Console.ReadLine();
            float precio, introducido;
            //Intentar convertir a número, si se puede ejecutar método, si no, imprimir que hay un error 
            if (float.TryParse(precioString, out precio) && float.TryParse(introducidoString, out introducido))
            {
                GetCambio(precio, introducido);
            }
            else Console.WriteLine("Revisa los datos introducidos");
        }
        /// <summary>
        /// Imprime en consola la cantidad de monedas de cada tipo a dar para el resto, o "Error" si <c><paramref name="cantidad"/></c> < <c><paramref name="precio"/></c>
        /// </summary>
        /// <param name="precio">Precio de la lata, en euros</param>
        /// <param name="cantidad">Cantidad introducida, en euros</param>
        static void GetCambio(float precio, float cantidad)
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
        static void Ejercicio9()
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

        //Ejercicio 10
        static void Ejercicio10()
        {
            switch (Menu())
            {
                case 1:
                    Ejercicio1();
                    break;
                case 2:
                    Ejercicio2();
                    break;
                case 3:
                    Ejercicio3();
                    break;
                case 4:
                    Ejercicio4();
                    break;
                case 5:
                    Ejercicio5();
                    break;
                case 6:
                    Ejercicio6();
                    break;
                case 7:
                    Ejercicio7();
                    break;
                case 8:
                    Ejercicio8();
                    break;
                case 9:
                    Ejercicio9();
                    break;
                case 10:
                    EjercicioExtra();
                    break;
                default:
                    Console.WriteLine("No es un número válido");
                    break;
            }
        }
        /// <summary>
        /// Pide por consola qué ejercicio se quiere hacer, y devuelve el índice del ejercicio, o -1 si no se ha introducido un número
        /// </summary>
        /// <returns>El índice del ejercicio, o -1 si no se ha introducido un número</returns>
        static int Menu()
        {
            Console.WriteLine("Elige un ejercicio:\n" +
                              "1. Numero primo\n" +
                              "2. Triangulo\n" +
                              "3. Fibonacci\n" +
                              "4. Submatriz\n" +
                              "5. Quitar espacios\n" +
                              "6. Binario a decimal\n" +
                              "7. Palindromo\n" +
                              "8. Cambio\n" +
                              "9. Toroide\n" +
                              "10. Numero perfecto"
                              );
            String seleccion = Console.ReadLine();
            bool intento = int.TryParse(seleccion, out int num);
            return intento ? num : -1;
        }

        static void EjercicioExtra()
        {
            Console.WriteLine("Ejercicio Extra");
            Console.WriteLine("Introduce un número");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(EsPerfecto(num) ? "Es perfecto" : "No es perfecto");
        }

        /// <summary>
        /// Devuelve true si <c><paramref name="num"/></c> es perfecto, false si no.
        /// </summary>
        /// <param name="num">El numero a evauluar</param>
        /// <returns>true si <c><paramref name="num"/></c> es perfecto, false si no.</returns>
        static bool EsPerfecto(int num)
        {
            //Lista donde ir guardando los divisores
            List<int> list = new List<int>();
            for (int i = 1; i <= num / 2; i++)
            {
                //Si el resto es cero, es divisible, y por tanto lo añadimos a la lista
                if (num % i == 0) list.Add(i);
            }
            //Sumar los divisores
            int suma = 0;
            foreach (int i in list)
            {
                suma += i;
            }
            return suma == num;
        }
    }
}