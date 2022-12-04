namespace LabsAndCoursesManagement.WebAPI.Dtos;

public class UserRegistrationDTO
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public string Group { get; set; }

    public string Year { get; set; }
}