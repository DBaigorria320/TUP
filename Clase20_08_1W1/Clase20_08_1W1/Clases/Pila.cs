using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_08_1W1.Clases
{
    public class Pila : Collection
    {
        public Pila(int tamanio) : base(tamanio)
        {

        }

        public override object Extraer()
        {
            object? obj = null;

            if (!EstaVacia())
            {
                obj = elementos[siguiente];
                elementos[siguiente] = null;
                siguiente--;
            }

            return obj;
        }
    }
}
