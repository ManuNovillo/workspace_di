using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
        internal class Ejercicio10 : Ejercicio
        {
            public override void ejecutar()
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
                int suma = 0;
                for (int i = 1; i <= num / 2; i++)
                {
                    //Si el resto es cero, es divisible, y por tanto sumamos
                    if (num % i == 0) suma += i;
                }
                return suma == num;
            }
        }
}
