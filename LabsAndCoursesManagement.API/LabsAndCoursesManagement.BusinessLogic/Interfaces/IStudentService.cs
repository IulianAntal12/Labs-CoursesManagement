using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public interface IStudentService: IBaseService<Student, CreateStudentDto>
    {
        Task<Result<Student>> EnrollStudentToLabs(Guid studentId, List<Guid> labIds);
    }
}