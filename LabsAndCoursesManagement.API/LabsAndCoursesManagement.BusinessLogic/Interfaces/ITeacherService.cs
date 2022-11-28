﻿using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.Models.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher, CreateTeacherDto>
    {
        Task<Result<Teacher>> EnrollTeacherToLabs(Guid teacherId, List<Guid> labIds);
    }
}