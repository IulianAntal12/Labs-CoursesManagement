using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Services
{
    public class TeacherService : BaseService<Teacher, CreateTeacherDto>, ITeacherService
    {
        private readonly IRepository<Lab> labRepository;

        public TeacherService(IRepository<Teacher> repository, IRepository<Lab> labRepository) : base(repository)
        {
            this.labRepository = labRepository;
        }

        public async Task<Result<Teacher>> EnrollTeacherToLabs(Guid teacherId, List<Guid> labIds)
        {
            var labTasks = labIds
                .Select(async(labId) => await labRepository.Get(labId))
                .ToList();

            var jointTasks = (await Task.WhenAll(labTasks))
                .ToList();

            if (jointTasks.Any(lab => lab == null)) 
            {
                return Result<Teacher>.Failure("Cannot enroll teacher to the specified labs");
            }
            
            var teacher = await repository.Get(teacherId);
            if (teacher == null) 
            {
                return Result<Teacher>.Failure("Teacher with specified id cannot be found");
            }

            teacher.EnrollToLabs(jointTasks);
            await repository.Update(teacherId, teacher);
            await repository.SaveChanges();
            return Result<Teacher>.SuccessNoEntity();
        }

        public void Update()
        {

        }
    }
}
