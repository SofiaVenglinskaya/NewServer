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
    public class InvitationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvitationsService _invitationsService;

        public InvitationController(IMapper mapper, IInvitationsService invitationsService)
        {
            _mapper = mapper;
            _invitationsService = invitationsService;
        }

        [HttpPost("accept")]
        public async Task<ActionResult> Accept(int userId, int friendId, FriendsBlo friendsBlo)
        {
            try
            {
                await _invitationsService.Accept(userId, friendId, friendsBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }

            return Created("", "");
        }

        [HttpPost("request")]
        public new async Task<ActionResult> Request(int userId, int friendId, UserInvitationsBlo invitationsBlo)
        {
            try
            {
                await _invitationsService.Request(userId, friendId, invitationsBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }

            return Created("", "");
        }

        [HttpGet("usersrequests")]
        public async Task<ActionResult<List<UserInvitationsBlo>>> UsersThatHaveSentFriendRequest(int userId, int friendId)
        {
            List<UserInvitationsBlo> invitationsBlo;
            try
            {
                invitationsBlo = await _invitationsService.UsersThatHaveSentFriendRequest(userId, friendId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<UserInvitationsBlo>(invitationsBlo));
        }

        [HttpDelete("deny")]
        public async Task<ActionResult> Deny(int userId, int friendId)
        {
            try
            {
                await _invitationsService.Deny(userId, friendId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(0);

        }
    }
}
