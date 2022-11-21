namespace LabsAndCoursesManagement.Models.Dtos
{
    public class CreateLabDto
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }
    }
}
