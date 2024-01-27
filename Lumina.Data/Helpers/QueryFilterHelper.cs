using Lumina.Data.Extentions;
using Lumina.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Data.Helpers;
public class QueryFilterHelper
{
    public static void AddQueryFilters(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Auditable).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).AddQueryFilter<Auditable>(e => e.IsDeleted == false);
        }
    }
}
