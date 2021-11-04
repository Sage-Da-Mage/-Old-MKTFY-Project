﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Shared.Exceptions
{
    // All exception classes should inherit from Exception
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message)
                : base(message)
        {
            
        }



    }
}
