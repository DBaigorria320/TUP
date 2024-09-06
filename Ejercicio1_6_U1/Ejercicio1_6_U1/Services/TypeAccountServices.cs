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
    public class TypeAccountServices
    {
        private ITypeAccountRepository _repository;

        public TypeAccountServices()
        {
            _repository = new TypeAccountRepository();
        }

        public List<TypeAccount> GetAllTypesAccounts() 
        {
            return _repository.GetAll();
        }

        public TypeAccount GetTypeAccountById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveTypeAccount(TypeAccount oTypeAccount)
        {
            return _repository.Save(oTypeAccount);
        }

        public bool DeleteTypeAccount(int id)
        {
            return _repository.Delete(id);
        }
    }
}
