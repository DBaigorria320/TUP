using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Interfaces
{
    public interface ITurnoService
    {
        List<Turno> GetTurnos();
        Turno? GetTurnoById(int id);
        bool DeleteTurno(int id);
        bool SaveTurno(Turno turno);
    }
}
