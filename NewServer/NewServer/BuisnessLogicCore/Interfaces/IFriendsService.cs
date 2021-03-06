using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    public interface IFriendsService
    {
        Task<List<FriendsBlo>> Get(int friendId, int userId);
        Task Delete(int userId, int friendId);
    }
}
