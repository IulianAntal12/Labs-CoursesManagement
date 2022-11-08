using ShelterManagement.Business;

namespace LabsAndCoursesManagement.Models.Models
{
    public class Student: Person
    {
        public int Year { get; private set; }

        public string IdentificationNumber { get; private set; }

        public string Group { get; private set; }


        public Result<Student> Create(string name, string surname, string gender, int year, string group)
        {
            if (!Enum.TryParse<PersonGender>(gender, out var personGender))
            {
                var expectedGenderValues = Enum.GetNames(typeof(PersonGender));
                var textExpectedGenderValues = string.Join(", ", expectedGenderValues);
                return Result<Student>.Failure($"The provided person gender '{gender}' is not one from the values: '{textExpectedGenderValues}'");
            }

            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                Gender = gender,
            };

            return Result<Student>.Success(student);
        }
    }
}
