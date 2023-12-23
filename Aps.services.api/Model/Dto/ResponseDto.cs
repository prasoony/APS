namespace Aps.services.api.Model.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Sucsess { get; set; } = true;

        public string Message { get; set; } = "";
    }
}
