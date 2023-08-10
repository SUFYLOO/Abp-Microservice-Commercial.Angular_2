using Volo.Abp.Modularity;

namespace Resume;

[DependsOn(
    typeof(ResumeApplicationModule),
    typeof(ResumeDomainTestModule)
    )]
public class ResumeApplicationTestModule : AbpModule
{

}
