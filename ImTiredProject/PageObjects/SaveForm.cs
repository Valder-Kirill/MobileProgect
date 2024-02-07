using Aquality.WinAppDriver.Elements.Interfaces;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class SaveForm : BasePage
    {
        private IButton SaveButton => ElementFactory.GetButton(By.XPath("//*[@AutomationId='1']"), "Save button");
        private ITextBox WayTextBox => ElementFactory.GetTextBox(By.XPath("//*[@ClassName='Breadcrumb Parent']"), "WayTextBox");
        private ITextBox FileNameTextBox => ElementFactory.GetTextBox(By.XPath("//*[@ClassName='Edit']"), "FileNameTextBox");

        public SaveForm() : base(By.XPath("//*[@AutomationId='1001']"), "Search text box")
        {
        }

        public void SaveFile(string way, string name)
        {
            WayTextBox.SendKeys(way);
            FileNameTextBox.SendKeys(name);
            SaveButton.Click();
        }
    }
}
