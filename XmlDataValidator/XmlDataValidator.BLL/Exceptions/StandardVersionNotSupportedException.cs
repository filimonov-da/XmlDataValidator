using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Exceptions
{
    public sealed class StandardVersionNotSupportedException : Exception
    {
        public StandardVersionNotSupportedException()
        {
        }

        public StandardVersionNotSupportedException(string message) : base(message)
        {
        }
    }
}
