using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.model.seres
{
    internal class Gacela : Herbivoro
    {
        static Gacela()
        {
            tipoComida = typeof(Planta);
        }
        public override String ToString()
        {
            return "Gacela";
        }
    }
}
