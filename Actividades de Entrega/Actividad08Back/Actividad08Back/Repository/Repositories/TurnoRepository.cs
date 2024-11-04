using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;

namespace Actividad08Back.Repository.Repositories
{
    public class TurnoRepository : ITurno
    {
        turnosContext _context;

        public TurnoRepository(turnosContext context)
        {
            _context = context;
        }

        public List<Turno> getAll()
        {
            return _context.Turnos.ToList();
        }

        public Turno? getById(int id)
        {
            var turno = _context.Turnos.FirstOrDefault(t => t.IdTurno == id);

            if (turno == null)
            {
                return null;
            }
            return turno;
        }

        public bool Save(Turno turno)
        {
            _context.Turnos.Add(turno);
            return _context.SaveChanges() != 0;
        }
    }
}
