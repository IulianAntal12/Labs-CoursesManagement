using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher, CreateTeacherDto>
    {
        void Update();

        Task<Result<Teacher>> EnrollTeacherToLabs(Guid teacherId, List<Guid> labIds);
    }
}