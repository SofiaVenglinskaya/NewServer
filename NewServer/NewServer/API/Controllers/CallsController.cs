
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewServer.API.Exeptions;
using NewServer.BuisnessLogicCore.Interfaces;
using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICallsService _callsService;

        public CallsController(IMapper mapper, ICallsService callsService)
        {
            _mapper = mapper;
            _callsService = callsService;
        }

        [HttpPost("call")]
        public async Task<ActionResult<CallsBlo>> Send(CallsBlo callsBlo)
        {
            try
            {
                CallsBlo call = await _callsService.Send(callsBlo);
                return Ok(_mapper.Map<MessageBlo>(call));
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpGet("get/{userId}/{friendId}")]
        public async Task<ActionResult<List<CallsBlo>>> Get(int userId, int friendId)
        {
            List<CallsBlo> callsBlo;
            try
            {
                callsBlo = await _callsService.Get(friendId, userId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<List<CallsBlo>>(callsBlo));
        }
    }
}
