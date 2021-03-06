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
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        [HttpPost("send")]
        public async Task<ActionResult<MessageBlo>> Send(MessageBlo messageBlo)
        {
            try
            {
                MessageBlo message = await _messageService.Send(messageBlo);
                return Ok(_mapper.Map<MessageBlo>(message));
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }

            
        }
         [HttpGet("get/{userId}/{friendId}")]
         public async Task<ActionResult<List<MessageBlo>>> Get(int userId, int friendId)
        {
            List<MessageBlo> messageBlo;
            try
            {
                messageBlo = await _messageService.Get(friendId, userId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<List<MessageBlo>>(messageBlo));
        }

        [HttpPatch("change/{messageId}")]
        public async Task<ActionResult<MessageBlo>> Change([FromRoute]int messageId, [FromBody]MessageBlo messageBlo)
        {
            try
            {
                messageBlo = await _messageService.Change( messageId, messageBlo);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok(_mapper.Map<MessageBlo>(messageBlo));
        }

        [HttpDelete("delete/{messageId}")]
        public async Task<IActionResult> Delete(int messageId)
        {
            try
            {
                await _messageService.Delete(messageId);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

    }
}
