using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Exceptions
{
    public sealed class CatalogueNotFoundException : Exception
    {
        public CatalogueNotFoundException()
        {
        }

        public CatalogueNotFoundException(string message) : base(message)
        {
        }
    }
}
