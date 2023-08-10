using Resume.Localization;
using Volo.Abp.Application.Services;

namespace Resume;

/* Inherit your application services from this class.
 */
public abstract class ResumeAppService : ApplicationService
{
    protected ResumeAppService()
    {
        LocalizationResource = typeof(ResumeResource);
    }
}
