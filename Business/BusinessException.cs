using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    [Serializable]
    public class BusinessException : Exception
    {
        public string ResourceReferenceProperty { get; set; }

        public BusinessException()
            : base() { }

        public BusinessException(string message)
            : base(message) { }

        public BusinessException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException) { }

        public BusinessException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }
}