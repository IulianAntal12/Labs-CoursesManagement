namespace LabsAndCoursesManagement.Models.Models
{
    public class Student: Person
    {
        public int Year { get; private set; }

        public string IdentificationNumber { get; private set; }

        public string Group { get; private set; }


        //public Result<Student> Create(string name, string surname, string gender, int year, string group)
        //{
           
        //}
    }
}
