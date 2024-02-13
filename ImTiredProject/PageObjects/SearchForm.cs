using Aquality.WinAppDriver.Elements.Interfaces;
using ImTiredProject.Utils;
using NUnit.Framework;
using OpenCvSharp;
using OpenQA.Selenium;

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
        {}

        public void FillInSearchTextBox(string text)
        {
            SearchTextBox.ClearAndType(text);
        }

        public void ClickSearchNextButton()
        {
            SearchNextButton.Click();
        }

        public void MessageWithTextIsExist(string variableName)
        {
            var outCompare = new Mat();
            var pic = ImagesUtils.CaptureElementScreenShot(ErrorMessageLabel().GetElement(), ImagesUtils.GetImageWay("baseSearchMessage"));
            pic.Save(ImagesUtils.GetImageWay("actualSearchMessage"));

            var referenceImage = new Mat(ImagesUtils.GetImageWay(variableName));
            referenceImage.ConvertTo(referenceImage, MatType.CV_32FC1);
            var actualImage = new Mat(ImagesUtils.GetImageWay("actualSearchMessage"));
            actualImage.ConvertTo(actualImage, MatType.CV_32FC1);

            Cv2.MatchTemplate(referenceImage, actualImage, outCompare, TemplateMatchModes.CCoeffNormed);
            Cv2.MinMaxLoc(outCompare, out double minCompRes, out _);

            Assert.That(minCompRes, Is.GreaterThan(0.8d));
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