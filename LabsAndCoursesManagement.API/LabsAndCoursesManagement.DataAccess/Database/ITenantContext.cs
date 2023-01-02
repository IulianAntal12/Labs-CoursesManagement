namespace LabsAndCoursesManagement.DataAccess.Database
{
    public interface ITenantContext
    {
        string CurrentTenant { get; set; }
    }
}