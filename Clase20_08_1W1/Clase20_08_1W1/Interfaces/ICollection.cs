using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_08_1W1.Interfaces
{
    public interface ICollection
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Anadir(object obj);
    }
}
