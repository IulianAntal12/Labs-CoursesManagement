using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Services
{
    public class CourseService : BaseService<Course, CreateCourseDto>, ICourseService
    {
        public CourseService(IRepository<Course> repository, IValidator<Course?> validator) : base(repository, validator)
        {
        }
    }
}
