using Volo.Abp.Settings;

namespace Resume.Settings;

public class ResumeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ResumeSettings.MySetting1));
    }
}
