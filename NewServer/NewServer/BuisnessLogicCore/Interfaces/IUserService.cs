using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    interface IUserService
    {
        Task<UserIdentityBlo> Register(UserIdentityBlo userIdentityBlo);
        Task<UserInformationBlo> Get(int userId);
        Task<UserInformationBlo> Update(UserInformationBlo userInformationBlo);
        Task<UserInformationBlo> Authenticate(UserIdentityBlo userIdentityBlo);
        Task MarkAsDeleted(int userId);
    }
}
