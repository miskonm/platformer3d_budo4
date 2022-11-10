namespace Services.Web
{
    public class ResponseException
    {
        public string Status { get; }
        public string Message { get; }

        public ResponseException(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}