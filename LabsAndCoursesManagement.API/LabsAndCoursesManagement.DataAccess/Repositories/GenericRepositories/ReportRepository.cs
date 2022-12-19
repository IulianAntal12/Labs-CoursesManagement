using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class ReportRepository : Repository<Report>
    {
        public ReportRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
