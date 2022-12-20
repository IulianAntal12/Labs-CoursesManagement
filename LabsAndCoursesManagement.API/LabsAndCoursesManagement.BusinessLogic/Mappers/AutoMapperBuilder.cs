using AutoMapper;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class AutoMapperBuilder
    {
        public IMapper Build()
        {
            return AutoMapperConfig
                .Configure()
                .CreateMapper();
        }
    }
}
