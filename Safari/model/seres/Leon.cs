using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.model.seres
{
    internal class Leon : Carnivoro
    {
        

        public override String ToString()
        {
            return "Leon";
        }

        /// <summary>
        /// Devuelve el tipoDeComida
        /// </summary>
        /// <returns></returns>
        public override Type getTipoComida()
        {
            return typeof(Gacela);
        }

    }
}
