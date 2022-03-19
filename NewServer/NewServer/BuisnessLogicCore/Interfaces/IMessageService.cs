using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    interface IMessageService
    {
        Task<MessageBlo> Send(MessageBlo messageBlo);
        Task<List<MessageBlo>> Get(int userId);
        
        Task Delete(int messageId);
        Task<MessageBlo> Change(MessageBlo messageText);

    }
}
