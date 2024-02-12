using Aquality.WinAppDriver.Elements.Interfaces;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class ConfirmAlertForm : BasePage
    {
        private IButton SaveButton => ElementFactory.GetButton(By.XPath("//*[@AutomationId='6']"), "Count text box");

        public ConfirmAlertForm() : base(By.Name("Сохранение ..."), "ConfirmAlertForm")
        {
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
    }
}
