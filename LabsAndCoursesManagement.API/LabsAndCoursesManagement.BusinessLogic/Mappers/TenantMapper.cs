using AutoMapper;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class TenantMapper
    {
        protected TenantMapper() { }
        private static readonly Lazy<IMapper> Lazy =
           new(() =>
           {
               var config = new MapperConfiguration(cfg =>
               {
                   cfg.ShouldMapProperty = p =>
                   p.GetMethod.IsPublic ||
                   p.GetMethod.IsAssembly;
                   cfg.AddProfile<TenantMapperProfile>();
               });
               var mapper = config.CreateMapper();
               return mapper;
           });
        public static IMapper Mapper => Lazy.Value;
    }
}
