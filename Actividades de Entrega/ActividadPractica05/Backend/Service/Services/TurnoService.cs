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
    public class TurnoService : ITurnoService
    {
        private ITurnoRepository _repositorio;

        public TurnoService(ITurnoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public bool DeleteTurno(int id)
        {
            return _repositorio.Delete(id);
        }

        public Turno? GetTurnoById(int id)
        {
            return _repositorio.GetById(id);
        }

        public List<Turno> GetTurnos()
        {
            return _repositorio.GetAll();
        }

        public bool SaveTurno(Turno turno)
        {
            turno.Fecha = DateOnly.FromDateTime(DateTime.Now);
            turno.Hora = TimeOnly.FromDateTime(DateTime.Now);
            return _repositorio.Save(turno);
        }
    }
}
