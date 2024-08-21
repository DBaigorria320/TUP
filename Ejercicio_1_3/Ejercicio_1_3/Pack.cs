using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_3
{
    public class Pack : Producto
    {
        private int Cantidad {  get; set; }

        public Pack()
        {
            Cantidad = 0;
        }

        public Pack(int codigo, string nombre, double precio, int cantidad) : base(codigo, nombre, precio)
        {
            Cantidad = cantidad;
        }

        public override double CalcularPrecio()
        {
            return Cantidad * Precio;
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo} - Nombre: {Nombre} - Precio: ${Precio} - Cantidad: {Cantidad}";
        }
    }
}
