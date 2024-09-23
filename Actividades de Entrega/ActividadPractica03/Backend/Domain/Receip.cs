using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Domain
{
    public class Receip
    {
        public int NroReceip { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Client { get; set; }
        public List<DetailReceip> DetailsReceip { get; set; }

        public Receip() 
        {
            DetailsReceip = new List<DetailReceip>();
        }

        public override string ToString()
        {
            return $"Nro Factura: {NroReceip} - Fecha: {Date} - Metodo Pago: {PaymentMethod} - Cliente: {Client} - Detalles: {DetailsReceip}";
        }
    }
}
