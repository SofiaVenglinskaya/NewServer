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

        [HttpPost("accept/{userId}/{friendId}")]
        public async Task<IActionResult> Accept([FromRoute]int userId, [FromRoute]int friendId, [FromBody]FriendsBlo friendsBlo)
        {
            try
            {
                await _invitationsService.Accept(userId, friendId, friendsBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok();

        }

        [HttpPost("request/{userId}/{friendId}")]
        public new async Task<IActionResult> Request([FromRoute]int userId, [FromRoute]int friendId, [FromBody]UserInvitationsBlo invitationsBlo)
        {
            try
            {
                await _invitationsService.Request(userId, friendId, invitationsBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet("usersrequests/{userId}/{invId}")]
        public async Task<ActionResult<List<UserInvitationsBlo>>> UsersThatHaveSentFriendRequest(int userId, int invId)
        {
            List<UserInvitationsBlo> invitationsBlo;
            try
            {
                invitationsBlo = await _invitationsService.UsersThatHaveSentFriendRequest(userId, invId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<List<UserInvitationsBlo>>(invitationsBlo));
        }

        [HttpDelete("deny/{userId}/{friendId}")]
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
            return Ok();
        }
    }
}
