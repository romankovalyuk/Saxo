namespace Saxo.Flow
{
    public class RequestInfo
    {
        public string Isbn { get; set; }

        public RequestInfo(string isbn)
        {
            Isbn = isbn;
        }
    }
}