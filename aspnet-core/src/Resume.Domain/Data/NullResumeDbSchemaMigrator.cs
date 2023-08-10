using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Resume.Data;

/* This is used if database provider does't define
 * IResumeDbSchemaMigrator implementation.
 */
public class NullResumeDbSchemaMigrator : IResumeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
