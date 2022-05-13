using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.DataAccessCore.Models
{
    [Table("Calls")]
    public class CallsRto
    {
        public int Id { get; set; }
        public int CallerId { get; set; }
        public UserRto CallerUser { get; set; }
        public int CalledPersonId { get; set; }
        public UserRto CalledUser { get; set; }
        public DateTime DateOfCall { get; set; }
    }
}
