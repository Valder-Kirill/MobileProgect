using Aquality.WinAppDriver.Elements.Interfaces;
using Aquality.WinAppDriver.Forms;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class BasePage : Form
    {
        private IElement element(By locator, string pageName) => ElementFactory.GetLabel(locator, pageName);

        public BasePage(By Locator, string PageName) : base(Locator, PageName)
        {
            element(Locator, PageName);
        }
    }
}
