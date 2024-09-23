using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Utils
{
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Parameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
