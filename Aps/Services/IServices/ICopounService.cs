using Aps.Models;

namespace Aps.Services.IServices
{
    public interface ICopounService
    {
        Task<CopounDto?> GetCopounAsyn(string CopounCode);
        Task<CopounDto?> GetAllCopounAsyn();
        Task<CopounDto?> GetCopounGetIDAsyn( int id );
        Task<CopounDto?> CreateCopounAsyn(CopounDto copounDto);
        Task<CopounDto?> DeleteCopounAsyn(int id );
        Task<CopounDto?> UpdateCopounAsyn(CopounDto copounDto);
    }
}
