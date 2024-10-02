using Backend.Models;
using Backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private TurnosDbContext _context;

        public TurnoRepository(TurnosDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var turno = GetById(id);
            if(turno != null)
            {
                _context.Turnos.Remove(turno);
                return _context.SaveChanges() != 0;
            }
            return false;
        }

        public List<Turno> GetAll()
        {
            return [.. _context.Turnos];
        }

        public Turno? GetById(int id)
        {
            return _context.Turnos.FirstOrDefault(t => t.IdTurno == id);
        }

        public bool Save(Turno turno)
        {
            if(turno.IdTurno == 0)
            {
                _context.Turnos.Add(turno);
            }
            else
            {
                _context.Turnos.Update(turno);
            }
            return _context.SaveChanges() != 0;
        }
    }
}
