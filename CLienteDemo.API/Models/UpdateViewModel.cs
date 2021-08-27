using ClienteDemo.Core.Entidades;
using System;

namespace ClienteDemo.Api.Models
{
    public class UpdateViewModel : ICliente
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Nome { get; set; }
        public bool isDeleted { get; set; }
    }
}
