using System;

namespace ClienteDemo.Core.DTOs
{
    public class UpdateCliente_Req
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cliente { get; set; }

    }
}
