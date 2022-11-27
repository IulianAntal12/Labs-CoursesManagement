namespace LabsAndCoursesManagement.Models.Dtos
{
    public class CreateStudentDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public int Year { get; set; }

        public string IdentificationNumber { get; set; }

        public string Group { get; set; }
    }
}
