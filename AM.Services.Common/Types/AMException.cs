using System;

namespace AM.Common.Types
{
    public class AMException : Exception
    {
        public string Code { get; }

        public AMException()
        {
        }

        public AMException(string code)
        {
            Code = code;
        }

        public AMException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public AMException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public AMException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public AMException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}