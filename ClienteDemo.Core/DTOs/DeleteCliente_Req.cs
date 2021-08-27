namespace ClienteDemo.Core.DTOs
{
    public class DeleteCliente_Req
    {
        public string Cliente;
        public DeleteCliente_Req(string cliente)
        {
            Cliente = cliente;
        }
    }
}
