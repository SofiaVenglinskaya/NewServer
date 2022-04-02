using AutoMapper;
using NewServer.BuisnessLogicCore.Models;
using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogic
{
    public class BuisnessLogicProfile : Profile
    {
        public BuisnessLogicProfile()
        {
            CreateMap<UserRto, UserInformationBlo>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Surname, x => x.MapFrom(m => m.Surname));

            CreateMap<FriendsRto, FriendsBlo>()
                .ForMember(x => x.FirstUser, x => x.MapFrom(m => m.FirstUserId))
                .ForMember(x => x.SecondUser, x => x.MapFrom(m => m.SecondUser));

            CreateMap<InvitationRto, UserInvitationsBlo>()
                .ForMember(x => x.SenderUser, x => x.MapFrom(m => m.SenderUser))
                .ForMember(x => x.AccepterUser, x => x.MapFrom(m => m.RecieverUser));

            CreateMap<MessageRto, MessageBlo>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Text, x => x.MapFrom(m => m.Text))
                .ForMember(x => x.SenderUser, x => x.MapFrom(m => m.SenderUser))
                .ForMember(x => x.RecieverUser, x => x.MapFrom(m => m.RecieverUser))
                .ForMember(x => x.DateOfSending, x => x.MapFrom(m => m.DateOfSending));

            CreateMap<UserRto, UserIdentityBlo>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Password, x => x.MapFrom(m => m.Password));


        }
    }
}
