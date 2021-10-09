
using System;
using System.Linq;
using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;
using ClienteDemo.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using ClienteDemo.Infrastucture.Models;
using ClienteDemo.Infrastucture.Repositorios;
using ClienteDemo.Core.UseCases;

namespace ClienteDemo.Application
{
    public class Cliente_Service: ICliente_UseCase
    {
        private readonly DataContext repo;
        public Cliente_Service(DataContext repo)
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
                var cliente = request.MapTo<Cliente>();

                await repo.AddAsync(cliente);
                await repo.SaveChangesAsync();

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

        public async Task<RemoveCliente_Res> RemoveCliente(RemoveCliente_Req request)
        {
            bool ok = false;
            string msg = string.Empty;
            RemoveCliente_Res response = null;

            try
            {
                var cliente = await repo.Clientes.FindAsync(request.Id);

                if (cliente is null || !cliente.IsActive)
                {
                    throw new Exception("Cliente doesn't exist");
                }

                cliente.IsActive = false;
                repo.Clientes.Update(cliente);
                await repo.SaveChangesAsync();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                msg = ex.Message;
            }
            finally
            {
                response = new RemoveCliente_Res(msg, ok);
            }

            return response;
        }

        public GetClientes_Res GetClientes(GetClientes_Req request)
        {
            bool ok = false;
            string msg = string.Empty;
            DataCollection<CreateCliente_Req> clientes = null;
            GetClientes_Res response = null;

            try
            {
                var query = repo.Clientes.AsQueryable().AsNoTracking();
                clientes = query.OrderBy(c => c.Nome)
                                .Paging(request.Page, request.Take)
                                .MapTo<DataCollection<CreateCliente_Req>>();

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
                var cliente = await repo.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (cliente is not null || !cliente.IsActive)
                {
                    throw new Exception("Cliente doesn't exist");
                }

                cliente.Nome = request.Nome;

                repo.Clientes.Update(cliente);

                await repo.SaveChangesAsync();

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
