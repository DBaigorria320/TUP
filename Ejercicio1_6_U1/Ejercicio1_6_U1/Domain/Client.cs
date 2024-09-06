using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public List<Account> Accounts { get; set; }

        public Client() 
        {
            Accounts = new List<Account>();
        }

        public void addAccount(Account a)
        {
            Accounts.Add(a);
        }

        public void removeAccount(int index)
        {
            Accounts.RemoveAt(index);
        }

        public override string ToString()
        {
            return $"Nombre: {Name} - Apellido: {Surname} - DNI: {Dni}";
        }
    }
}
