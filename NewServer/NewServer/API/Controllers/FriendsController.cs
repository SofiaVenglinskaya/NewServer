
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
    public class FriendsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFriendsService _friendsService;

        public FriendsController(IMapper mapper, IFriendsService friendsService)
        {
            _mapper = mapper;
            _friendsService = friendsService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<FriendsBlo>>> Get(int userId, int friendId)
        {
            List<FriendsBlo> friendsBlo;
            try
            {
                friendsBlo = await _friendsService.Get(userId, friendId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<FriendsBlo>(friendsBlo));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int userId, int friendId)
        {
            try
            {
                await _friendsService.Delete(userId, friendId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok();

        }
    }
}
