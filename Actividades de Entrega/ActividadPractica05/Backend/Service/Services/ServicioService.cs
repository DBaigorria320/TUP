using Backend.Models;
using Backend.Repository.Interfaces;
using Backend.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Services
{
    public class ServicioService : IServicioService
    {
        private IServicioRepository _repositorio;

        public ServicioService(IServicioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public bool DeleteServicio(int id)
        {
            return _repositorio.Delete(id);
        }

        public List<Servicio> GetAllServiciosByPrecio(decimal precio1, decimal precio2)
        {
            return _repositorio.FilterByPrecio(precio1, precio2);
        }

        public List<Servicio> GetAllServiciosByPromocion(bool condicion)
        {
            return _repositorio.FilterByPromocion(condicion);
        }

        public Servicio? GetServicioById(int id)
        {
            return _repositorio.GetById(id);
        }

        public List<Servicio> GetServicios()
        {
            return _repositorio.GetAll();
        }

        public bool SacarPromocion(int id)
        {
            return _repositorio.OutPromocion(id);
        }

        public bool SaveServicio(int id, Servicio servicio)
        {
            return _repositorio.Save(id, servicio);
        }
    }
}
