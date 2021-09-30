using System;
using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Infrastucture.Models
{
    public class ClienteModel : ICliente
    {
        public string Nome { get; set; }
        public string Cliente { get; set; }
    }
}
