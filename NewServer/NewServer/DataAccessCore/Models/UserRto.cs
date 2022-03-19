using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Models
{
    [Table("User")]
    public class UserRto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public List<FriendsRto> FirstFriend { get; set; }
        public List<FriendsRto> SecondFriend { get; set; }

        public List<InvitationRto> SendingInvitation { get; set; }
        public List<InvitationRto> ReceivingInvitation { get; set; }
        public List<MessageRto> SendMessage { get; set; }
        public List<MessageRto> GetMessage { get; set; }
    }
}
