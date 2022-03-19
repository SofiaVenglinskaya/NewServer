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
        public int SenderUserId { get; set; }
        public UserRto SenderUser { get; set; }
        public int RecieverUserId { get; set; }
        public UserRto RecieverUser { get; set; }
        public int CountOfInvitations { get; set; }
    }
}
