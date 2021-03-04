using System;
using XmlDataValidator.BLL.Args;
using XmlDataValidator.BLL.Models;

namespace XmlDataValidator.BLL.Interfaces
{
    internal interface ISchemaValidation
    {
        void Validate(ValidationRequest validationRequest, Action<ValidationEventArgs> validation, Action<ValidationResponseMessage> validationResponseMessageAction);
    }
}