using System;
using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Infrastucture.Models
{
    public class ClienteModel : ICliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cliente { get; set; }
        public bool isDeleted { get ; set; }
    }
}
