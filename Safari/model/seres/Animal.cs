using System;

namespace Safari.model.seres
{
    internal class Animal : Ser
    {
        protected static Type tipoComida { get; set; }

        public Type getTipoComida() { 
            return tipoComida; 
        }
    }
}
