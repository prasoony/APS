﻿using Aps.services.api.Data;
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
    }
}
