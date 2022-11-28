using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Services
{
    public class StudentService : BaseService<Student, CreateStudentDto>, IStudentService
    {
        private readonly IRepository<Lab> labRepository;

        public StudentService(IRepository<Student> repository, IRepository<Lab> labRepository) : base(repository)
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
                return Result<Student>.Failure("Cannot enroll student to the specified labs");
            }

            var student = await repository.Get(studentId);
            if (student == null)
            {
                return Result<Student>.Failure("Student with specified id cannot be found");
            }

            student.EnrollToLabs(jointTasks);
            await repository.Update(studentId, student);
            await repository.SaveChanges();
            return Result<Student>.SuccessNoEntity();
        }
    }
}
