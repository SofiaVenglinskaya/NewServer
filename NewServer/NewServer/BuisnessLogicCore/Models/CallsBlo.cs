using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.BuisnessLogicCore.Models
{
    public class CallsBlo
    {
        public int? Id { get; set; }
        public int CallerId { get; set; }
        public int CalledId { get; set; }
        public DateTime DateOfCall { get; set; }
    }
}
