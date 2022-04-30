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
            var firstFriend = await _context.Invitation.
                AnyAsync(x => x.SenderUserId == userId);
            if (firstFriend == false)
                throw new DllNotFoundException($"Пользователя с Id {userId} не существует");
            var secondFriend = await _context.Invitation.
                AnyAsync(x => x.RecieverUserId == friendId);
            if (secondFriend == false)
                throw new DllNotFoundException($"Пользователя с Id {friendId} не существует");
            FriendsRto newFriend = new FriendsRto()
            {
                SecondUserId = friendsBlo.SecondUserId,
                FirstUserId = friendsBlo.FirstUserId

            };
            FriendsRto newfriend = new FriendsRto()
            {
                SecondUserId = friendsBlo.FirstUserId,
                FirstUserId = friendsBlo.SecondUserId

            };
            _context.Friends.Add(newFriend);
            _context.Friends.Add(newfriend);
            await _context.SaveChangesAsync();
            
        }

        public async Task Deny(int userId, int friendId)
        {
            var invitation = await _context.Invitation
                .FirstOrDefaultAsync(e => e.SenderUserId == friendId && e.RecieverUserId == userId);
            if (invitation == null)
                throw new BadRequestExeption($"В списке заявок пользователя с Id {userId} нет пользователя с Id{friendId}");
            _context.Invitation.Remove(invitation);
            await _context.SaveChangesAsync();
        }

       
        public async Task Request(int userId, int friendId, UserInvitationsBlo invitationsBlo)
        {
            var firstFriend = await _context.User.
                AnyAsync(x => x.Id == userId);
            if (firstFriend == false)
                throw new DllNotFoundException($"Пользователя с Id {userId} не существует");
            var secondFriend = await _context.User.
                AnyAsync(x => x.Id == userId);
            if (secondFriend == false)
                throw new DllNotFoundException($"Пользователя с Id {friendId} не существует");
            InvitationRto newInvitation = new InvitationRto()
            {
                RecieverUserId = invitationsBlo.AccepterUserId,
                SenderUserId = invitationsBlo.SenderUserId

            };
            _context.Invitation.Add(newInvitation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserInvitationsBlo>> UsersThatHaveSentFriendRequest(int userId, int invId)
        {
            var invitationsList = await _context.Invitation.
                Where(e => e.RecieverUserId == userId && e.SenderUserId == invId).ToListAsync();
            if (invitationsList == null) 
                throw new ArgumentNullException(nameof(invitationsList));
            List<UserInvitationsBlo> invitationsBlo = new List<UserInvitationsBlo>();
            for (int i = 0; i < invitationsList.Count; i++)
            {
                invitationsBlo.Add(_mapper.Map<UserInvitationsBlo>(invitationsList[i]));
            }
            return invitationsBlo;
        }
    }
}
