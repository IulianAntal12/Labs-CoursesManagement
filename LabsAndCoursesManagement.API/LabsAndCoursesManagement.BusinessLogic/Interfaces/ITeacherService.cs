using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher, CreateTeacherDto>
    {
        Task<Result<Teacher>> EnrollTeacherToLabs(Guid teacherId, List<Guid> labIds);
    }
}