namespace ClienteDemo.Core.DTOs
{
    public class CreateCliente_Req
    {
        public string Nome;
        public string Cliente;

        public CreateCliente_Req(string cliente, string nome)
        {
            Nome = nome;
            Cliente = cliente;
        }
    }
}