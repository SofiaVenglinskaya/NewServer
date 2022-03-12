using Microsoft.EntityFrameworkCore;
using NewServer.DataAccessCore.Interfaces.DbContext;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccess.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext

    {
        public DbSet<UserRto> User { get; set; }
        public DbSet<FriendsRto> Friends { get; set; }
        public DbSet<InvitationRto> Invitation { get; set; }
        public DbSet<MessageRto> Messages { get; set; }
    }
}
