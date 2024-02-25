using Aquality.WinAppDriver.Applications;
using ImTiredProject.Utils;
using TechTalk.SpecFlow;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class BeforeHooks : BaseHooks
    {
        [BeforeScenario]
        public void OpenApp()
        {
            AqualityServices.WinAppDriverLauncher.StartWinAppDriverIfRequired();
            AqualityServices.Application.Launch();
            ActionUtils.MaximazeWindow();
            MainPage.ChangeLanguage();
        }
    }
}
