using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public interface ICourseService : IBaseService<Course, CreateCourseDto>
    {

    }
}
