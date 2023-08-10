using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Resume;

[Dependency(ReplaceServices = true)]
public class ResumeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Resume";
}
