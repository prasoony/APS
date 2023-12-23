using Aps.Models;
using Aps.Services.IServices;

namespace Aps.Services
{
    public class CopounServcies:ICopounService
    {
        private readonly IBaseServices _baseServices;
        public CopounServcies(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }

        Task<CopounDto?> ICopounService.CreateCopounAsyn(CopounDto copounDto)
        {
            throw new NotImplementedException();
        }

        Task<CopounDto?> ICopounService.DeleteCopounAsyn(int id)
        {
            throw new NotImplementedException();
        }

        Task<CopounDto?> ICopounService.GetAllCopounAsyn()
        {
            throw new NotImplementedException();
        }

        Task<CopounDto?> ICopounService.GetCopounAsyn(string CopounCode)
        {
            throw new NotImplementedException();
        }

        Task<CopounDto?> ICopounService.GetCopounGetIDAsyn(int id)
        {
            throw new NotImplementedException();
        }

        Task<CopounDto?> ICopounService.UpdateCopounAsyn(CopounDto copounDto)
        {
            throw new NotImplementedException();
        }
    }
}
