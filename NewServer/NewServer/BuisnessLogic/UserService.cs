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
    public class UserService : IUserService


    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public UserService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserInformationBlo> Authenticate(UserIdentityBlo userIdentityBlo)
        {
            UserRto? user = await _context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login.ToLower() == userIdentityBlo.Login!.ToLower() && x.Password == userIdentityBlo.Password!);
            if (user == null)
                throw new BadRequestExeption("Неверный пароль или логин");
            UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(user);
            return userInformationBlo;

        }

        public async Task<UserInformationBlo> Get(int userId)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(e => (e.Id == userId));
            if (user == null)
                throw new BadRequestExeption($"Пользователя с Id {userId} не существует");
            UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(user);
            return userInformationBlo;


        }

        public async Task MarkAsDeleted(int userId)
        {
            var userRto = await _context.User
                .FirstOrDefaultAsync(e => (e.Id == userId));
            if (userRto == null)
                throw new BadRequestExeption($"Пользователя с Id {userId} не существует");
            _context.User.Remove(userRto);
            await _context.SaveChangesAsync();
            
        }

        public async Task<UserIdentityBlo> Register(UserIdentityBlo userIdentityBlo)
        {
            if (await _context.User.AnyAsync(x => x.Login.ToLower() == userIdentityBlo.Login!.ToLower()))
                throw new BadRequestExeption($"Пользователь с логином {userIdentityBlo.Login} уже существует");
            UserRto userRto = new UserRto()
            {
                Login = userIdentityBlo.Login!,
                Password = userIdentityBlo.Password!
                

            };
            _context.User.Add(userRto);
            await _context.SaveChangesAsync();
            return userIdentityBlo;

        }

        public async Task<UserInformationBlo> Update(UserInformationBlo userInformationBlo, UserIdentityBlo userIdentityBlo)
        {
            UserRto? user = await _context.User
               
                .FirstOrDefaultAsync(x => x.Login.ToLower() == userInformationBlo.Login!.ToLower());
            
            user.Login = userInformationBlo.Login == null ? user.Login : userInformationBlo.Login;
            user.Name = userInformationBlo.Name == null ? user.Name : userInformationBlo.Name;
            user.Password = userIdentityBlo.Password == null ? user.Password : userIdentityBlo.Password;

            await _context.SaveChangesAsync();
            UserInformationBlo userInformation = _mapper.Map<UserInformationBlo>(user);
            return userInformation;
        }
    }
}
