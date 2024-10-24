using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio8 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Ejercicio 8");
            Console.WriteLine("Introduce el precio del bote");
            float precio = LeerDato.LeerFloat();
            Console.WriteLine("Introduce la cantidad que vas a pagar");
            float introducido = LeerDato.LeerFloat();
            if(LeerDato.getFallo()) Console.WriteLine("Revisa los datos introducidos");
            else GetCambio(precio, introducido);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }
        /// <summary>
        /// Imprime en consola la cantidad de monedas de cada tipo a dar para el resto, o "Error" si <c><paramref name="cantidad"/></c><c><paramref name="precio"/></c>
        /// </summary>
        /// <param name="precio">Precio de la lata, en euros</param>
        /// <param name="cantidad">Cantidad introducida, en euros</param>
        void GetCambio(float precio, float cantidad)
        {
            //Convertir los euros a céntimos para facilitar el trabajo, y calcular el resto
            int resto = (int)(100 * (cantidad - precio));
            //El resto no puede ser menor que 0 porque entonces la cantidad es menor que el precio
            if (resto < 0)
            {
                //Mostrar error
                Console.WriteLine("Error");
            }
            else
            {
                //Calcular cuántas monedas de cada tiene que dar
                int monedas200 = resto / 200;
                resto = resto % 200;
                int monedas100 = resto / 100;
                resto = resto % 100;
                int monedas50 = resto / 50;
                resto = resto % 50;
                int monedas20 = resto / 20;
                resto = resto % 20;
                int monedas10 = resto / 10;
                resto = resto % 10;
                int monedas5 = resto / 5;
                resto = resto % 5;
                int monedas2 = resto / 2;
                resto = resto % 2;
                int monedas1 = resto;

                //Imprimir resultado en consola
                Console.WriteLine($"Monedas de 2€: {monedas200}\n" +
                                  $"Monedas de 1€: {monedas100}\n" +
                                  $"Monedas de 50 cént.: {monedas50}\n" +
                                  $"Monedas de 20 cént.: {monedas20}\n" +
                                  $"Monedas de 10 cént.: {monedas10}\n" +
                                  $"Monedas de 5 cént.: {monedas5}\n" +
                                  $"Monedas de 2 cént.: {monedas2}\n" +
                                  $"Monedas de 1 cént.: {monedas1}");
            }
        }
    }
}
