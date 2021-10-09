namespace ClienteDemo.Core.DTOs
{
    public class RemoveCliente_Res
    {
        public bool Ok;
        public string Msg;
        public RemoveCliente_Res(string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
        }
    }
}
