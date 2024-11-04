using Actividad08Back.Models;

namespace Actividad08Back.Repository.Interfaces
{
    public interface IServicio
    {
        List<Servicio> getAll();
        Servicio? getById(int id);
    }
}
