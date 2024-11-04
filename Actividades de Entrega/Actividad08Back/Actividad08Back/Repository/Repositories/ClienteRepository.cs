using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;

namespace Actividad08Back.Repository.Repositories
{
    public class ClienteRepository : ICliente
    {
        turnosContext _context;

        public ClienteRepository(turnosContext context)
        {
            _context = context;
        }

        public int AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return FindByDni(cliente.Dni).IdCliente;
        }

        public Cliente? FindByDni(string dni)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Dni.Equals(dni));

            if (cliente == null)
            {
                return null;
            }
            return cliente;
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? GetById(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if(cliente == null)
            {
                return null;
            }
            return cliente;
        }
    }
}
