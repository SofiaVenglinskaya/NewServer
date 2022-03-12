using Microsoft.EntityFrameworkCore;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Interfaces.DbContext
{
    public interface IDbContext: IDisposable, IAsyncDisposable
    {
         DbSet<UserRto> User { get; set; }
         DbSet<FriendsRto> Friends { get; set; }
         DbSet<InvitationRto> Invitation { get; set; }
         DbSet<MessageRto> Messages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
