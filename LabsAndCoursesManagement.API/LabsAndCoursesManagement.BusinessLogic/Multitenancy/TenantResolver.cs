using Newtonsoft.Json;

namespace LabsAndCoursesManagement.BusinessLogic.Multitenancy
{
    public static class TenantResolver
    {
        private static List<TenantSettings> tenants;

        static TenantResolver()
        {
            var tenantSettingsContent = File.ReadAllText("tenantsettings.json");
            tenants = JsonConvert.DeserializeObject<List<TenantSettings>>(tenantSettingsContent);
        }

        public static TenantSettings GetByTenantName(string tenantName)
        {
            return tenants.FirstOrDefault(t => t.Name == tenantName, null);
        }
    }
}
