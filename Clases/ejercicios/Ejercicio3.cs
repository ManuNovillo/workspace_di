using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio3 : Ejercicio
    {
        public override void ejecutar()
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
    }
}
