using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    interface IInvitationsService
    {
        Task Request(UserInvitationsBlo userInvitationsBlo);
        Task<UserInvitationsBlo> Get(int senderUserId);
        Task Accept(UserInvitationsBlo userInvitationsBlo);
        Task Deny(UserInvitationsBlo userInvitationsBlo);
        Task<int> GetNumberOfFriendInvitations(int userId);
        Task<List<UserInformationBlo>> UsersThatHaveSentFriendRequest(int userId);


    }
}
