namespace LabsAndCoursesManagement.Models.Models
{
    public class Course: TenantBase
    {
        public Guid Id { get; private set; }
       
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Year { get; private set; }

        public int Semester { get; private set; }

    }
}
