using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> list = new List<int>();
            IEnumerable<int> pares = from n 
                                     in numeros 
                                     where (n % 2 == 0) 
                                     select n;
            foreach (var num in pares)
            {
                Console.WriteLine(num);
            }
        }
    }
}
