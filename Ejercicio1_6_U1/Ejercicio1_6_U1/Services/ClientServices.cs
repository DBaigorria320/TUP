using Ejercicio1_6_U1.Data.Interfaces;
using Ejercicio1_6_U1.Data.Repositories;
using Ejercicio1_6_U1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Services
{
    public class ClientServices
    {
        private IClientRepository _repository;

        public ClientServices() 
        {
            _repository = new ClientRepository();
        }

        public List<Client> GetClients()
        {
            return _repository.GetAll();
        }

        public Client GetClientById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveClient(Client client)
        {
            return _repository.Save(client);
        }
    }
}
