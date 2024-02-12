using Aquality.WinAppDriver.Applications;
using ImTiredProject.Models;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class AfterHooks : BaseHooks
    {
        [AfterScenario]
        public void CloseApp()
        {
            MainPage.CloseAllDocuments();
            if (MainPage.CloseNotificationIsOpen())
            {
                MainPage.CloseNotification(CloseNotificationOptions.CloseAllDontSave);
            }
            AqualityServices.Application.Quit();
        }
    }
}
