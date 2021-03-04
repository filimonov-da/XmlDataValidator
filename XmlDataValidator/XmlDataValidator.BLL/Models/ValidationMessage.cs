using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace XmlDataValidator.BLL.Models
{
    [DataContract]
    public class ValidationMessage
    {
        public ValidationMessage()
        {
        }

        public ValidationMessage(string type, string message, int lineNumber, int columnNumber)
        {
            Type = type;
            Message = message;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }

        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int LineNumber { get; set; }
        [DataMember]
        public int ColumnNumber { get; set; }
    }
}
