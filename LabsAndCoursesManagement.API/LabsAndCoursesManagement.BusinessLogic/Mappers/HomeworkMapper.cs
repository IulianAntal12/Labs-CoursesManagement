using AutoMapper;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class HomeworkMapper
    {
        private static readonly Lazy<IMapper> Lazy =
           new(() =>
           {
               var config = new MapperConfiguration(cfg =>
               {
                   cfg.ShouldMapProperty = p =>
                   p.GetMethod.IsPublic ||
                   p.GetMethod.IsAssembly;
                   cfg.AddProfile<ReportMappingProfile>();
               });
               var mapper = config.CreateMapper();
               return mapper;
           });
        public static IMapper Mapper => Lazy.Value;
    }
}
