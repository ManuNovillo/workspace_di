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

        /*
         * Método que llama a la función que muestra el menú y almacena la opción en una variable,
         * después, según la opción seleccionada y gracias a la herencia y polimorfismo,
         * llama a la ejecución de cada opción. Esto se repite mientras que la opción no sea salir.
         * El método no recibe ni devuelve ningún valor.
         */
        public void llamarEjercicio()
        {
            int opc; // Variable que almacena la opción seleccionada.
            do
            {
                opc = iniciar(); // Llamo al menú y la opción la almaceno en la variable local opc
                ejercicios[opc].ejecutar(); // Ejecuto el ejercicio que el usuario ha seleccionado.
            } while (opc != 0);
            // Cuando el usuario quiera salir selecciona la opción 0, mientras tanto sigue mostrando el menú
        }

        /*
         * Esta función muestra el menú por pantalla, solicita la opción al usuario
         * comprueba que la opción sea válida y la devuelve a la llamada.
         */
        public int iniciar()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("MI PRIMERA PRÁCTICA DE DISEÑO DE INTERFACES\n\n");
                Console.WriteLine("\t  MENÚ  ");
                Console.WriteLine("\t________\n");
                Console.WriteLine("0.- Salir del programa");
                Console.WriteLine("1.- Es primo o no...");
                Console.WriteLine("2.- ¿Qué Triángulo es?");
                Console.WriteLine("3.- Serie de Fibonacci");
                Console.WriteLine("4.- Submatriz de una Matriz");
                Console.WriteLine("5.- Quita blancos de una cadena");
                Console.WriteLine("6.- Binario a Decimal");
                Console.WriteLine("7.- ¿Es Palíndromo?");
                Console.WriteLine("8.- Dame el cambio");
                Console.WriteLine("9.- Movimiento de Matriz toroide");
                Console.WriteLine("11.- ¿El número es perfecto?");
                Console.Write("Dime la opción que quieres probar: ");

                // Leo la opción deseada y la convierto a entero
                opcion = LeerDato.LeerEntero();

                // Si la opción no es válida se muestra un mensaje de error.
                if (opcion < 0 || opcion > 11)
                {
                    Console.WriteLine("\n\nLa opción introducida es incorrecta");
                    Console.WriteLine("Pulsa INTRO para continuar");
                    Console.ReadLine();
                }
                // Mientras que la opción no esté dentro del rango de opciones se repite
            } while (opcion < 0 || opcion > 11);
            return opcion; // Devuelvo la opción seleccionada por el usuario
        }
    }
}