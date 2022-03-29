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
    public class FriendsService : IFriendsService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public FriendsService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Delete(int userId, int friendId)
        {
            var friendD = await _context.Friends
                .FirstOrDefaultAsync(e => e.FirstUserId == userId && e.SecondUserId == friendId);
            if (friendD == null)
                throw new BadRequestExeption($"В списке друзей пользователя с Id {userId} нет пользователя с Id{friendId}");
            _context.Friends.Remove(friendD);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendsBlo>> Get(int friendId)
        {
            throw new NotImplementedException();
        }
    }
}
