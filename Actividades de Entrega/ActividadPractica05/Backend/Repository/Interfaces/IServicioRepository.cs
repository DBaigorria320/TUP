using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Interfaces
{
    public interface IServicioRepository
    {
        List<Servicio> GetAll();
        Servicio? GetById(int id);
        bool Save(int id, Servicio servicio);
        bool Delete(int id);
        List<Servicio> FilterByPromocion(bool condicion);
        List<Servicio> FilterByPrecio(decimal precio1, decimal precio2);
        bool OutPromocion(int id);
    }
}
