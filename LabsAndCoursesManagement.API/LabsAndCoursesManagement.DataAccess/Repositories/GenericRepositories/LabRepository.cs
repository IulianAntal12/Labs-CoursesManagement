using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class LabRepository : Repository<Lab>
    {
        public LabRepository(DatabaseContext context) : base(context)
        { }
        public override async Task<Lab> Add(Lab entity)
        {
            var teacher = await context.Teachers.FindAsync(entity.TeacherId);
            if (teacher == null)
            {
                return null;
            }
            
            teacher.EnrollToLabs(new List<Lab>() { entity });
            await context.AddAsync(entity);
            await SaveChanges();
            return entity;
        }
    }
}
