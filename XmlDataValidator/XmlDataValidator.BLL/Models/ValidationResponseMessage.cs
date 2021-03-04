using System.Runtime.Serialization;

namespace XmlDataValidator.BLL.Models
{
    [DataContract]
    public class ValidationResponseMessage
    {
        public ValidationResponseMessage()
        {
        }

        public ValidationResponseMessage(ValidationMessage validationMessage)
        {
            Type = validationMessage.Type;
            Message = validationMessage.Message;
            LineNumber = validationMessage.LineNumber;
            ColumnNumber = validationMessage.ColumnNumber;
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