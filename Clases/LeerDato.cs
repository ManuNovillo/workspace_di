using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal static class LeerDato
    {
        public static int LeerEntero()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("No es un numero");
                return -1;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Demasiado grande");
                return -3;
            }
            catch (ArgumentNullException e) 
            {
                Console.WriteLine("No hay argumento");
                return -2;
            }
        }

        public static int LeerFloat()
        {
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("No es un numero");
                return -1;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Demasiado grande");
                return -3;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("No hay argumento");
                return -2;
            }
        }
    }
}
