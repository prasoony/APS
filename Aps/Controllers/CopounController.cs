using Aps.Models;
using Aps.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aps.Controllers
{
    public class CopounController(ICopounService copounService) : Controller
    {

        private  ICopounService _copounService = copounService;

        public async Task<IActionResult> CopounIndex()
        {
            List<CopounDto> list = new();
            ResponseDto? response = await _copounService.GetAllCopounAsyn();
            if(response!=null && response.Sucsess)
            {
                list = JsonConvert.DeserializeObject<List<CopounDto>>(Convert.ToString(response.Result));
				
			}
            else
            {
                TempData["error"] = response?.Message;        
            }

            return View(list);
        }

        public async Task<IActionResult>CopounCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CopounCreate( CopounDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _copounService.CreateCopounAsyn(model);
                if (response != null && response.Sucsess)
                {
					TempData["success"] = "Coupon Create Successfully";
					return RedirectToAction(nameof(CopounIndex));
					
				}
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
             
            return View(model);
        }
       		
		public async Task<IActionResult> CopounDelete( int CopounId)
        {
			ResponseDto? response = await _copounService.GetCopounGetIDAsyn(CopounId);
			if (response != null && response.Sucsess)
			{
				CopounDto?model = JsonConvert.DeserializeObject<CopounDto>(Convert.ToString(response.Result));
                return View(model);
				
			}

            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

		[HttpPost]
		public async Task<IActionResult> CopounDelete(CopounDto copounDto)
		{
			ResponseDto? response = await _copounService.DeleteCopounAsyn(copounDto.CopounId);
			if (response != null && response.Sucsess)
			{
				TempData["success"] = "Coupon deleted successfully";
				return RedirectToAction(nameof(CopounIndex));
			}
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(copounDto);
		}
	}
}
