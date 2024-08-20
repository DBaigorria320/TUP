// See https://aka.ms/new-console-template for more information

// Pilas.Escribe una interfaz, llamada IColleccion que declare los siguientes métodos:
//  estaVacia(): devuelve true si la colección está vacía y false en caso contrario.
//  extraer(): devuelve y elimina el primer elemento de la colección.
//  primero(): devuelve el primer elemento de la colección.
//  añadir(): añade un objeto por el extremo que corresponda, y devuelve true si se ha añadido y false en caso contrario.
// A continuación, escribe una clase Pila, que implemente esta interfaz,
// utilizando para ello un array de Object y un contador de objetos.

// Colas.Desarrollar una clase Cola que implemente la interfaz definida en el
// problema anterior pero esta vez utilizando un objeto List. Tener en cuenta que una
// Cola es una estructura FIFO (Primero en entrar primero en salir).

using Clase20_08_1W1.Clases;

var pila = new Pila(4);
var cola = new Cola(4);

object[] coleccion = {pila, cola};

foreach(Collection item  in coleccion)
{
    Console.WriteLine(item.Anadir(1));
    Console.WriteLine(item.Anadir(2));
    Console.WriteLine(item.Anadir(3));
    Console.WriteLine(item.Anadir(4));
    Console.WriteLine(item.Extraer());
}