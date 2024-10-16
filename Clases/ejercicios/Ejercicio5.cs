using System;
using System.Text;

namespace Clases.ejercicios
{
    internal class Ejercicio5 : Ejercicio
    {
        public override void ejecutar()
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
    }
}
