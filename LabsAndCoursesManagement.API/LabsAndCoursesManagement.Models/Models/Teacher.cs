namespace LabsAndCoursesManagement.Models.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
        public string FullName { get; protected set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Cabinet { get; private set; }
        public List<Lab> Labs { get; private set; } = new List<Lab>();

        public void EnrollToLabs(List<Lab> labs)
        {
            labs.ForEach(lab =>
            {
                Labs.Append(lab);
                lab.EnrollTeacher(this);
            });
        }

        public Result<Teacher> Validate()
        {
            if (FullName == null)
            {
                return Result<Teacher>.Failure("Name must not be null");
            } 
            return Result<Teacher>.Success(this);
       }
    }
}
