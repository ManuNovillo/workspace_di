using System;

namespace Algoritmos.Ejercicios
{
    internal class EjercicioExamen : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio examen");
            Console.WriteLine("Introduce de cuántas filas quieres la pirámide");
            int filas = LeerDato.LeerEntero();
            if (filas <= 0) Console.WriteLine("Dato incorrecto, tienes que poner un número válido de filas");
            else printPiramide(filas);
            Console.WriteLine("Pulsa INTRO para continuar");
            Console.ReadLine();
        }

        /// <summary>
        /// Imprime una pirámide del tipo
        ///     *
        ///    ***
        ///   *****
        ///  *******
        /// ********* 
        /// dado el número de filas
        /// </summary>
        /// <param name="filas"> Cuántas filas va a tener la pirámide</param>
        private void printPiramide(int filas)
        {
            // Cuántos espacios dejar al principio para que salga centrada
            // Se calcula multiplicando el número de filas por 2, restando 1, y dividiendo ese resultado entre 2
            int espacios = (filas * 2 -1)/2;

            // Cuántas estrellas van a haber en esa fila
            int numEstrellas;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < espacios; j++)
                {
                    Console.Write(" ");
                }
                numEstrellas = 2 * i + 1; // Fórmula que da los números impares, que en este caso es el número de estrellas en la fila
                for (int j = 0; j < numEstrellas; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                espacios--; // En la siguiente fila habrán más estrellas y menos espacios
            }
        }
    }
}
