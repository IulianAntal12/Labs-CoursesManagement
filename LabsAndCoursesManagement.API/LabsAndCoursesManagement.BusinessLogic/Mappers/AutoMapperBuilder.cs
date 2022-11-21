using AutoMapper;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class AutoMapperBuilder : IBuilder<IMapper>
    {
        public IMapper Build()
        {
            return AutoMapperConfig
                .Configure()
                .CreateMapper();
        }
    }
}
