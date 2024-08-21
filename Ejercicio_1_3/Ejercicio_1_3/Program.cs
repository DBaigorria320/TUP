// See https://aka.ms/new-console-template for more information

using Ejercicio_1_3;

Producto azucar = new Pack(1, "Azucar", 5.00, 10);
Producto leche = new Suelto(2, "Leche", 2.50, 6);

Console.WriteLine(azucar.ToString());
Console.WriteLine($"Precio Total: ${azucar.CalcularPrecio()}");

Console.WriteLine(leche.ToString());
Console.WriteLine($"Precio Total: ${leche.CalcularPrecio()}");
