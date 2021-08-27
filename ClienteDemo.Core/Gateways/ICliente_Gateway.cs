using ClienteDemo.Core.Entidades;
using System.Threading.Tasks;
using ClienteDemo.Core.Helpers;

namespace ClienteDemo.Core.Gateways
{
    public interface ICliente_Gateway
    {
        Task Create(string cliente, string nome);
        Task<DataCollection<ICliente>> GetClientes(int page, int take);
        Task UpdateCliente(ICliente cliente);
        Task<ICliente> GetCliente(string cliente);
        Task Remove(ICliente cliente);
    }
}