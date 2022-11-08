using Microsoft.VisualBasic;

namespace LabsAndCoursesManagement.Models.Models
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Year { get; private set; }

        public int Semester { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateInterval Duration { get; private set; } 

        public List<Student> Students { get; private set; }
    }
}
