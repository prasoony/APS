﻿using Aps.Models;
using Aps.Services.IServices;
using static Aps.Utility.SD;

namespace Aps.Services
{
    public class CopounServcies : ICopounService
    {
        private readonly IBaseServices _baseServices ;
        public CopounServcies(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }

        public async Task<ResponseDto?> CreateCopounAsyn(CopounDto copounDto)
        {


            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Data =copounDto,
                Url = CouponAPIBase + "/api/copouns"
            });
        }

      

        public async Task<ResponseDto?> DeleteCopounAsyn(int id)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = CouponAPIBase + "/api/copouns/"+id
            });
        }

       

        public async Task<ResponseDto?> GetAllCopounAsyn()
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/copouns"
            });
        }

       
        public async Task<ResponseDto?> GetCopounAsyn(string CopounCode)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/copouns/GetbyCode/"+CopounCode
            });
        }

       

        public async Task<ResponseDto?> GetCopounGetIDAsyn(int id)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/copouns" +id
            });
        }

       

        public  async Task<ResponseDto?> UpdateCopounAsyn(CopounDto copounDto)
        {
            return await _baseServices.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data =copounDto,
                Url = CouponAPIBase + "/api/copouns"
            });
        }
    }
}
