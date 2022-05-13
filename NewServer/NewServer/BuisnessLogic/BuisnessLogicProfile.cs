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
                
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Photo, x => x.MapFrom(m => m.Photo))
                .ForMember(x => x.Surname, x => x.MapFrom(m => m.Surname));


            CreateMap<FriendsRto, FriendsBlo>()
                .ForMember(x => x.FirstUserId, x => x.MapFrom(m => m.FirstUserId))
                .ForMember(x => x.SecondUserId, x => x.MapFrom(m => m.SecondUserId));

            CreateMap<InvitationRto, UserInvitationsBlo>()
                .ForMember(x => x.SenderUserId, x => x.MapFrom(m => m.SenderUserId))
                .ForMember(x => x.AccepterUserId, x => x.MapFrom(m => m.RecieverUserId));

            CreateMap<MessageRto, MessageBlo>()
                 .ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Text, x => x.MapFrom(m => m.Text))
                .ForMember(x => x.SenderUserId, x => x.MapFrom(m => m.SenderUserId))
                .ForMember(x => x.RecieverUserId, x => x.MapFrom(m => m.RecieverUserId))
                .ForMember(x => x.DateOfSending, x => x.MapFrom(m => m.DateOfSending));

            CreateMap<UserRto, UserIdentityBlo>()
                
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Password, x => x.MapFrom(m => m.Password));


        }
    }
}
