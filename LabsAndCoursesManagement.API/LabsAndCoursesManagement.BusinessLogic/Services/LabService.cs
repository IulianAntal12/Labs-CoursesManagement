using FluentValidation;
using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Services.Validators;
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

        public LabService(IRepository<Lab> repository, IRepository<Teacher> teacherRepository, IValidator<Lab?> validator) 
            : base(repository, validator)
        {
            this.teacherRepository = teacherRepository;
        }

        public new async Task<Result<Lab>> Update(Guid id, CreateLabDto dto)
        {
            var entity = mapper.Map<Lab>(dto);
            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return Result<Lab>.Failure(HttpStatusCode.UnprocessableEntity, validationResult.Errors[0].ErrorMessage);
            }

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
