﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewServer.API.Exeptions;
using NewServer.BuisnessLogicCore.Interfaces;
using NewServer.BuisnessLogicCore.Models;
using NewServer.DataAccessCore.Interfaces.DbContext;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogic
{
    
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public MessageService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPatch("change")]
        public async Task<MessageBlo> Change(MessageBlo messageBlo)
        {
            MessageRto message = await _context.Message
                .FirstOrDefaultAsync(x => x.Text == messageBlo.Text);

            message.Text = messageBlo.Text == null ? message.Text : messageBlo.Text;
            MessageBlo messageText = _mapper.Map<MessageBlo>(message);
            return messageBlo;
        }
        [HttpDelete("delete")]
        public async Task Delete(int messageId)
        {
            var message = await _context.Message
                .FirstOrDefaultAsync(e => (e.Id == messageId));
            if (message == null)
                throw new BadRequestExeption($"Сообщение не существует");
            _context.Message.Remove(message);
            await _context.SaveChangesAsync();
        }
        [HttpGet("get")]
        public async Task<List<MessageBlo>> Get(int userId, int friendId)
        {
            var messages = await _context.Message.
                Where(e => e.RecieverUserId == userId && e.SenderUserId == friendId).ToListAsync();
            if (messages == null || messages.Count < 1) throw new ArgumentNullException(nameof(messages));
            List<MessageBlo> messagesBlo = new List<MessageBlo>();
            for (int i = 0; i < messages.Count; i++)
            {
                messagesBlo.Add(_mapper.Map<MessageBlo>(messages[i]));
            }
            return messagesBlo;
        }
        [HttpPost("send")]
        public async Task<MessageBlo> Send(MessageBlo messageBlo)
        {
            MessageRto messageRto = new MessageRto()
            {
                Text = messageBlo.Text!,
                SenderUser = messageBlo.SenderUser!,
                RecieverUser = messageBlo.RecieverUser!,
                DateOfSending = messageBlo.DateOfSending

            };
            if (messageBlo.Text == null)
                throw new BadRequestExeption($"Сообщение пустое");
            _context.Message.Add(messageRto);
            await _context.SaveChangesAsync();
            return messageBlo;
        }
    }
}
