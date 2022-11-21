using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class TeacherRepository: Repository<Teacher>
    {
        public TeacherRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
