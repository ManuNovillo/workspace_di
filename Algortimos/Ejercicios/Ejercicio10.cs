using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio10 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio Extra");
            Console.WriteLine("Introduce un número");
            int num = LeerDato.LeerEntero();
            if (num < 0)
            {
                Console.WriteLine("Dato introducido no válido");
            }
            else
            {
                Console.WriteLine(EsPerfecto(num) ? "Es perfecto" : "No es perfecto");
            }
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /// <summary>
        /// Devuelve true si <c><paramref name="num"/></c> es perfecto, false si no.
        /// </summary>
        /// <param name="num">El numero a evauluar</param>
        /// <returns>true si <c><paramref name="num"/></c> es perfecto, false si no.</returns>
        static bool EsPerfecto(int num)
        {
            // El 0 no es perfecto
            if (num == 0) return false;
            int suma = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                // Si el resto es cero, es divisible, y por tanto sumamos
                if (num % i == 0) suma += i;
            }
            // Devolver true si la suma es igual al número
            return suma == num;
        }
    }
}
