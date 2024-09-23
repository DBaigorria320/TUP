using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Domain
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Method { get; set; }

        public override string ToString()
        {
            return $"Codigo: {Id} - Forma Pago: {Method}";
        }
    }
}
