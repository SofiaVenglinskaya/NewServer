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

        public List<FriendsRto> UsersFriends { get; set; }
        public List<InvitationRto> UsersInvitations { get; set; }
        public List<MessageRto> UsersMessages { get; set; }
    }
}
