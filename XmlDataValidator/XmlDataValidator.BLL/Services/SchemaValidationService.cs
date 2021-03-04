using XmlDataValidator.BLL.BusinessModels;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.Args;
using System.IO;
using XmlDataValidator.BLL.Exceptions;

namespace XmlDataValidator.BLL.Services
{
    public class SchemaValidationService : BaseService, ISchemaValidationService
    {
        #region [Private Declaration]

        private static ISchemaCatalogue SchemaCatalogue = new SchemaCatalogue();

        #endregion

        public SchemaValidationService(ConfigurationSettings сonfigurationSettings) : base(сonfigurationSettings)
        {

        }

        public ValidationResponse Validate(ValidationRequest validationRequest)
        {
            var validationResponse = new ValidationResponse();

            var schema = SchemaCatalogue.GetSchema(validationRequest.XsdSchemaName);

            using (var xsdInputStream = new MemoryStream())
            {
                schema.XsdSchema.Write(xsdInputStream);
                xsdInputStream.Seek(0, SeekOrigin.Begin);

                using (var xmlInputStream = new MemoryStream(validationRequest.XmlDocumentBase64.GetBytesFromBase64String()))
                {
                    BusinessModels.ConfigurationSettings.Validation(this, new ValidationEventArgs(validationRequest.XsdSchemaStandard, xsdInputStream, xmlInputStream, e =>
                    {
                        validationResponse.ValidationResponseMessageList.Add(new ValidationResponseMessage(e));
                    }));
                }
            }

            return validationResponse;
        }
    }
}
