using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class CourseRepository: Repository<Course>
    {
        public CourseRepository(DatabaseContext context): base(context)
        {

        }
    }
}
