using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class HomeworkRepository : Repository<Homework>
    {
        public HomeworkRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
