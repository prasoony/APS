using Aps.Models;
using Aps.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Aps.Utility.SD;

namespace Aps.Services
{
    public class BaseServices:IBaseServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseServices( IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {


                HttpClient client = _httpClientFactory.CreateClient("Aps");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "Application/json");
                }
                HttpResponseMessage? ApiResponse = null;
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                ApiResponse = await client.SendAsync(message);

                switch (ApiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Sucsess = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { Sucsess = false, Message = "Access denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { Sucsess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { Sucsess = false, Message = "Internal Server Error" };
                    default:
                        var apicontent = await ApiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
                        return apiResponseDto;


                }
            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message,
                    Sucsess = false


                };
                return dto;
            }

        }
    }
}
