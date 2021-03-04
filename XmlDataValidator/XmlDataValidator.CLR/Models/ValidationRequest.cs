using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace XmlDataValidator.CLR.Models
{
    [XmlRoot("ValidationRequest")]
    public class ValidationRequest
    {
        [XmlElement("XsdSchemaName")]
        public string XsdSchemaName { get; set; }

        [XmlElement("XmlValidationStandard")]
        public string XmlValidationStandard { get; set; }

        public string XmlData
        {
            set
            {
                XmlDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }
        }

        [XmlElement("XmlDataBase64")]
        public string XmlDataBase64 { get; set; }
    }

    public static class ValidationRequestExtension
    {
        #region [GetXmlString]

        public static string GetXmlString(this ValidationRequest validationRequest)
        {
            var serializer = new XmlSerializer(typeof(ValidationRequest));

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, validationRequest);

                var xmlString = Encoding.Default.GetString(ms.ToArray());

                return xmlString;
            }
        }

        #endregion
    }
}
