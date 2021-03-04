using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.Exceptions;

namespace XmlDataValidator.BLL.Models
{
    [DataContract]
    public class ValidationRequest
    {
        public ValidationRequest()
        {
        }

        [DataMember]
        public string XsdSchemaName { get; set; }

        [DataMember]
        public string XsdSchemaStandard { get; set; }

        [DataMember]
        public string XmlDocumentBase64 { get; set; }
    }

    public static class StringExtension
    {
        public static byte[] GetBytesFromBase64String(this string value)
        {
            try
            {
                return Convert.FromBase64String(value);
            }
            catch(Exception)
            {
                throw new Base64DecodingException("Ошибка декодирования строки из формата Base64.");
            }
        }
    }
}
