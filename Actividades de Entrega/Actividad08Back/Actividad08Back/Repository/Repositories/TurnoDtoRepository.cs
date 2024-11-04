using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;

namespace Actividad08Back.Repository.Repositories
{
    public class TurnoDtoRepository : ITurnoDto
    {

        ITurno _repository;
        ICliente _cliente;
        IServicio _servicio;

        public TurnoDtoRepository(ITurno repository, ICliente cliente, IServicio servicio)
        {
            _repository = repository;
            _cliente = cliente;
            _servicio = servicio;
        }

        public List<TurnoDto> getAll()
        {
            var turnos = _repository.getAll();

            var turnosDto = turnos.Select(t => new TurnoDto
            {
                Fecha = t.Fecha,
                Hora = t.Hora,
                Cliente = _cliente.GetById(t.IdCliente),
                Servicio = _servicio.getById(t.IdServicio)
            }).ToList();

            return turnosDto;
        }

        public TurnoDto? getById(int id)
        {
            var turno = _repository.getById(id);

            var turnoDto = new TurnoDto
            {
                Fecha = turno.Fecha,
                Hora = turno.Hora,
                Cliente = _cliente.GetById(turno.IdCliente),
                Servicio = _servicio.getById(turno.IdServicio)
            };

            return turnoDto;
        }

        public bool Save(TurnoDto turnoDto)
        {
            var cliente = _cliente.FindByDni(turnoDto.Cliente.Dni);
            if (cliente == null)
            {
                cliente = new Cliente()
                {
                    Nombre = turnoDto.Cliente.Nombre,
                    Apellido = turnoDto.Cliente.Apellido,
                    Dni = turnoDto.Cliente.Dni,
                };
                var id = _cliente.AddCliente(cliente);

                var turno = new Turno()
                {
                    Fecha = turnoDto.Fecha,
                    Hora = turnoDto.Hora,
                    IdCliente = id,
                    IdServicio = turnoDto.Servicio.IdServicio
                };

                return _repository.Save(turno);
            }else
            {
                var turno = new Turno()
                {
                    Fecha = turnoDto.Fecha,
                    Hora = turnoDto.Hora,
                    IdCliente = cliente.IdCliente,
                    IdServicio = turnoDto.Servicio.IdServicio
                };

                return _repository.Save(turno);
            }


        }
    }
}
