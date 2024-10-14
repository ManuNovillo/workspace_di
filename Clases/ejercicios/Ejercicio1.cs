using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio1 : Ejercicio
    {
        public override void ejecutar()
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
    }
}
