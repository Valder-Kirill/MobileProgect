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
                ConfirmAlertForm.CloseNotification(CloseNotificationOptions.CloseDontSave);
            }
            AqualityServices.Application.Quit();
        }
    }
}
