﻿using NewServer.BuisnessLogicCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Interfaces
{
    interface IInvitationsService
    {
        Task Request(int userId, int friendId, UserInvitationsBlo invitationsBlo);
        Task Accept(int userId, int friendId, FriendsBlo friendsBlo);
        Task Deny(int userId, int friendId);
        Task<int> GetNumberOfFriendInvitations(int userId);
        Task<List<UserInformationBlo>> UsersThatHaveSentFriendRequest(int userId);


    }
}
