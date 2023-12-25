using Aps.Models;
using Aps.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    }
}
