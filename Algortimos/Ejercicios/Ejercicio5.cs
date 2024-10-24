using System;
using System.Text;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio5 : Ejercicio
    {

        public Ejercicio5()
        {

        }

        /*
         * Método que realiza las funciones para la opción 5 del menú.
         * No reibe ni devuelve ningún parámetro.
         */
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("\nVamos a quitar los espacios en blanco de una cadena");
            // Solicito la cadena completa al usuario
            Console.Write("\n\nDame la frase de origen: ");
            string cadenaOrigen = Console.ReadLine();
            // Variable que almacena el resultado, la cadena sin espacios
            string cadenaFinal = EliminarEspacios(cadenaOrigen);
            // Muestro la cadena resultante sin espacios.
            Console.WriteLine("\n\nLa cadena resultante es:" + cadenaFinal);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /// <summary>
        /// Devuelve <c><paramref name="s"/></c> pero sin cualquier caracter de espacio (" ")
        /// </summary>
        /// <param name="s">El String al que se le quieren quitar los espacios</param>
        /// <returns>Un String idéntico a <c>s</c> pero sin espacios</returns>
        String EliminarEspacios(String s)
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
    }
}
