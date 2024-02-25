using Aquality.WinAppDriver.Elements.Interfaces;
using ImTiredProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace ImTiredProject.PageObjects
{
    public class MainPage : BasePage
    {
        private readonly string CloseDontSaveLocator = "//*[@AutomationId='7']";
        private readonly string ToolbarPath = "//*[@ClassName='ToolbarWindow32']";

        private ITextBox DocumentTextBox => ElementFactory.GetTextBox(By.ClassName("Scintilla"), "Document text box");
        private ILabel Docbar => ElementFactory.GetLabel(By.Name("Tab"), "Docbar");
        private ReadOnlyCollection<AppiumWebElement> DocTabs => Docbar.GetElement().FindElementsByXPath("//*");
        private IButton NewFileButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[1]"), "New file button");
        private IButton CloseCurrentFileButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[5]"), "Close current file button");
        private IButton CloseAllFilesButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[6]"), "Close all files button");
        private IButton CutButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[8]"), "Cut button");
        private IButton CopyButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[9]"), "Copy button");
        private IButton PasteButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[10]"), "Paste button");
        private IButton BackButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[11]"), "Back button");
        private IButton ForwardButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[12]"), "Forward button");
        private IButton StartRecordButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[28]"), "Start record button");
        private IButton StopRecordingButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[29]"), "Stop recording button");
        private IButton PlayRecordButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[30]"), "Play record button");
        private IButton MultipleRunButton => ElementFactory.GetButton(By.XPath($"{ToolbarPath}/*[31]"), "Multiple run button");
        private IButton CloseButton => ElementFactory.GetButton(By.XPath("//*[@AutomationId='Close']"), "Close button");

        public MainPage() : base(By.ClassName("Scintilla"), "Main page")
        { }

        public void ChangeLanguage()
        {
            var testText = "q";
            DocumentTextFillIn(testText);
            var realText = GetDocumentText();
            ActionUtils.ChangeLenguage(testText, realText);
            SelectAllText();
            ClickBackspace();
        }

        public void DocumentTextFillIn(string text)
        {
            DocumentTextBox.SendKeys(text);
        }

        public string GetDocumentText()
        {
            return DocumentTextBox.Text;
        }

        public void SelectAllText()
        {
            DocumentTextBox.SendKeys(Keys.Control + "a");
        }

        public void ClickBackspace()
        {
            DocumentTextBox.SendKeys(Keys.Backspace);
        }

        public void ClickCut()
        {
            CutButton.Click();
        }

        public void ClickPaste()
        {
            PasteButton.Click();
        }

        public void ClickCopy()
        {
            CopyButton.Click();
        }

        public void ClickBackButton()
        {
            BackButton.Click();
        }

        public void ClickForwardButton()
        {
            ForwardButton.Click();
        }

        public void ClickOnRecord()
        {
            StartRecordButton.Click();
        }

        public bool IsStopRecordingButtonEnabled()
        {
            return StopRecordingButton.GetElement().Enabled;
        }

        public void ClickStopRecordingButton()
        {
            StopRecordingButton.Click();
        }

        public bool IsPlayButtonEnabled()
        {
            return PlayRecordButton.GetElement().Enabled;
        }

        public void ClickMultipleRunButton()
        {
            MultipleRunButton.Click();
        }

        public void ClickPlayButton()
        {
            PlayRecordButton.Click();
        }

        public void OpenFindForm()
        {
            SendKeys(Keys.Control + "f");
        }

        public void OpenDocument()
        {
            NewFileButton.Click();
        }

        public int GetDocumentCount()
        {
            return DocTabs.Count() - 1;
        }

        public void FillInAllDocumentsWithText(string text)
        {
            for (var i = 1; i < DocTabs.Count(); i++)
            {
                var tab = DocTabs[i];
                tab.Click();
                DocumentTextFillIn(text);
            }
        }

        public List<string> GetAllDocumentsText()
        {
            var result = new List<string>();
            
            for (var i = 1; i < DocTabs.Count(); i++)
            {
                var tab = DocTabs[i];
                tab.Click();
                result.Add(GetDocumentText());
            }

            return result;
        }

        public bool CloseNotificationIsOpen()
        {
            return ElementFactory.FindElements<IButton>(By.XPath(CloseDontSaveLocator), "").Count() > 0;
        }

        public void CloseApp()
        {
            CloseButton.Click();
        }

        public List<string> GetAllFileNames()
        {
            var result = new List<string>();

            for (var i = 1; i < DocTabs.Count(); i++)
            {
                var tab = DocTabs[i];
                result.Add(tab.GetAttribute("Name"));
            }

            return result;
        }

        public void SelectDocTabsByNumber(int number)
        {
            DocTabs[number].Click();
        }

        public void CloseCurrentDocument()
        {
            CloseCurrentFileButton.Click();
        }

        public void CloseAllDocuments()
        {
            CloseAllFilesButton.Click();
        }
    }
}
