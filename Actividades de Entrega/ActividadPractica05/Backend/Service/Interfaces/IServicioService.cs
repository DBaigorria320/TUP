using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Interfaces
{
    public interface IServicioService
    {
        List<Servicio> GetServicios();
        Servicio? GetServicioById(int id);
        bool SaveServicio(int id, Servicio servicio);
        bool DeleteServicio(int id);
        List<Servicio> GetAllServiciosByPromocion(bool condicion);
        List<Servicio> GetAllServiciosByPrecio(decimal precio1, decimal precio2);
        bool SacarPromocion(int id);
    }
}
