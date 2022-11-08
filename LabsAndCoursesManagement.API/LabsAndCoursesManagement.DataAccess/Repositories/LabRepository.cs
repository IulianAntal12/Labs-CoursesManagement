using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.DataAccess.Interfaces;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Repositories
{
    public class LabRepository : ILabRepository
    {
        private readonly DatabaseContext? DbContext;

        public LabRepository(DatabaseContext _context)
        {
            DbContext = _context;
            DbContext?.Database.EnsureCreated();
        }

        public async Task Add(Lab lab)
        {
            if (lab is not null || this.DbContext is not null)
                await DbContext.Labs.AddAsync(lab);
            else
                throw new ArgumentNullException();
            DbContext?.SaveChangesAsync();
        }

        public async Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lab>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Lab> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
