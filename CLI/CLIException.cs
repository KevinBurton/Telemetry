﻿using System;

namespace CLI
{
    public class CLIException : Exception
    {
        public CLIException()
        {
        }

        public CLIException(string message)
            : base(message)
        {
        }

        public CLIException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
