using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Repository.Interfaces
{
    public interface IServicioRepository
    {
        List<Servicio> GetAll();
        Servicio? GetById(int id);
        void Save(Servicio servicio);
        void Delete(int id);
    }
}
