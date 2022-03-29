using AutoMapper;
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
    public class InvitationService : IInvitationsService

    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public InvitationService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Accept(int userId, int friendId, FriendsBlo friendsBlo)
        {
            var friendRto = await _context.Invitation
                .FirstOrDefaultAsync(e => e.RecieverUserId == userId && e.SenderUserId == friendId);
            if (friendRto == null)
                throw new BadRequestExeption($"В списке заявок пользователя с Id {userId} нет пользователя с Id{friendId}");
            FriendsRto newFriend = new FriendsRto()
            {
                SecondUser = friendsBlo.SenderUser,
                FirstUser = friendsBlo.AccepterUser

            };
            _context.Friends.Add(newFriend);
            await _context.SaveChangesAsync();
            
        }

        public async Task Deny(int userId, int friendId)
        {
            var friendD = await _context.Invitation
               .FirstOrDefaultAsync(e => e.RecieverUserId == userId && e.SenderUserId == friendId);
            if (friendD == null)
                throw new BadRequestExeption($"В списке заявок пользователя с Id {userId} нет пользователя с Id{friendId}");
            _context.Invitation.Remove(friendD);
            await _context.SaveChangesAsync();
        }

       
        public Task<int> GetNumberOfFriendInvitations(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task Request(int userId, int friendId, UserInvitationsBlo invitationsBlo)
        {
            var friendRto = await _context.Invitation
                .FirstOrDefaultAsync(e => e.RecieverUserId == friendId && e.SenderUserId == userId);
            if (friendRto == null)
                throw new BadRequestExeption($"Пользователя с Id {friendId} или {userId} не существует");
            InvitationRto newInvitation = new InvitationRto()
            {
                RecieverUser = invitationsBlo.AccepterUser,
                SenderUser = invitationsBlo.SenderUser

            };
            _context.Invitation.Add(newInvitation);
            await _context.SaveChangesAsync();
        }

        public Task<List<UserInformationBlo>> UsersThatHaveSentFriendRequest(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
