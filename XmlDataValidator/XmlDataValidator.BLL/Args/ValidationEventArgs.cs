using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.Models;

namespace XmlDataValidator.BLL.Args
{
    public class ValidationEventArgs : EventArgs
    {
        public string XsdStandardVer { get; }
        public MemoryStream XsdInputStream { get; }
        public MemoryStream XmlInputStream { get; }

        public Action<ValidationMessage> XmlError { get; } 
        public ValidationEventArgs(string xsdStandardVer, MemoryStream xsdInputStream, MemoryStream xmlInputStream, Action<ValidationMessage> xmlError)
        {
            XsdStandardVer = xsdStandardVer;
            XsdInputStream = xsdInputStream;
            XmlInputStream = xmlInputStream;
            XmlError = xmlError;
        }
    }
}
