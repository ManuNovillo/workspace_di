using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio6 : Ejercicio
    {
        public override void ejecutar()
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
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
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
        int BinToDec(String numBinario)
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
    }
}
