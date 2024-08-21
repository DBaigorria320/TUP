// See https://aka.ms/new-console-template for more information

using EjercicioInterfaces;

Pila pila = new Pila();

pila.Anadir(10);
pila.Anadir(20);
pila.Anadir(30);

Console.WriteLine($"Primero: {pila.Primero()}"); // Debe imprimir 30
Console.WriteLine($"Extraer: {pila.Extraer()}"); // Debe imprimir 30
Console.WriteLine($"Primero: {pila.Primero()}"); // Debe imprimir 20
Console.WriteLine($"Está vacía: {pila.EstaVacia()}"); // Debe imprimir False