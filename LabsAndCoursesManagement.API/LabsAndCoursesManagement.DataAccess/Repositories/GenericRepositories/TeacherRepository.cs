using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class TeacherRepository: Repository<Teacher>
    {
        public TeacherRepository(DatabaseContext context) : base(context)
        {

        }

        public async override Task<IEnumerable<Teacher>> All()
        {
            CheckDatabaseContextStatus();
            return await context.Teachers.Include(s => s.Labs)
                .ToListAsync();
        }
    }
}
