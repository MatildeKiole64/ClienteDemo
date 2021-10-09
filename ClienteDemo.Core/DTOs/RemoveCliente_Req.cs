using System;

namespace ClienteDemo.Core.DTOs
{
    public record RemoveCliente_Req
    {
        public Guid Id { get; set; }
    }
}
