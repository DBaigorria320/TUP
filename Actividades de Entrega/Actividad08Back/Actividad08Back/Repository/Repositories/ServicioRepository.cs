using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;

namespace Actividad08Back.Repository.Repositories
{
    public class ServicioRepository : IServicio
    {

        turnosContext _context;

        public ServicioRepository(turnosContext context)
        {
            _context = context;
        }

        public List<Servicio> getAll()
        {
            return _context.Servicios.ToList();
        }

        public Servicio? getById(int id)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.IdServicio == id);

            if(servicio == null)
            {
                return null;
            }
            return servicio;
        }
    }
}
