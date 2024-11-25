using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.model.seres
{
    internal class Leon : Animal
    {
        public override String ToString()
        {
            return "Leon";
        }

        public override Type getTipoComida()
        {
            return typeof(Gacela);
        }

    }
}
