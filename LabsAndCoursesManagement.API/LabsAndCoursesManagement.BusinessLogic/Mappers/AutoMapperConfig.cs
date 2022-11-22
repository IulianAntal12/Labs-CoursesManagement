using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TeacherMapper());
                cfg.AddProfile(new LabMapper());
                cfg.AddCollectionMappers();
            }
            );
            return config;
        }
    }
}
