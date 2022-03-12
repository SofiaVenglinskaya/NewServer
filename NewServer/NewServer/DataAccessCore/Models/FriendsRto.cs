using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Models
{
    [Table("Friends")]
    public class FriendsRto
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public UserRto FriendName { get; set; }
        public string Surnames { get; set; }
        public UserRto FriendSurname { get; set; }
        public string Logins { get; set; }
        public UserRto FriendLogin { get; set; }
        public int CountOfInvitations { get; set; }



    }
}
