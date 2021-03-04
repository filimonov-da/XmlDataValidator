using System.Threading.Tasks;
using XmlDataValidator.BLL.Models;

namespace XmlDataValidator.BLL.Interfaces
{
    public interface ISchemaValidationService
    {
        ValidationResponse Validate(ValidationRequest validationRequest);
    }
}