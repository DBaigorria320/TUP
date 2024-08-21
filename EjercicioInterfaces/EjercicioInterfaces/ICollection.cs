using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public interface ICollection
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Anadir(object obj);
    }
}
