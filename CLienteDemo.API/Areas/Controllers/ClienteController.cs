using ClienteDemo.Core.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClienteDemo.Core.UseCases;

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
        public async Task<IActionResult> Create(CreateCliente_Req request)
        {
            var response = await cliente_useCase.CreateCliente(request);

            return response.Ok ? Ok(response.Msg) : BadRequest(response.Msg);
        }

        [HttpPut]
        [Route("update/")]
        public async Task<IActionResult> Update(UpdateCliente_Req request)
        {
            var response = await cliente_useCase.UpdateCliente(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Remove(RemoveCliente_Req request)
        {
            var response = await cliente_useCase.RemoveCliente(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

        [HttpGet]
        [Route("clientes/")]
        public IActionResult GetClientes(GetClientes_Req request)
        {
            var response = cliente_useCase.GetClientes(request);

            return response.Ok ? Ok(response) : BadRequest(response.Msg);
        }

    }
}
