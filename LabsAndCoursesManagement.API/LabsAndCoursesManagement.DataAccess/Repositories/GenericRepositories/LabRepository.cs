using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class LabRepository : Repository<Lab>
    {
        public LabRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
