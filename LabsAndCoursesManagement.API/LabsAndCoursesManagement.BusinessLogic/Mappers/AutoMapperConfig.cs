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
                cfg.AddCollectionMappers();
            }
            );
            return config;
        }
    }
}
