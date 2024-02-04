using Aquality.WinAppDriver.Forms;
using OpenQA.Selenium;

namespace ImTiredProject.PageObjects
{
    public class BasePage : Form
    {
        public BasePage(By Locator, string PageName) : base(Locator, PageName)
        {}
    }
}
