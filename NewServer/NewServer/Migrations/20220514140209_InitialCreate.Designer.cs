// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewServer.DataAccess.Context;

namespace NewServer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220514140209_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("NewServer.DataAccessCore.Models.CallsRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalledUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CallerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCall")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CalledUserId");

                    b.HasIndex("CallerUserId");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.FriendsRto", b =>
                {
                    b.Property<int>("FirstUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfInvitations")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("FirstUserId", "SecondUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.InvitationRto", b =>
                {
                    b.Property<int>("SenderUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecieverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfInvitations")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("SenderUserId", "RecieverUserId");

                    b.HasIndex("RecieverUserId");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.MessageRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfSending")
                        .HasColumnType("TEXT");

                    b.Property<int>("RecieverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecieverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.UserRto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.CallsRto", b =>
                {
                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "CalledUser")
                        .WithMany("GetCall")
                        .HasForeignKey("CalledUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "CallerUser")
                        .WithMany("ToCall")
                        .HasForeignKey("CallerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.FriendsRto", b =>
                {
                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "FirstUser")
                        .WithMany("FirstFriend")
                        .HasForeignKey("FirstUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "SecondUser")
                        .WithMany("SecondFriend")
                        .HasForeignKey("SecondUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.InvitationRto", b =>
                {
                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "RecieverUser")
                        .WithMany("ReceivingInvitation")
                        .HasForeignKey("RecieverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "SenderUser")
                        .WithMany("SendingInvitation")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewServer.DataAccessCore.Models.MessageRto", b =>
                {
                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "RecieverUser")
                        .WithMany("GetMessage")
                        .HasForeignKey("RecieverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewServer.DataAccessCore.Models.UserRto", "SenderUser")
                        .WithMany("SendMessage")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
