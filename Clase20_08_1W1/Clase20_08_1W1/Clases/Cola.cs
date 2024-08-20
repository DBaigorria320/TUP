using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_08_1W1.Clases
{
    public class Cola : Collection
    {
        public Cola(int tamanio) : base (tamanio)
        {

        }

        public override object Extraer()
        {
            object? obj = null;

            if (!EstaVacia())
            {
                for(int i = 0; i < siguiente && elementos[i] != null; i++)
                {
                    obj = elementos[i];
                    elementos[i] = null;
                    break;
                }
            }

            return obj;
        }
    }
}
