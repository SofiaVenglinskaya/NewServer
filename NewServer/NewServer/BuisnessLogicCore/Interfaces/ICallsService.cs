using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    public interface ICallsService
    {
        Task<CallsBlo> Send(CallsBlo callsBlo);
        Task<List<CallsBlo>> Get(int userId, int friendId);
    }
}
