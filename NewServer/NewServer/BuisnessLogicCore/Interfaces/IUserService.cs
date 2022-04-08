using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
   public interface IUserService
    {
        Task<UserInformationBlo> Register(UserIdentityBlo userIdentityBlo);
        Task<UserInformationBlo> Get(int userId);
        Task<UserInformationBlo> Update(UserInformationBlo userInformationBlo, UserIdentityBlo userIdentityBlo);
        Task<UserInformationBlo> Authenticate(UserIdentityBlo userIdentityBlo);
        Task Delete(int userId);
    }
}
