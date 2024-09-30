using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> list = new List<String>();
            Console.WriteLine("Introduce una palabra");
            String entrada = Console.ReadLine();
            while (!entrada.ToLower().Equals("fin"))
            {
                list.Add(entrada);
                Console.WriteLine("Introduce otra palabra");
                entrada = Console.ReadLine();
            }
            Console.WriteLine("Introduce que elemento quieres borrar");
            entrada = Console.ReadLine();
            if (list.Remove(entrada) == false)
            {
                Console.WriteLine("No existe");
            }
            else Console.WriteLine("Borrado");
        }
    }
}