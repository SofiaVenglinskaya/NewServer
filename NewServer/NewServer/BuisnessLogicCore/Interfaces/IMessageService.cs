using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
   public interface IMessageService
    {
        Task<MessageBlo> Send(MessageBlo messageBlo);
        Task<List<MessageBlo>> Get(int userId, int friendId);
        
        Task Delete(int messageId);
        Task<MessageBlo> Change( int messageId,MessageBlo messageBlo);

    }
}
