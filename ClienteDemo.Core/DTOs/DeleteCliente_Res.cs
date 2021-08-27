namespace ClienteDemo.Core.DTOs
{
    public class DeleteCliente_Res
    {
        public bool Ok;
        public string Msg;
        public DeleteCliente_Res(string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
        }
    }
}
