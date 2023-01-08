namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class TenantContext : ITenantContext
    {
        private string[] values;
        public TenantContext()
        {
            values = new string[] { "test", "value", "incoming" };
        }

        public string CurrentTenant { get; set; }
    }
}
