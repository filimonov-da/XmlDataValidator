using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Exceptions
{

    [Serializable]
    public sealed class Base64DecodingException : Exception
    {
        public Base64DecodingException() { }
        public Base64DecodingException(string message) : base(message) { }
        public Base64DecodingException(string message, Exception inner) : base(message, inner) { }
        protected Base64DecodingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
