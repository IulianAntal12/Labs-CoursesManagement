namespace LabsAndCoursesManagement.Models.Models
{
    public class Teacher: Person
    {
        public string Role { get; private set; }

        public string PhoneNumber { get; private set; } 

        public string Email { get; private set; }

        public string Cabinet { get; private set; }

        //public Result<Teacher> Create(string name, string surname, string gender, string role,
        //    string phoneNumber, string email, string cabinet)
        //{

        //}
    }
}
