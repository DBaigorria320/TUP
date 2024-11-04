using Actividad08Back.Models;

namespace Actividad08Back.Repository.Interfaces
{
    public interface ICliente
    {
        List<Cliente> GetAll();
        Cliente? GetById(int id);
        Cliente? FindByDni(string dni);
        int AddCliente(Cliente cliente);
    }
}
