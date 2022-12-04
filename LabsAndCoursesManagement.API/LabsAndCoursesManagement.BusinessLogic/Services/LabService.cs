using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using System.Net;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public class LabService : BaseService<Lab, CreateLabDto>, ILabService
    {
        private readonly IRepository<Teacher> teacherRepository;

        public LabService(IRepository<Lab> repository, IRepository<Teacher> teacherRepository) : base(repository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<Result<Lab>> Update(Guid id, CreateLabDto dto)
        {
            var entity = mapper.Map<Lab>(dto);

            var teacher = await teacherRepository.Get(entity.TeacherId);
            if (teacher == null)
            {
                return Result<Lab>.Failure(HttpStatusCode.UnprocessableEntity, "Cannot find teacher specified by id");
            }

            var response = await repository.Update(id, entity);
            if (response == null)
            {
                return Result<Lab>.Failure(HttpStatusCode.NotFound, "Cannot find entity specified by id");
            }
            return Result<Lab>.Success(response);
        }

    }
}
