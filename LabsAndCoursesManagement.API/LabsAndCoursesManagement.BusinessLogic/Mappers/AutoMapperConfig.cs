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
                cfg.AddProfile(new UserMapper());
                cfg.AddProfile(new LabMapper());
                cfg.AddProfile(new StudentMapper());
                cfg.AddProfile(new CourseMapper());
                cfg.AddProfile(new HomeworkMapperProfile());
                cfg.AddProfile(new ReportMappingProfile());
                cfg.AddCollectionMappers();
            }
            );
            return config;
        }
    }
}
