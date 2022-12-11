using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.BusinessLogic.Services.Validators;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using System.Net;

namespace LabsAndCoursesManagement.BusinessLogic.Services
{
    public class StudentService : BaseService<Student, CreateStudentDto>, IStudentService
    {
        private readonly IRepository<Lab> labRepository;

        public StudentService(IRepository<Student> repository, IRepository<Lab> labRepository, IValidator<Student?> validator) 
            : base(repository, validator)
        {
            this.labRepository = labRepository;
        }

        public async Task<Result<Student>> EnrollStudentToLabs(Guid studentId, List<Guid> labIds)
        {
            var labTasks = labIds
                .Select(async (labId) => await labRepository.Get(labId))
                .ToList();

            var jointTasks = (await Task.WhenAll(labTasks))
                .ToList();

            if (jointTasks.Any(lab => lab == null))
            {
                return Result<Student>.Failure(HttpStatusCode.BadRequest, "Cannot find all the specified labs");
            }

            var student = await repository.Get(studentId);
            if (student == null)
            {
                return Result<Student>.Failure(HttpStatusCode.NotFound, "Cannot find the specified student");
            }

            student.EnrollToLabs(jointTasks);
            await repository.Update(studentId, student);
            await repository.SaveChanges();
            return Result<Student>.SuccessNoEntity();
        }
    }
}
