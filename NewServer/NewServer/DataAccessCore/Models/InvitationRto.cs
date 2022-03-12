using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Models
{
    [Table("Invitation")]
    public class InvitationRto
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public UserRto SenderName { get; set; }
        public string Surnames { get; set; }
        public UserRto SenderSurname { get; set; }
        public string Logins { get; set; }
        public UserRto SenderLogin { get; set; }
        public int CountOfInvitations { get; set; }
    }
}
