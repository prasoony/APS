using static Aps.Utility.SD;

namespace Aps.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }

        public string Accesstoken { get; set; }

    }
}
