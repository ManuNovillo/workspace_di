using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio2 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Introduce las longitudes del triangulo");
            float lado1 = LeerDato.LeerFloat();
            float lado2 = LeerDato.LeerFloat();
            float lado3 = LeerDato.LeerFloat();
            if (LeerDato.getFallo()) Console.WriteLine("Revisa los datos introducidos");
            else Console.WriteLine(TipoTriangulo(lado1, lado2, lado3));
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
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
