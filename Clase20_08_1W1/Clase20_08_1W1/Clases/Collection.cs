using Clase20_08_1W1.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_08_1W1.Clases
{
    public abstract class Collection : ICollection
    {
        public object[] elementos;
        public int siguiente;

        public Collection(int tamanio)
        {
            elementos = new object[tamanio];
            siguiente = -1;
        }

        public virtual bool Anadir(object obj)
        {
            bool aux = false;

            if (siguiente < elementos.Length)
            {
                elementos[++siguiente] = obj;
                aux = true;
            }

            return aux;
        }

        public bool EstaVacia()
        {
            return siguiente == -1;
        }

        public abstract object Extraer();

        public object Primero()
        {
            object? obj = null;

            if (!EstaVacia())
            {
                obj = elementos[0];
            }

            return obj;
        }
    }
}
