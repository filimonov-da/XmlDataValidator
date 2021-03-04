using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.Args;
using XmlDataValidator.BLL.Exceptions;
using XmlDataValidator.BLL.Models;

namespace XmlDataValidator.Service
{
    public class JavaValidator
    {
        #region [Validation]

        public static void Validation(object sender, ValidationEventArgs validationEventArgs)
        {
            var xsdSchemaStandard = validationEventArgs.XsdStandardVer;

            if ((xsdSchemaStandard != "1.0" && xsdSchemaStandard != "1.1"))
                throw new StandardVersionNotSupportedException($"Версия стандарта XSD-схемы \"{xsdSchemaStandard}\" не поддерживается.");

            var xmlDataValidator = new JavaXmlDataValidator.XmlDataSourceValidator();

            var javaXsdInputStream = new ikvm.io.InputStreamWrapper(validationEventArgs.XsdInputStream);
            var javaXmlInputStream = new ikvm.io.InputStreamWrapper(validationEventArgs.XmlInputStream);

            var javaXsdValidationType = JavaXmlDataValidator.XsdValidationType.XSD_11;

            if (xsdSchemaStandard != "1.1")
                javaXsdValidationType = JavaXmlDataValidator.XsdValidationType.XSD_10;

            var javaErrors = xmlDataValidator.Validate(javaXsdValidationType, javaXsdInputStream, javaXmlInputStream);

            foreach (var javaError in javaErrors.toArray())
            {
                var jsonError = JsonConvert.SerializeObject(javaError);

                var dyncError = JsonConvert.DeserializeObject<dynamic>(jsonError);

                //Predicate<object> hasAction = jsonObject =>
                //                     ((JObject)jsonObject).Property("Message") != null;

                //string message = hasAction(dynoError) ? dynoError.Message : null;

                var validationMessage = new ValidationMessage()
                {
                    Type = dyncError.Type,
                    Message = dyncError.Message,
                    LineNumber = dyncError.LineNumber,
                    ColumnNumber = dyncError.ColumnNumber
                };

                validationEventArgs.XmlError(validationMessage);
            }
        }

        #endregion
    }
}
