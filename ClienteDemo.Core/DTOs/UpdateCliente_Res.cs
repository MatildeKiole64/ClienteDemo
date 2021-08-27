namespace ClienteDemo.Core.DTOs
{
    public class UpdateCliente_Res
    {
        public bool Ok;
        public string Msg;

        public UpdateCliente_Res(string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
        }
    }
}
