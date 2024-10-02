using Backend.Models;
using Backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private TurnosDbContext _context;

        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var servicio = GetById(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                return _context.SaveChanges() != 0;
            }
            return false;
        }

        public List<Servicio> FilterByPrecio(decimal precio1, decimal precio2)
        {
            return [.. _context.Servicios.Where(s => s.Costo >= precio1 && s.Costo <= precio2)];
        }

        public List<Servicio> FilterByPromocion(bool condicion)
        {
            return [.. _context.Servicios.Where(s => s.EnPromocion == condicion)];
        }

        public List<Servicio> GetAll()
        {
            return [.. _context.Servicios];
        }

        public Servicio? GetById(int id)
        {
            return _context.Servicios.FirstOrDefault(s => s.IdServicio == id);
        }

        public bool OutPromocion(int id)
        {
            var servicio = GetById(id);
            if(servicio != null)
            {
                servicio.EnPromocion = false;
                servicio.Costo += 1000;
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public bool Save(int id, Servicio servicio)
        {
            if (id == 0)
            {
                _context.Servicios.Add(servicio);
            }
            else
            {
                _context.Servicios.Update(servicio);
            }
            return _context.SaveChanges() != 0;
        }
    }
}
