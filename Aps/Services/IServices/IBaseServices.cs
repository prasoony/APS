using Aps.Models;

namespace Aps.Services.IServices
{
    public interface IBaseServices
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
