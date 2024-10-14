using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal class Ejercicio2 : Ejercicio
    {
        public override void ejecutar()
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
    }
}
