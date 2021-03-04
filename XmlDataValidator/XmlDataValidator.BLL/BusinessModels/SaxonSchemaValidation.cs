using Saxon.Api;
using XmlDataValidator.BLL.Exceptions;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XmlDataValidator.BLL.BusinessModels
{
    internal class SaxonSchemaValidation : ISchemaValidation
    {
        #region [Private Declaration]

        private static ISchemaCatalogue SchemaCatalogue = new SchemaCatalogue();

        #endregion

        #region [Validate]

        public void Validate(ValidationRequest validationRequest, Action<ValidationResponseMessage> validationResponseMessageAction)
        {
            var errors = new List<ValidationFailure>();
            try
            {
                var schema = SchemaCatalogue.GetSchema(validationRequest.XsdSchemaName);

                var processor = new Processor(true);
                processor.SetProperty(net.sf.saxon.lib.FeatureKeys.VALIDATION_WARNINGS, "true");

                var schemaManager = processor.SchemaManager;

                using (var ms = new MemoryStream())
                {
                    schema.XsdSchema.Write(ms);
                    ms.Position = 0;
                    schemaManager.Compile(XmlReader.Create(ms));
                }

                schemaManager.XsdVersion = validationRequest.XmlValidationStandard;
                var schemaValidator = schemaManager.NewSchemaValidator();

                using (var xr = new MemoryStream(validationRequest.XmlDataBase64.GetBytesFromBase64String()))
                {
                    try
                    {
                        schemaValidator.SetSource(XmlReader.Create(xr));

                        schemaValidator.ErrorList = errors;
                        schemaValidator.Run();
                    }
                    catch(Saxon.Api.StaticError ex)
                    {
                        validationResponseMessageAction(new ValidationResponseMessage(ex.Message));
                    }
                }

                errors.ToList().ForEach(e => validationResponseMessageAction(new ValidationResponseMessage(e.GetMessage())));
            }
            catch (net.sf.saxon.type.ValidationException)
            {
                errors.ToList().ForEach(e => validationResponseMessageAction(new ValidationResponseMessage(e.ToString())));
            }
        }

        #endregion
    }
}
