using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.DataAccess.Interfaces
{
    public interface ILabRepository
    {
        Task Add(Lab lab);
        Task Delete();
        Task<Lab> GetById();
        Task<IEnumerable<Lab>> GetAll();
    }
}
