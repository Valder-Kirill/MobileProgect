using Aquality.WinAppDriver.Elements.Interfaces;
using ImTiredProject.Models;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class SaveAlertForm : BasePage
    {
        private IButton SaveButton => ElementFactory.GetButton(By.XPath("//*[@AutomationId='6']"), "Save button");
        private IButton DontSaveAll => ElementFactory.GetButton(By.XPath("//*[@AutomationId='5']"), "Dont save all");
        private IButton DontSave => ElementFactory.GetButton(By.XPath("//*[@AutomationId='7']"), "Dont save");

        public SaveAlertForm() : base(By.Name("Сохранение ..."), "Save alert form")
        {}

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public void CloseNotification(string value)
        {
            switch (value)
            {
                case CloseNotificationOptions.DontSaveСurrent:
                    DontSave.Click();
                    break;

                case CloseNotificationOptions.DontSaveAll:
                    DontSaveAll.Click();
                    break;

                case CloseNotificationOptions.CloseDontSave:
                    if (new MainPage().GetAllFileNames().Count > 1)
                    {
                        DontSaveAll.Click();
                    }
                    else
                    {
                        DontSave.Click();
                    } 
                    break;
            }
        }
    }
}
