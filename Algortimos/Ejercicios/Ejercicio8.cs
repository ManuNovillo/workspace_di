using System;

namespace Algoritmos.Ejercicios
{
    internal class Ejercicio8 : Ejercicio
    {
        public override void ejecutar()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 8");
            Console.WriteLine("Introduce el precio del bote");
            float precio = LeerDato.LeerFloat();
            Console.WriteLine("Introduce la cantidad que vas a pagar");
            float introducido = LeerDato.LeerFloat();
            if (LeerDato.getFallo() || precio < 0 || introducido < 0) 
                Console.WriteLine("Revisa los datos introducidos");
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
            // Convertir los euros a céntimos para facilitar el trabajo, y calcular el resto
            // Redondear a dos decimales para evitar problemas con los float, por experiencia
            int resto = (int)(100 * Math.Round(cantidad - precio, 2));

            // El resto no puede ser menor que 0 porque entonces la cantidad es menor que el precio
            if (resto < 0)
            {
                // Mostrar error
                Console.WriteLine("Error, la cantidad introducida no puede ser menor que el precio");
            }
            else
            {
                // Calcular cuántas monedas de cada tiene que dar

                // Array con los céntimos de cada tipo de moneda/billete
                int[] currency = [500, 200, 100, 50, 20, 10, 5, 2, 1];
                int[] cambio = new int[currency.Length];
                for (int i = 0; i < currency.Length; i++)
                {
                    cambio[i] = resto / currency[i];
                    resto = resto % currency[i];
                }
                /*int monedas200 = resto / 200;
                resto = resto % 200;
                int monedas100 = resto / 100;
                resto = resto % 100;
                int monedas50 = resto / 50;
                resto = resto % 50;
                Console.WriteLine(resto);
                int monedas20 = resto / 20;
                resto = resto % 20;
                int monedas10 = resto / 10;
                resto = resto % 10;
                int monedas5 = resto / 5;
                Console.WriteLine(resto);
                resto = resto % 5;
                int monedas2 = resto / 2;
                Console.WriteLine(resto);
                resto = resto % 2;
                Console.WriteLine(resto);
                int monedas1 = resto;*/

                // Imprimir resultado en consola
                for (int i = 0; i < cambio.Length; i++)
                {
                    // Si no hay billetes/monedas de este tipo, no imprimirlo
                    if (cambio[i] == 0) continue;
                    // Si el tipo de moneda/billete es mayor que 100, dividir entre 100 para que salga en euros
                    int tipoCurrency = currency[i] >= 100 ? currency[i] / 100 : currency[i];
                    // Si es mayor de 100, poner euros, si no, poner céntimos
                    String eurosOCentimos = currency[i] >= 100 ? "euros" : "céntimos";
                    // Si es mayor de 500, es que es un billete
                    if (currency[i] >= 500) Console.Write("Billetes de ");
                    // Si no, es una moneda
                    else Console.Write("Monedas de ");
                    Console.Write($"{tipoCurrency} {eurosOCentimos}: {cambio[i]}\n");


                }
                /*Console.WriteLine($"Billetes de 5 euros: {cambio[0]}" +
                                  $"Monedas de 2 euros: {cambio[1]}\n" +
                                  $"Monedas de 1 euro: {cambio[2]}\n" +
                                  $"Monedas de 50 cént.: {cambio[3]}\n" +
                                  $"Monedas de 20 cént.: {cambio[4]}\n" +
                                  $"Monedas de 10 cént.: {cambio[5]}\n" +
                                  $"Monedas de 5 cént.: {cambio[3]}\n" +
                                  $"Monedas de 2 cént.: {cambio[3]}\n" +
                                  $"Monedas de 1 cént.: {cambio[3]}");*/

            }
        }
    }
    /*internal class Ejercicio8 : Ejercicio
    {
        public Ejercicio8()
        {

        }

        /*
         * Método que realiza las operaciones necesarias para la opción 8 del menú.
         * No recibe ni devuelve ningún valor.
         */
    /*public override void ejecutar()
    {
        Console.Clear();
        Console.WriteLine("\nVamos a calcular el cambio de una máquina expendedora");
        // Declaro las variables que almacenan el precio del producto, el dinero introducido
        // y el cambio que tendré que darle
        float precio, dinero, resto;
        // Creo un array con los tipos de monedas que existen.
        float[] tipoMonedas = { 2.0f, 1.0f, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };
        // Creo un array con la cantidad de monedas necesarias de cada tipo.
        int[] cuentaMonedas = { 0, 0, 0, 0, 0, 0, 0, 0 };
        // Solicito los valores al usuario:
        Console.Write("\n\nDime el precio del producto a comprar: ");
        precio = LeerDato.LeerFloat();
        Console.Write("\nDime la cantidad de dinero introducida: ");
        dinero = LeerDato.LeerFloat();

        // En este bucle compruebo que el cliente haya introducido dinero suficiente para el producto que quiere comprar.
        while (dinero < precio)
        {
            // Si no es así le muestro un mesaje de error y le pido más dinero.
            Console.Write("\nEl dinero introducido es insuficiente, introduce de nuevo el dinero: ");
            dinero = LeerDato.LeerFloat();
        }

        // Calculo el cambio que debo darle al cliente,
        // para evitar el problema de las operaciones con decimales uso el redondeo a dos decimales
        resto = (float)Math.Round(dinero - precio, 2);
        // Bucle que calcula monedas a devolver mientras que aún tenga que dinero que devolver
        while (resto > 0)
        {
            // Evaluo la cantidad a devolver y compruebo los casos de mayor a menor para evitar
            // dar más monedas de las necesarias.
            switch (resto)
            {
                // En cada caso de moneda comprubo si es mayor que el resto que falta por devolver
                // Aumento el contador de monedas de ese valor y resto ese valor a la cantidad a devolver.
                case float f when f >= tipoMonedas[0]:
                    resto = (float)Math.Round(resto - tipoMonedas[0], 2);
                    cuentaMonedas[0]++;
                    break;
                case float f when f >= tipoMonedas[1]:
                    resto = (float)Math.Round(resto - tipoMonedas[1], 2);
                    cuentaMonedas[1]++;
                    break;
                case float f when f >= tipoMonedas[2]:
                    resto = (float)Math.Round(resto - tipoMonedas[2], 2);
                    cuentaMonedas[2]++;
                    break;
                case float f when f >= tipoMonedas[3]:
                    resto = (float)Math.Round(resto - tipoMonedas[3], 2);
                    cuentaMonedas[3]++;
                    break;
                case float f when f >= tipoMonedas[4]:
                    resto = (float)Math.Round(resto - tipoMonedas[4], 2);
                    cuentaMonedas[4]++;
                    break;
                case float f when f >= tipoMonedas[5]:
                    resto = (float)Math.Round(resto - tipoMonedas[5], 2);
                    cuentaMonedas[5]++;
                    break;
                case float f when f >= tipoMonedas[6]:
                    resto = (float)Math.Round(resto - tipoMonedas[6], 2);
                    cuentaMonedas[6]++;
                    break;
                case float f when f >= tipoMonedas[7]:
                    resto = (float)Math.Round(resto - tipoMonedas[7], 2);
                    cuentaMonedas[7]++;
                    break;
            }
        }

        // Recorro el array de cantidad de monedas y muestro la cantidad de cada una de ellas a devolver.
        Console.WriteLine("Las monedas a devolver son: ");
        for (int i = 0; i < tipoMonedas.Length; i++)
        {
            if (cuentaMonedas[i] != 0)
            {
                Console.WriteLine($"{cuentaMonedas[i]} monedas de {tipoMonedas[i]} euros.");
            }
        }
        Console.WriteLine("Pulsa INTRO para continuar.");
        Console.ReadLine();
    }
}*/
}
