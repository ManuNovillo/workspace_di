using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio1 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Introduce un número para ver si es primo");
            int num = LeerDato.LeerEntero();
            // Si es menor que 0, mostrar mensaje de error
            if (num < 0)
            {
                Console.WriteLine("No se puede saber si es número primo o no porque es incorrecto");
            }
            // Si no, mostrar si es primo o no
            else Console.WriteLine(EsPrimo(num) ? "Es primo" : "No es primo");
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /// <summary>
        /// Determina si un número es primo o no, y devuelve true o false en consecuencia
        /// </summary>
        /// <param name="num">El número a evaluar</param>
        /// <returns>true si es primo, false si no es primo</returns>
        bool EsPrimo(int num)
        {
            //Casos especiales

            //El 1 y el 0 no son primos
            if (num == 1 || num == 0) return false;
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
