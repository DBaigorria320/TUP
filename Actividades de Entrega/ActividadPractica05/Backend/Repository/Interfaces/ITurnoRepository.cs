using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Interfaces
{
    public interface ITurnoRepository
    {
        List<Turno> GetAll();
        Turno? GetById(int id);
        bool Save(Turno turno);
        bool Delete(int id);
    }
}
