using Resume.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Resume.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ResumeEntityFrameworkCoreModule),
    typeof(ResumeApplicationContractsModule)
)]
public class ResumeDbMigratorModule : AbpModule
{
}
