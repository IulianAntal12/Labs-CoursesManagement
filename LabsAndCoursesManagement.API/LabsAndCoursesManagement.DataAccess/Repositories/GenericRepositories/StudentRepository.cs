using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class StudentRepository: Repository<Student>
    {
        public StudentRepository(DatabaseContext context): base(context)
        {

        }
    }
}
