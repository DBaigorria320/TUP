using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Repository;
using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Services
{
    public class ReceipManager
    {
        private IReceipRepository _repository;

        public ReceipManager()
        {
            _repository = new ReceipRepository();
        }

        public List<Receip> GetReceips() 
        {
            return _repository.GetAll();
        }

        public Receip GetReceipById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveReceip(Receip receip)
        {
            return _repository.Save(receip);
        }

        public List<Receip> GetReceipsByDate(DateTime date)
        {
            return _repository.GetByDate(date);
        }

        public List<Receip> GetReceipsByPaymentMethod(int id)
        {
            return _repository.GetByPaymentMethod(id);
        }
    }
}
