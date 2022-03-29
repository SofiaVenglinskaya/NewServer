using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Models
{
    public class FriendsBlo
    {

        public UserRto SenderUser { get; set; }
        public UserRto AccepterUser { get; set; }
    }
}
