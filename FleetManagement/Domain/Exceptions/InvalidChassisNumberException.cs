﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidChassisNumberException : Exception
    {
        public InvalidChassisNumberException() : base() { }
        public InvalidChassisNumberException(string message) : base(message) { }
        public InvalidChassisNumberException(string message, Exception inner) : base(message, inner) { }

    }
}
