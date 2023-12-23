namespace Aps.Models
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Sucsess { get; set; } = true;

        public string Message { get; set; } = "";
    }
}
