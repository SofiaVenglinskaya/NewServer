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
        public int FirstUserId { get; set; }
        public UserRto FirstUser { get; set; }
        public string SecondUserId { get; set; }
        public UserRto SecondUser { get; set; }

        public int CountOfInvitations { get; set; }



    }
}
