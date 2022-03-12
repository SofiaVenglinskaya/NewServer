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
        public string UserName { get; set; }
        public UserRto SenderMessageName { get; set; }
        public DateTime DateOfSending { get; set; }


    }
}
