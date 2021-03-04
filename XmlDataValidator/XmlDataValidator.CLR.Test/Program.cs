using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace XmlDataValidator.CLR.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://192.168.1.59:9000/api/validate";
            var xsdSchemaName = "AttractRegistration";
            var xmlValidationStandard = "1.1";
            var xmlData = "<Hi>123</Hi>";

            var response = UserDefinedFunctions.SqlXmlDataValidator(url, xsdSchemaName, xmlValidationStandard, xmlData);
        }
    }
}
