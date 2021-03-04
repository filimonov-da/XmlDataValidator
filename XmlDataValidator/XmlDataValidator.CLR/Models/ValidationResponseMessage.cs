using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlDataValidator.CLR.Models
{
    public class ValidationResponseMessage
    {
        [XmlElement("Text")]
        public string Text { get; set; }
    }
}
