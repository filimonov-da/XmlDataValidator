using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.SqlServer.Server;
using XmlDataValidator.CLR.Models;
using System.Data.Linq;
using System.Xml;

public partial class UserDefinedFunctions
{
    #region [SqlXmlDataValidator]

    [SqlFunction]
    public static SqlXml SqlXmlDataValidator(SqlString url, SqlString xsdSchemaName, SqlString xmlValidationStandrard, SqlString xmlData)
    {
        var webRequest = WebRequest.Create(url.Value);
        webRequest.ContentType = "application/xml";
        webRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
        {
            var validationRequest = new ValidationRequest()
            {
                XsdSchemaName = xsdSchemaName.Value,
                XmlValidationStandard = xmlValidationStandrard.Value,
                XmlData = xmlData.Value
            };

            streamWriter.Write(validationRequest.GetXmlString());
        }

        var webResponse = webRequest.GetResponse();
        using (var stream = webResponse.GetResponseStream())
        {
            using (var reader = new StreamReader(stream))
            {
                var validationResponse = reader.ReadToEnd();

                #region MemoryStream

                //var memoryStream = new MemoryStream();

                //var xmlWriterSettings = new XmlWriterSettings();
                //xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;

                //using (var xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                //{
                //    xmlWriter.WriteString(validationResponse.ToString().Trim());
                //    return new SqlXml(memoryStream);
                //}

                #endregion

                using (var stringReader = new StringReader(validationResponse))
                {
                    using (var xmlTextReader = new XmlTextReader(stringReader))
                        return new SqlXml(xmlTextReader);
                }
            }
        }
    }

    #endregion
}
