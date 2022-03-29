using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    interface IFriendsService
    {
        Task<List<FriendsBlo>> Get(int friendId);
        Task Delete(int userId, int friendId);
    }
}
