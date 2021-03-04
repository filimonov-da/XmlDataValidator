using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data.Linq;
using System.Collections;
using System.Xml.Serialization;

namespace XmlDataValidator.CLR.Models
{
    [XmlRoot("ValidationResponse")]
    public class ValidationResponse
    {
        [XmlArray("ValidationResponseMessageList")]
        [XmlArrayItem("ValidationResponseMessage")]
        public List<ValidationResponseMessage> ValidationResponseMessageList { get; set; } = new List<ValidationResponseMessage>();
    }
}
