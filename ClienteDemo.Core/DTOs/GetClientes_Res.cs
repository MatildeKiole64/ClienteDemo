using ClienteDemo.Core.Helpers;
using ClienteDemo.Core.Entidades;

namespace ClienteDemo.Core.DTOs
{
    public class GetClientes_Res
    {
        public bool Ok;
        public string Msg;
        public DataCollection<ICliente> Clientes;
        public GetClientes_Res(DataCollection<ICliente> clientes, string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
            Clientes = clientes;
        }
    }
}
