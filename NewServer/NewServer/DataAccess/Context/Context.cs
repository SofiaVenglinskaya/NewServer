using Microsoft.EntityFrameworkCore;
using NewServer.DataAccessCore.Interfaces.DbContext;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccess.Context
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext, IDbContext

    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        public DbSet<UserRto> User { get; set; }
        public DbSet<FriendsRto> Friends { get; set; }
        public DbSet<InvitationRto> Invitation { get; set; }
        public DbSet<MessageRto> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendsRto>(builder =>
           {
               builder.HasKey(a => new
               {
                   a.FirstUserId,
                   a.SecondUserId

               });
               builder
               .HasOne<UserRto>(a => a.FirstUser)
               .WithMany(a => a.FirstFriend)
               .HasForeignKey(a => a.FirstUserId)
               .IsRequired();

               builder
                .HasOne<UserRto>(a => a.SecondUser)
                .WithMany(a => a.SecondFriend)
                .HasForeignKey(a => a.SecondUserId)
                .IsRequired();

           });

            modelBuilder.Entity<InvitationRto>(builder =>
            {
                builder.HasKey(a => new
                {
                    a.SenderUserId,
                    a.RecieverUserId

               });
                builder
                .HasOne<UserRto>(a => a.SenderUser)
                .WithMany(a => a.SendingInvitation)
                .HasForeignKey(a => a.SenderUserId)
                .IsRequired();

                builder
               .HasOne<UserRto>(a => a.RecieverUser)
               .WithMany(a => a.ReceivingInvitation)
               .HasForeignKey(a => a.RecieverUserId)
               .IsRequired();

            });

           modelBuilder.Entity<MessageRto>(builder =>
            {
                //builder.HasKey(a => new
                //{
                //    a.SenderUserId,
                //    a.RecieverUserId

                //}); 

                builder
                .HasOne<UserRto>(a => a.SenderUser)
                .WithMany(a => a.SendMessage)
                .HasForeignKey(a => a.SenderUserId);

                builder
                .HasOne<UserRto>(a => a.RecieverUser)
                .WithMany(a => a.GetMessage)
                .HasForeignKey(a => a.RecieverUserId);
                
            });
            }
    }
}
