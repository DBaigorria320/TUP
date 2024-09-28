using Backend.Data.Models;
using Backend.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Repository.Repositories
{
    public class ServicioRepository : IServicioRepository
    {

        private TurnosDbContext _context;

        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var servicio = GetById(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                _context.SaveChanges();
            }
        }

        public List<Servicio> GetAll()
        {
            return _context.Servicios.ToList();
        }

        public Servicio? GetById(int id)
        {
            return _context.Servicios.FirstOrDefault(s => s.IdServicio == id);
        }

        public void Save(Servicio servicio)
        {
            if (servicio.IdServicio == 0)
            {
                _context.Servicios.Add(servicio);
            }
            else
            {
                _context.Servicios.Update(servicio);
            }
            _context.SaveChanges();
        }
    }
}
