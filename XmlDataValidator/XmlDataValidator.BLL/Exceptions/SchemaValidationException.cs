using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Exceptions
{
    public sealed class SchemaValidationException : Exception
    {
        public SchemaValidationException()
        {
        }

        public SchemaValidationException(string message) : base(message)
        {
        }
    }
}
