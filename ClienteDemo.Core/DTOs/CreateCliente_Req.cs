namespace ClienteDemo.Core.DTOs
{
    public record CreateCliente_Req
    {
        public string Cliente { get; set; }
        public string Nome { get; set; }
    }
}