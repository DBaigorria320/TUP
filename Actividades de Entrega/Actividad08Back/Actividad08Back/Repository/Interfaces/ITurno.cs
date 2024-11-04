using Actividad08Back.Models;

namespace Actividad08Back.Repository.Interfaces
{
    public interface ITurno
    {
        List<Turno> getAll();

        Turno? getById(int id);
        bool Save(Turno turno);
    }
}
