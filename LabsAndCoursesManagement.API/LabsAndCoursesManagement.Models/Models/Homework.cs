namespace LabsAndCoursesManagement.Models.Models
{
    public class Homework
    {
        public Guid Id { get; private set; }

        public double Value { get; private set; }
        public string Description { get; private set; }
        public double Bonus { get; private set; }
    }
}
