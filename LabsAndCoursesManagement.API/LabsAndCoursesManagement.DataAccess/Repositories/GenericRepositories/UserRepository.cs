using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Models;
using System.Data.Entity;

namespace LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {

    }

    public async Task<User> GetByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

}