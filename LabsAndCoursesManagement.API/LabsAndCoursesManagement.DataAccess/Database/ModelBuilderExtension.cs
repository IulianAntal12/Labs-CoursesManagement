using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public static class ModelBuilderExtension
    {
        public static void ApplyGlobalFilters<TClass>(this ModelBuilder modelBuilder, Expression<Func<TClass, bool>> expression)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.BaseType == typeof(TClass))
                .Select(e => e.ClrType);
                
            foreach (var entity in entities)
            {
                var newParam = Expression.Parameter(entity);
                var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
            }
        }
    }
}
