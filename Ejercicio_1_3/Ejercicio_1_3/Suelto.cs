using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_3
{
    public class Suelto : Producto
    {
        private double Medida {  get; set; }

        public Suelto()
        {
            Medida = 0;
        }

        public Suelto(int codigo, string nombre, double precio, double medida) : base(codigo, nombre, precio)
        {
            Medida = medida;
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }

        public override double CalcularPrecio()
        {
            return Medida * Precio;
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo} - Nombre: {Nombre} - Precio: ${Precio} - Medida: {Medida}";
        }
    }
}
