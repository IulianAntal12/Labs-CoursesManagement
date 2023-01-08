using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.Models.Dtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

    }
}
