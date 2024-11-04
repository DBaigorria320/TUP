using Actividad08Back.Models;

namespace Actividad08Back.Repository.Interfaces
{
    public interface ITurnoDto
    {
        List<TurnoDto> getAll();
        TurnoDto? getById(int id);
        bool Save(TurnoDto turno);
    }
}
