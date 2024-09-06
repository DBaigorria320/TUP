using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Cbu { get; set; }
        public double Balance { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public string LastMovement { get; set; }
    }
}
