using AutoMapper;
using XmlDataValidator.BLL.AutoMapper;

namespace XmlDataValidator.WebApi
{
    public class AutoMapperConfig
    {
        public static void Initialize() => Mapper.Initialize((config) => config.AddProfile<MappingProfiles>());
    }
}
