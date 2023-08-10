using Resume.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Resume.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ResumeController : AbpControllerBase
{
    protected ResumeController()
    {
        LocalizationResource = typeof(ResumeResource);
    }
}
