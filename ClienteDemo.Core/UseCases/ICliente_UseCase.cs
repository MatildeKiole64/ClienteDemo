using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;

namespace ClienteDemo.Core.UseCases
{
    public interface ICliente_UseCase
    {
        GetClientes_Res GetClientes(GetClientes_Req request);
        Task<CreateCliente_Res> CreateCliente(CreateCliente_Req request);
        Task<UpdateCliente_Res> UpdateCliente(UpdateCliente_Req request);
        Task<RemoveCliente_Res> RemoveCliente(RemoveCliente_Req request);
    }
}