namespace Services.Web
{
    public class Response
    {
        public bool IsSuccess { get; }
        public ResponseException Exception { get; }

        public Response()
        {
            IsSuccess = true;
        }

        public Response(ResponseException exception)
        {
            IsSuccess = true;
            Exception = exception;
        }
    }
}