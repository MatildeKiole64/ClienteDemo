using ClienteDemo.Core.Entidades;
using ClienteDemo.Core.Gateways;
using ClienteDemo.Core.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClienteDemo.Infrastucture.Models;

namespace ClienteDemo.Infrastucture.Repositorios
{
    public class Cliente_Repositorio : ICliente_Gateway
    {
        private readonly DataContext dataContext;
        public Cliente_Repositorio(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Create(string cliente, string nome)
        {
            var _cliente = new ClienteModel
            {
                Nome = nome,
                Cliente = cliente
            };

            dataContext.Clientes.Add(_cliente);
            await dataContext.SaveChangesAsync();
        }

        public Task<ICliente> GetCliente(string cliente)
        {
            var tempCliente = dataContext.Clientes.FirstOrDefault(c => c.Cliente == cliente);

            return Task.FromResult((ICliente)tempCliente);
        }

        public Task<DataCollection<ICliente>> GetClientes(int page, int take)
        {
            var query = dataContext.Clientes.AsQueryable().AsNoTracking();
            DataCollection<ClienteModel> clientes = query.OrderBy(c => c.Cliente).Paging(page, take);
            var resultados = clientes.MapTo<DataCollection<ICliente>>();

            return Task.FromResult(resultados);
        }

        public async Task Remove(ICliente cliente)
        {
            cliente.isDeleted = true;

            var tempCliente = cliente.MapTo<ClienteModel>();

            dataContext.Clientes.Update(tempCliente);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateCliente(ICliente cliente)
        {
            var tempCliente = new ClienteModel
            {
                Cliente = cliente.Cliente,
                Nome = cliente.Nome,
            };

            dataContext.Clientes.Update(tempCliente);

            await dataContext.SaveChangesAsync();
        }
    }
}
