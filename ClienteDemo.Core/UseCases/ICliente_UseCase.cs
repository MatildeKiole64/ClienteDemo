using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;

namespace ClienteDemo.Core.UseCases
{
    public interface ICliente_UseCase
    {
        Task<GetClientes_Res> GetClientes(GetClientes_Req request);
        Task<CreateCliente_Res> CreateCliente(CreateCliente_Req request);
        Task<UpdateCliente_Res> UpdateCliente(UpdateCliente_Req request);
        Task<DeleteCliente_Res> DeleteCliente(DeleteCliente_Req request);
    }
}