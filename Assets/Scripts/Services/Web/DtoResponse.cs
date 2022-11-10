namespace Services.Web
{
    public class DtoResponse<TDto> : Response
    {
        public TDto Dto { get; }

        public DtoResponse(TDto dto)
        {
            Dto = dto;
        }

        public DtoResponse(ResponseException exception) : base(exception) { }
    }
}