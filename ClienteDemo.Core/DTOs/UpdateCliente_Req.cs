using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Core.DTOs
{
    public class UpdateCliente_Req
    {
        public ICliente Cliente;
        public UpdateCliente_Req(ICliente cliente)
        {
            Cliente = cliente;
        }
    }
}
