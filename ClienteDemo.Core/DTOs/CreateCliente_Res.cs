namespace ClienteDemo.Core.DTOs
{
    public class CreateCliente_Res
    {
        public bool Ok;
        public string Msg;

        public CreateCliente_Res(string msg, bool ok)
        {
            Ok = ok;
            Msg = msg;
        }
    }
}