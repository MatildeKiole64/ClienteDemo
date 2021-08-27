namespace ClienteDemo.Core.DTOs
{
    public class GetClientes_Req
    {
        public int Page;
        public int Take;
        public GetClientes_Req(int page, int take)
        {
            Page = page;
            Take = take;
        }
    }
}
