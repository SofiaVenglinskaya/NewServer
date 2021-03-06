using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewServer.API.Exeptions;
using NewServer.API.Models;
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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserIdentityBlo>> Register(UserIdentityBlo userIdentityBlo)
        {
            UserInformationBlo userInformationBlo;
            try
            {
                userInformationBlo = await _userService.Register(userIdentityBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }

            return Created("", _mapper.Map<UserInformationBlo>(userInformationBlo));
        }

        [HttpPatch("update")]
        public async Task<ActionResult<UserInformationBlo>> Update( UserInformationBlo userInformationBlo)
        {
            try
            {
                userInformationBlo = await _userService.Update( userInformationBlo);
            }
            catch(BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Created("", _mapper.Map<UserInformationBlo>(userInformationBlo));
        }

        [HttpGet("get/{userId}")]
        public async Task<ActionResult<UserInformationBlo>> Get(int userId)
        {
            UserInformationBlo userInformationBlo;
            try
            {
                userInformationBlo = await _userService.Get(userId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok( _mapper.Map<UserInformationBlo>(userInformationBlo));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                await _userService.Delete(userId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
                
            }
            return Ok();
            
        }
        [HttpPost("auth")]
        public async Task<ActionResult<UserInformationBlo>> AuthAuthenticate( [FromBody]UserIdentityBlo userIdentityBlo)
        {
            UserInformationBlo userInformationBlo;
            try
            {
                userInformationBlo = await _userService.Authenticate( userIdentityBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<UserInformationBlo>(userInformationBlo));
        }

    }
}
