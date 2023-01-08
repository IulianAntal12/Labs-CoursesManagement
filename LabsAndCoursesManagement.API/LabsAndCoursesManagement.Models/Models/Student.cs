namespace LabsAndCoursesManagement.Models.Models
{
    public class Student: TenantBase
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }

        public string FullName { get; protected set; }

        public string Email { get; private set; }

        public int Year { get; private set; }

        public string IdentificationNumber { get; private set; }

        public string Group { get; private set; }

        public List<Lab> Labs { get; private set; } = new List<Lab>();

        public void EnrollToLabs(List<Lab?> labs)
        {
            labs.ForEach(lab =>
            {
                if (lab != null)
                {
                    Labs.Add(lab);
                    lab.EnrollStudent(this);
                }

            });
        }
    }
}
