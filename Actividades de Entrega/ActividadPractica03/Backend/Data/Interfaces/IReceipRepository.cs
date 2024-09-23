using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Interfaces
{
    public interface IReceipRepository
    {
        List<Receip> GetAll();
        Receip GetById(int id);
        bool Save(Receip receip);
        bool Delete(int id);
        List<Receip> GetByDate(DateTime date);
        List<Receip> GetByPaymentMethod(int id);
        bool Update(Receip receip);

    }
}
