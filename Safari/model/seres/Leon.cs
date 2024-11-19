using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.model.seres
{
    internal class Leon : Carnivoro
    {
        static Leon()
        {
            tipoComida = typeof(Gacela);
        }
        public override String ToString()
        {
            return "Leon";
        }
    }
}
