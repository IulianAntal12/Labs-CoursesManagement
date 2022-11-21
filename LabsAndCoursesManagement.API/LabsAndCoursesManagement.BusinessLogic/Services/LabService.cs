using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public class LabService : BaseService<Lab, CreateLabDto>, ILabService
    {
        public LabService(IRepository<Lab> repository) : base(repository)
        {

        }
    }
}
