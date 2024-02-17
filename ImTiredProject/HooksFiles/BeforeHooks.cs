using Aquality.WinAppDriver.Applications;
using ImTiredProject.Utils;

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
            ActionUtils.ChangeLenguage();
        }
    }
}
