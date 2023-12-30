using Aps.services.api.Data;
using Aps.services.api.Model;
using Aps.services.api.Model.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aps.services.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CopounApiController : ControllerBase
    {
        private readonly AppDbcontext _db;
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public CopounApiController(AppDbcontext db ,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }


        [HttpGet]
        public ResponseDto get()
        {
            try
            {
                IEnumerable<Copoun> objlist = _db.Copouns.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CopounDto>>(objlist);
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto get(int id)
        {
            try
            {
                Copoun objlist = _db.Copouns.First(u => u.CopounId==id);
                _responseDto.Result = _mapper.Map<CopounDto>(objlist); 
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message =ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string Code)
        {
            try
            {
                Copoun objlist = _db.Copouns.First(u => u.CopounCode.ToLower() == Code.ToLower());
                _responseDto.Result = _mapper.Map<CopounDto>(objlist);
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        public ResponseDto Post([FromBody] CopounDto copounDto)
        {
            try
            {
                Copoun obj = _mapper.Map<Copoun>(copounDto);
                _db.Add(obj);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CopounDto>(obj);
 
            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] CopounDto copounDto)
        {
            try
            {
                Copoun obj = _mapper.Map<Copoun>(copounDto);
                _db.Update(obj);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CopounDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpDelete]
		[Route("{id:int}")]
		public ResponseDto Delete(int id)
        {
            try
            {
                Copoun objlist = _db.Copouns.First(u => u.CopounId == id);
                _db.Remove(objlist);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.Sucsess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


    
    }
}
