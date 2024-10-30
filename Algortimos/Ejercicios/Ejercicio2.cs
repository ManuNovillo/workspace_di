using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio2 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Introduce las longitudes del triangulo");
            float lado1 = LeerDato.LeerFloat();
            float lado2 = LeerDato.LeerFloat();
            float lado3 = LeerDato.LeerFloat();
            if (LeerDato.getFallo() || lado1 <= 0 || lado2 <= 0 || lado3 <= 0) 
                Console.WriteLine("Revisa los datos introducidos");
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

            //Almacenar las longitudes en otras variables
            float hipotenusa = longitudes[2];
            float cateto1 = longitudes[0];
            float cateto2 = longitudes[1];

            if (hipotenusa >= cateto1 + longitudes[1]) return "No es un triangulo";
            if (hipotenusa * hipotenusa == cateto1 * cateto1 + cateto2 * cateto2) return "Es un triángulo rectángulo";
            if (hipotenusa * hipotenusa > cateto1 * cateto1 + cateto2 * cateto2) return "Es un triángulo obtusángulo";
            if (hipotenusa * hipotenusa < cateto1 * cateto1 + cateto2 * cateto2) return "Es un triángulo acutángulo";
            //Si no se cumple ninguna opción anterior, no es un triángulo
            return "No es un triángulo";
        }
    }
}
