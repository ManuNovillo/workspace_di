using Clases.ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal class Menu
    {
        private List<Ejercicio> ejercicios;

        public Menu()
        {
            ejercicios = new List<Ejercicio>();
            ejercicios.AddRange(new Ejercicio[] {
                    new Ejercicio1(),
                    new Ejercicio2(),
                    new Ejercicio3(),
                    new Ejercicio4(),
                    new Ejercicio5(),
                    new Ejercicio6(),
                    new Ejercicio7(),
                    new Ejercicio8(),
                    new Ejercicio9(),
                    new Ejercicio10(),
                }
            );
        }

        public void iniciar()
        {
            ejercicios[Seleccion() - 1].ejecutar();
        }

        private int Seleccion()
        {
            Console.WriteLine("Elige un ejercicio:\n" +
                         "1. Numero primo\n" +
                         "2. Triangulo\n" +
                         "3. Fibonacci\n" +
                         "4. Submatriz\n" +
                         "5. Quitar espacios\n" +
                         "6. Binario a decimal\n" +
                         "7. Palindromo\n" +
                         "8. Cambio\n" +
                         "9. Toroide\n" +
                         "10. Numero perfecto"
            );
            String seleccion = Console.ReadLine();
            bool intento = int.TryParse(seleccion, out int num);
            return intento ? num : -1;
        }
    }
}
