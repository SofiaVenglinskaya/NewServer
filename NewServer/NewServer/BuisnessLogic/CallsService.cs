using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewServer.BuisnessLogicCore.Models;
using NewServer.DataAccessCore.Interfaces.DbContext;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogic
{
    public class CallsService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public CallsService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<CallsBlo>> Get(int userId, int friendId)
        {
            var calls = await _context.Calls.
                Where(e => e.CallerUserId == userId && e.CalledUserId == friendId || e.CalledUserId == friendId && e.CallerUserId == userId).ToListAsync();
            if (calls == null) throw new ArgumentNullException(nameof(calls));
            List<CallsBlo> callsBlo = new List<CallsBlo>();
            for (int i = 0; i < calls.Count; i++)
            {
                callsBlo.Add(_mapper.Map<CallsBlo>(calls[i]));
            }
            return callsBlo;
        }

        public async Task<CallsBlo> Call(CallsBlo callsBlo)
        {
            CallsRto callRto = new CallsRto()
            {
                
                CallerUserId = callsBlo.CallerId!,
                CalledUserId = callsBlo.CalledId!,
                DateOfCall = callsBlo.DateOfCall

            };

            await _context.SaveChangesAsync();
            return _mapper.Map<CallsBlo>(callRto);

        }
    }
}
