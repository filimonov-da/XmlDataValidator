using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Exceptions
{
    public sealed class SchemaNotFoundException : Exception
    {
        public SchemaNotFoundException()
        {
        }

        public SchemaNotFoundException(string message) : base(message)
        {
        }
    }
}
