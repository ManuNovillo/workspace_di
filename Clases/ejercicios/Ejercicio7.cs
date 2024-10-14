using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio7 : Ejercicio
    {
        public override void ejecutar()
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
    }
}
