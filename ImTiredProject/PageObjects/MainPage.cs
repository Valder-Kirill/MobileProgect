using Aquality.WinAppDriver.Applications;
using Aquality.WinAppDriver.Elements.Interfaces;
using ImTiredProject.Models;
using Microsoft.VisualBasic;
using NUnit.Framework.Interfaces;
using OpenCvSharp.Internal.Vectors;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.ObjectModel;
//using System.Windows.Forms;


namespace ImTiredProject.PageObjects
{
    public class MainPage : BasePage
    {
        private ITextBox DocumentTextBox => ElementFactory.GetTextBox(By.ClassName("Scintilla"), "Document text box");
        private ILabel Docbar => ElementFactory.GetLabel(By.Name("Tab"), "Find Drop Down");
        private ReadOnlyCollection<AppiumWebElement> DocTabs => Docbar.GetElement().FindElementsByXPath("//*");
        private IButton NewFileButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[1]"), "Cut button");
        private IButton CutButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[8]"), "Cut button");
        private IButton CopyButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[9]"), "Copy button");
        private IButton PasteButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[10]"), "Paste button");
        private IButton BackButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[11]"), "Back button");
        private IButton ForwardButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[12]"), "Forward button");
        private IButton RecordButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[28]"), "Record button");
        private IButton StopRecordingButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[29]"), "Stop recording button");
        private IButton PlayButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[30]"), "Play button");
        private IButton MultipleRunButton => ElementFactory.GetButton(By.XPath("//*[@ClassName='ToolbarWindow32']/*[31]"), "Multiple run button");
        private IButton CloseAllDontSave => ElementFactory.GetButton(By.XPath("//*[@AutomationId='5']"), "Count text box");
        private IButton CloseDontSave => ElementFactory.GetButton(By.XPath("//*[@AutomationId='7']"), "Count text box");
        private IButton FindDropDown => ElementFactory.GetButton(By.Name("Поиск"), "Find Drop Down");
        private IButton FindButton => ElementFactory.GetButton(By.Name("Найти..."), "Find button");

        public MainPage() : base(By.ClassName("Scintilla"), "Main page")
        {
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

        public void SelectFirstWord()
        {
            var text = DocumentTextBox.Text;
        }

        public void ClickOnRecord()
        {
            RecordButton.Click();
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
            return PlayButton.GetElement().Enabled;
        }

        public void ClickMultipleRunButton()
        {
            MultipleRunButton.Click();
        }

        public void ClickPlayButton()
        {
            PlayButton.Click();
        }

        public void OpenFindForm()
        {
            SendKeys(Keys.LeftControl + "f");
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
            for(var i = 1; i < DocTabs.Count(); i++)
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

        public void CloseNotification(string value)
        {
            switch(value)
            {
                case CloseNotificationOptions.CloseAllDontSave:
                    try
                    {
                        CloseAllDontSave.Click();

                    }
                    catch
                    {
                        CloseDontSave.Click();

                    }
                    break;
            }
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
    }
}
