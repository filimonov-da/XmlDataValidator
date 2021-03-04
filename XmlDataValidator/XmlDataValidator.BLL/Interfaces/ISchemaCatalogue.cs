using XmlDataValidator.BLL.BusinessModels;

namespace XmlDataValidator.BLL.Interfaces
{
    internal interface ISchemaCatalogue
    {
        void AddSchema(Schema schema);
        Schema GetSchema(string name);
    }
}