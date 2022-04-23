using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Models
{
    public class UserInvitationsBlo
    {
        public int SenderUserId { get; set; }
        public int AccepterUserId { get; set; }
    }
}
