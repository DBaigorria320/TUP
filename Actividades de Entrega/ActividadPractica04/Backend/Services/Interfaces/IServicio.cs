using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IServicio
    {
        List<Servicio> ObtenerServicios();
        Servicio? ObtenerServicioPorId(int id);
        void GuardarServicio(Servicio servicio);
        void EliminarServicio(int id);
    }
}
