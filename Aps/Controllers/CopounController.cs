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
                   return RedirectToAction(nameof(CopounIndex));

                }
            }
             
            return View(model);
        }
        [HttpDelete]
        public async Task<IActionResult> CopounDelete( int copounId)
        {
			ResponseDto? response = await _copounService.GetCopounGetIDAsyn(copounId);
			if (response != null && response.Sucsess)
			{
				CopounDto?model = JsonConvert.DeserializeObject<CopounDto>(Convert.ToString(response.Result));
                return View(model);
			}


			return NotFound();
        }
    }
}
