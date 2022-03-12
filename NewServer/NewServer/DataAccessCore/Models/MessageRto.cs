using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Models
{
    [Table("Message")]
    public class MessageRto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderUserId { get; set; }
        public UserRto SenderUser { get; set; }
        public string RecieverUserId { get; set; }
        public UserRto RecieverUser { get; set; }
        public DateTime DateOfSending { get; set; }


    }
}
