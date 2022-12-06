namespace LabsAndCoursesManagement.Models.Models
{
    public class Report
    {

        public Guid TenantId { get; private set; }

        public Guid StudentId { get; private set; }

        public Guid TeacherId { get; private set; }

        public double Value { get; private set; }

        public string EvaluationType { get; private set; }

    }
}
