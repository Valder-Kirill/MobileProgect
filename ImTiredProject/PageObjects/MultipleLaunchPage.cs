using Aquality.WinAppDriver.Elements.Interfaces;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class MultipleLaunchPage : BasePage
    {
        private ITextBox CountTextBox => ElementFactory.GetTextBox(By.XPath("//*[@AutomationId='8003']"), "Count text box");
        private IButton StartButton => ElementFactory.GetButton(By.Name("Запуск"), "Start Button");
        private IButton CloseButton => ElementFactory.GetButton(By.Name("Закрыть"), "Close Button");

        public MultipleLaunchPage() : base(By.Name("Многократный запуск ..."), "Main page")
        {}

        public void DocumentTextFillIn(string text)
        {
            CountTextBox.ClearAndType(text);
            StartButton.Click();
            CloseButton.Click();
        }
    }
}
