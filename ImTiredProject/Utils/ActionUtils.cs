using Aquality.WinAppDriver.Applications;
using ImTiredProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ImTiredProject.Utils
{
    public static class ActionUtils
    {
        private static readonly Actions Actions = new(AqualityServices.Application.Driver);

        public static void MaximazeWindow()
        {
            Actions.SendKeys(Keys.Command + Keys.ArrowUp + Keys.Command);
            Actions.Perform();
        }

        public static void ChangeLenguage()
        {
            var mainPage = new MainPage();
            mainPage.DocumentTextFillIn("q");
            var text = mainPage.GetDocumentText();
            if (text != "q")
            {
                Actions.SendKeys(Keys.LeftAlt + Keys.LeftShift + Keys.LeftAlt);
                Actions.Perform();
            }
            mainPage.SelectAllText();
            mainPage.ClickBackspace();
        }
    }
}