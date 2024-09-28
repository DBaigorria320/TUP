using Backend.Data.Repository.Interfaces;
using Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Service
{
    public class Servicio : IServicio
    {
        private IServicioRepository _repositorio;

        public Servicio(IServicioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Data.Models.Servicio> ObtenerServicios()
        {
            return _repositorio.GetAll();
        }

        public Data.Models.Servicio? ObtenerServicioPorId(int id)
        {
            return _repositorio.GetById(id);
        }

        public void GuardarServicio(Data.Models.Servicio servicio)
        {
            _repositorio.Save(servicio);
        }

        public void EliminarServicio(int id)
        {
            _repositorio.Delete(id);
        }
    }
}
