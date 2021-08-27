using ClienteDemo.Api.Models;
using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClienteDemo.Core.UseCases;
using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Api.Areas.Controllers
{
    [Route("api/cliente/")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente_UseCase cliente_useCase;
        public ClienteController(ICliente_UseCase cliente_useCase)
        {
            this.cliente_useCase = cliente_useCase;
        }

        [HttpPost]
        [Route("create/")]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            var request = new CreateCliente_Req(viewModel.Cliente, viewModel.Nome);

            var response = await cliente_useCase.CreateCliente(request);

            return response.Ok ? Ok(response.Msg) : BadRequest(response.Msg);
        }

        [HttpPut]
        [Route("update/")]
        public async Task<IActionResult> Update(UpdateViewModel viewModel)
        {
            var request = new UpdateCliente_Req(viewModel);

            var response = await cliente_useCase.UpdateCliente(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

        [HttpDelete]
        [Route("delete/{cliente}")]
        public async Task<IActionResult> Delete(string cliente)
        {
            var request = new DeleteCliente_Req(cliente);

            var response = await cliente_useCase.DeleteCliente(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

        [HttpGet]
        [Route("clientes/")]
        public async Task<IActionResult> GetClientes(int page, int take)
        {
            var request = new GetClientes_Req(page, take);

            var response = await cliente_useCase.GetClientes(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

    }
}
