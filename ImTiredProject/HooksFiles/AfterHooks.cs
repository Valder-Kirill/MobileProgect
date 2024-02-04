using Aquality.WinAppDriver.Applications;
using ImTiredProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class AfterHooks : BaseHooks
    {
        [AfterScenario]
        public void CloseApp()
        {
            AqualityServices.Application.Quit();
            MainPage.CloseNotification(CloseNotificationOptions.CloseAllDontSave);
        }
    }
}
