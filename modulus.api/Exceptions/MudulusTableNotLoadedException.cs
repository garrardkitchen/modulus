using System;

namespace Modulus.Api.Exceptions
{
    public class MudulusTableNotLoadedException : Exception
    {
        public MudulusTableNotLoadedException()
        {
        }

        public MudulusTableNotLoadedException(string message) : base (message)
        {
        }
    }
}