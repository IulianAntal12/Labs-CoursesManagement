namespace LabsAndCoursesManagement.WebAPI.Dtos;

public class UserDTO
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
}