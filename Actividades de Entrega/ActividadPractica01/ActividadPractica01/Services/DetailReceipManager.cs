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
    public class DetailReceipManager
    {
        private IDetailReceipRepository _repository;

        public DetailReceipManager()
        {
            _repository = new DetailReceipRepository();
        }

        public List<DetailReceip> GetDetailsReceip() 
        {
            return _repository.GetAll();
        }

        public DetailReceip GetDetailReceipById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
