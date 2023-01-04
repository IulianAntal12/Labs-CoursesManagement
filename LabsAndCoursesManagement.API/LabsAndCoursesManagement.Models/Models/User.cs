namespace LabsAndCoursesManagement.Models.Models;

public class User: TenantBase
{
    public Guid ID { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public string FullName { get; private set; }

    public string Group { get; private set; }

    public string Year { get; private set; }

    public Guid StudentID { get; private set; }

    public Teacher Student { get; private set; }

}