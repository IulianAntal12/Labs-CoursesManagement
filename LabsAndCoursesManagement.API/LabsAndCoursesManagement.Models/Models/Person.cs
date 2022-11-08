namespace LabsAndCoursesManagement.Models.Models
{
    public abstract class Person
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Surname { get;  protected set; }

        public string Gender { get; protected set; }
    }
}
