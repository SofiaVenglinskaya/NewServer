using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewServer.API.Exeptions
{
    public class BadRequestExeption : Exception 
    {
        public BadRequestExeption(string message) : base(message)
        {

        }
    }

    
}
