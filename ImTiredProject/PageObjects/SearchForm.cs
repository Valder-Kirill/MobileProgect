using AppiumTestProject.Utils;
using Aquality.WinAppDriver.Elements.Interfaces;
using ImTiredProject.Utils;
using NUnit.Framework;
using OpenCvSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow.Analytics;

namespace ImTiredProject.PageObjects
{
    public class SearchForm : BasePage
    {
        private ITextBox SearchTextBox => ElementFactory.GetTextBox(Locator, Text);
        private IButton SearchNextButton => ElementFactory.GetButton(By.XPath("//*[@AutomationId='1']"), "Search next");
        private ILabel ErrorMessageLabel() => ElementFactory.GetLabel(By.XPath($"//*[@ClassName='msctls_statusbar32']"), Text);
        private IButton ReplacementTab => ElementFactory.GetButton(By.XPath($"//*[@Name='Замена']"), Text);
        private ITextBox ReplaceTextBox => ElementFactory.GetTextBox(By.XPath($"//*[@Name='Заменить на:'][2]"), Text);
        private IButton ReplaceAllButton => ElementFactory.GetButton(By.XPath($"//*[@Name='Заменить']"), Text);
        private IButton ReplaceInAllDocumentsButton => ElementFactory.GetButton(By.XPath($"//*[contains(@Name,'Заменить все во Всех')]"), Text);
        private IButton CloseButton => ElementFactory.GetButton(By.XPath($"//*[@Name='Закрыть']"), Text);
        private IButton MatchCaseCheckBox => ElementFactory.GetButton(By.XPath($"//*[@AutomationId='1724']"), Text);

        public SearchForm() : base(By.XPath("//*[@AutomationId='1001']"), "Search text box")
        {
        }

        public void FillInSearchTextBox(string text)
        {
            SearchTextBox.ClearAndType(text);
        }

        public void ClickSearchNextButton()
        {
            SearchNextButton.Click();
        }

        public void ErrorTextIsExist(string variableName)
        {
            Mat outCompare = new Mat();
            double minCompRes;

            var pic = CaptureElementScreenShot(ErrorMessageLabel().GetElement(), "Base", ImagesUtils.GetImageWay("baseSearchMessage"));
            pic.Save(ImagesUtils.GetImageWay("actualSearchMessage"));

            var referenceImage = new Mat(ImagesUtils.GetImageWay(variableName));
            referenceImage.ConvertTo(referenceImage, MatType.CV_32FC1);
            var actualImage = new Mat(ImagesUtils.GetImageWay("actualSearchMessage"));
            actualImage.ConvertTo(actualImage, MatType.CV_32FC1);

            Cv2.MatchTemplate(referenceImage, actualImage, outCompare, TemplateMatchModes.CCoeffNormed);
            Cv2.MinMaxLoc(outCompare, out minCompRes, out _);

            Assert.That(minCompRes, Is.GreaterThan(0.8d));
        }

        /// <summary>
        /// Captures the element screen shot.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>returns the screenshot  image </returns>
        public Image CaptureElementScreenShot(AppiumWebElement element, string uniqueName, string filename)
        {
            Bitmap printscreen = new Bitmap(1920, 1080);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(1920, 1080));

            printscreen.Save(filename);

            Image img = Bitmap.FromFile(filename);
            Rectangle rect = new Rectangle();

            if (element != null)
            {
                int width = element.Size.Width;
                int height = element.Size.Height;
                System.Drawing.Point p = element.Location;
                rect = new Rectangle(p.X, p.Y, width, height);
            }

            Bitmap bmpImage = new Bitmap(img);
            var cropedImag = bmpImage.Clone(rect, bmpImage.PixelFormat);

            return cropedImag;
        }

        public void GoToReplacementTab()
        {
            ReplacementTab.Click();
        }

        public void FillTheSearchFieldWithText(string text)
        {
            SearchTextBox.ClearAndType(text);
        }

        public void FillTheReplaceFieldWithText(string text)
        {
            ReplaceTextBox.ClearAndType(text);
        }

        public void ClickReplaceAllButton()
        {
            ReplaceAllButton.Click();
        }

        public void ClickReplaceInAllDocumentsButton()
        {
            ReplaceInAllDocumentsButton.Click();
        }

        public void MatchCaseCheckBoxActivate()
        {
            MatchCaseCheckBox.Click();
        }

        public void Close()
        {
            CloseButton.Click();
        }
    }
}