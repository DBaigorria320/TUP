using Ejercicio1_6_U1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Data.Interfaces
{
    public interface ITypeAccountRepository
    {
        List<TypeAccount> GetAll();
        TypeAccount GetById(int id);
        bool Save(TypeAccount oTypeAccount);
        bool Delete(int id);
    }
}
