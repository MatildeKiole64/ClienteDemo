
using System;
using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;
using ClienteDemo.Core.Helpers;
using ClienteDemo.Core.Gateways;
using ClienteDemo.Core.UseCases;
using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Application
{
    public class Cliente_Service : ICliente_UseCase
    {
        private readonly ICliente_Gateway repo;
        public Cliente_Service(ICliente_Gateway repo)
        {
            this.repo = repo;
        }

        public async Task<CreateCliente_Res> CreateCliente(CreateCliente_Req request)
        {
            bool ok = false;
            string msg = string.Empty;
            CreateCliente_Res response = null;

            try
            {
                await repo.Create(request.Cliente, request.Nome);

                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                msg = ex.Message;
            }
            finally
            {
                response = new CreateCliente_Res(msg, ok);
            }

            return response;
        }

        public async Task<DeleteCliente_Res> DeleteCliente(DeleteCliente_Req request)
        {
            bool ok = false;
            string msg = string.Empty;
            DeleteCliente_Res response = null;

            try
            {
                ICliente cliente = await repo.GetCliente(request.Cliente);

                if (cliente is null || cliente.isDeleted)
                {
                    throw new Exception("Cliente doesn't exist");
                }

                await repo.Remove(cliente);

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                msg = ex.Message;
            }
            finally
            {
                response = new DeleteCliente_Res(msg, ok);
            }

            return response;
        }

        public async Task<GetClientes_Res> GetClientes(GetClientes_Req request)
        {
            bool ok = false;
            string msg = string.Empty;
            DataCollection<ICliente> clientes = null;
            GetClientes_Res response = null;

            try
            {
                clientes = await repo.GetClientes(request.Page, request.Take);
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                msg = ex.Message;
            }
            finally
            {
                response = new GetClientes_Res(clientes, msg, ok);
            }

            return response;
        }

        public async Task<UpdateCliente_Res> UpdateCliente(UpdateCliente_Req request)
        {
            bool ok = false;
            string msg = string.Empty;

            UpdateCliente_Res response = null;

            try
            {
                ICliente cliente = await repo.GetCliente(request.Cliente.Cliente);

                if (cliente is not null || cliente.isDeleted)
                {
                    throw new Exception("Cliente doesn't exist");
                }

                await repo.UpdateCliente(cliente);

                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                msg = ex.Message;
            }
            finally
            {
                response = new UpdateCliente_Res(msg, ok);
            }

            return response;
        }
    }
}
