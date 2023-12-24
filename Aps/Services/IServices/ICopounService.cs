using Aps.Models;

namespace Aps.Services.IServices
{
    public interface ICopounService
    {
        Task<ResponseDto?> GetCopounAsyn(string CopounCode);
        Task<ResponseDto?> GetAllCopounAsyn();
        Task<ResponseDto?> GetCopounGetIDAsyn( int id );
        Task<ResponseDto?> CreateCopounAsyn(CopounDto copounDto);
        Task<ResponseDto?> DeleteCopounAsyn(int id );
        Task<ResponseDto?> UpdateCopounAsyn(CopounDto copounDto);
    }
}
