using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Domain
{
    public class DetailReceip
    {
        public int Id { get; set; }
        public Article Article { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - {Article} - Cantida: {Amount}";
        }
    }
}
