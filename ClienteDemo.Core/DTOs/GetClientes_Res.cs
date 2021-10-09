using ClienteDemo.Core.Helpers;

namespace ClienteDemo.Core.DTOs
{
    public class GetClientes_Res
    {
        public bool Ok;
        public string Msg;
        public DataCollection<CreateCliente_Req> Clientes;
        public GetClientes_Res(DataCollection<CreateCliente_Req> clientes, string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
            Clientes = clientes;
        }
    }
}
