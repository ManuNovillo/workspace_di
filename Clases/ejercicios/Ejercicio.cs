using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.ejercicios
{
    internal abstract class Ejercicio
    {
        private Cosa cosa;
        public abstract void ejecutar();
    }

    interface Cosa
    {
        void hola();
    }

    class Prueba : Cosa
    {
        public void hola()
        {
            Console.WriteLine("hola");
        }
    }
}
