using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Models
{
    [DataContract]
    public class ValidationResponse
    {
        public ValidationResponse()
        {
        }

        [DataMember]
        public List<ValidationResponseMessage> ValidationResponseMessageList { get; set; } = new List<ValidationResponseMessage>();
    }
}
