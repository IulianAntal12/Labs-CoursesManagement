using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class LabRepository : Repository<Lab>
    {
        public LabRepository(DatabaseContext context) : base(context)
        { }
        public override async Task<Lab?> Add(Lab entity)
        {
            var teacher = await context.Students.FindAsync(entity.TeacherId);
            if (teacher == null)
            {
                return null;
            }
            
            teacher.EnrollToLabs(new List<Lab>() { entity });
            await context.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public override async Task<IEnumerable<Lab>> All()
        {
            return await context.Labs
                .Include(lab => lab.Students)
                .Include(lab => lab.Teacher)
                .ToListAsync();  
        }
    }
}
