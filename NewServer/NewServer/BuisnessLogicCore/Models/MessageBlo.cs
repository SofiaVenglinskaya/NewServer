using NewServer.DataAccessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Models
{
    public class MessageBlo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserRto SenderUser { get; set; }
        public UserRto RecieverUser { get; set; }
        public DateTime DateOfSending { get; set; }
    }
}
