using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories
{
    public class TenantRepository : Repository<Tenant>
    {
        public TenantRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
