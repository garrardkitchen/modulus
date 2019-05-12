using System;

namespace Modulus.api.Exceptions
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