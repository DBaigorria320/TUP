using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Pila : ICollection
    {
        public List<object> Objetos { get; set; }
        public int Contador {  get; set; }

        public Pila() 
        { 
            Objetos = new List<object>();
            Contador = 0;
        }

        public Pila(List<object> objetos, int contador)
        {
            Objetos = objetos;
            Contador = contador;
        }

        public bool EstaVacia()
        {
            return Objetos.Count == 0;
        }

        public object Extraer()
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("La pila esta vacía!");
            }
            else
            {
                object obj = Objetos[Objetos.Count - 1];
                Objetos.RemoveAt(Objetos.Count - 1);
                Contador--;
                return obj;
            }
        }

        public object Primero()
        {
            if(EstaVacia())
            {
                throw new InvalidOperationException("La pila esta vacía!");
            }
            else
            {
                return Objetos[Objetos.Count - 1];
            }
        }

        public bool Anadir(object obj)
        {
            try
            {
                Objetos.Add(obj);
                Contador++;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
