using Aquality.WinAppDriver.Applications;
using ImTiredProject.Models;
using TechTalk.SpecFlow;

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
                ConfirmAlertForm.CloseNotification(CloseNotificationOptions.CloseDontSave);
            }
            AqualityServices.Application.Quit();
        }
    }
}
