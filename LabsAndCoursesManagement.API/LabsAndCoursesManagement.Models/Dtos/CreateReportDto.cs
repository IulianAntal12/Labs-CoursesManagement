namespace LabsAndCoursesManagement.Models.Dtos
{
    public class CreateReportDto
    {
        public Guid StudentId { get; private set; }

        public Guid TeacherId { get; private set; }

        public double Value { get; private set; }

        public string EvaluationType { get; private set; }

        public DateTime EvaluationDate { get; private set; }
    }
}
