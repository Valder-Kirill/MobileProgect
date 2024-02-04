using Aquality.WinAppDriver.Applications;

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
        }
    }
}
