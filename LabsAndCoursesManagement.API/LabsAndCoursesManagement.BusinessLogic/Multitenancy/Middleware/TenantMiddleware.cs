using LabsAndCoursesManagement.DataAccess.Database;
using Microsoft.AspNetCore.Http;

namespace LabsAndCoursesManagement.BusinessLogic.Multitenancy.Middleware
{
    internal class TenantMiddleware : IMiddleware
    {
        private readonly ITenantContext tenantContext;

        public TenantMiddleware(ITenantContext tenantContext)
        {
            this.tenantContext = tenantContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //var request = context.Request;
            //if (!string.IsNullOrEmpty(request.ContentType) && request.ContentType.StartsWith("application/json"))
            //{
            //    tenantContext.CurrentTenant = request.Headers["Tenant"].ToString();
            //}
            tenantContext.CurrentTenant = TenantResolver.GetCurrentTenant().Name;
            await next(context);
        }
    }
}
