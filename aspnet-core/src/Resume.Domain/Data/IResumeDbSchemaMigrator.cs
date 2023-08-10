using System.Threading.Tasks;

namespace Resume.Data;

public interface IResumeDbSchemaMigrator
{
    Task MigrateAsync();
}
