using ShelterManagement.Business;

namespace LabsAndCoursesManagement.Models.Models
{
    public class Report
    {

        public Guid TenantId { get; private set; }

        public Guid StudentId { get; private set; }

        public Guid TeacherId { get; private set; }

        public double Value { get; private set; }

        public string EvaluationType { get; private set; }

        public Result<Report> Create(Guid studentId, Guid teacherId, double value, string evaluationType)
        {
            if (!Enum.TryParse<PersonGender>(gender, out var personGender))
            {
                var expectedGenderValues = Enum.GetNames(typeof(PersonGender));
                var textExpectedGenderValues = string.Join(", ", expectedGenderValues);
                return Result<Person>.Failure($"The provided person gender '{gender}' is not one from the values: '{textExpectedGenderValues}'");
            }
        }
    }
}
