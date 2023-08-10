using Resume.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Resume;

[DependsOn(
    typeof(ResumeEntityFrameworkCoreTestModule)
    )]
public class ResumeDomainTestModule : AbpModule
{

}
