using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class TextActionHooks : BaseHooks
    {
        [When(@"select all the text")]
        public void WhenSelectAllTheText()
        {
            MainPage.SelectAllText();
        }

        [When(@"fill in the document with '(.*)'")]
        public void WhenFillInTheDocumentWith(string text)
        {
            MainPage.DocumentTextFillIn(text);
        }

        [Then(@"is the document fill in '(.*)'")]
        public void ThenIsTheDocumentFillIn(string expText)
        {
            string curText = MainPage.GetDocumentText();
            Assert.That(expText, Is.EqualTo(curText));
        }

        [When(@"press the forward button")]
        public void PressTheForwardButton()
        {
            MainPage.ClickForwardButton();
        }

        [When(@"clear document")]
        public void ClearDocument()
        {
            MainPage.SelectAllText();
            MainPage.ClickBackspace();
        }

        [When(@"click copy button")]
        public void ClickCopy()
        {
            MainPage.ClickCopy();
        }

        [When(@"click on the record button")]
        public void ClickOnTheRecordButton()
        {
            MainPage.ClickOnRecord();
        }

        [Then(@"the stop Recording button has become active")]
        public void TheStopRecordingButtonHasBecomeActive()
        {
            Assert.That(MainPage.IsStopRecordingButtonEnabled(), "Stop Recording button in not active!");
        }

        [When(@"click on the stop recording button")]
        public void ClickOnTheStopRecordingButton()
        {
            MainPage.ClickStopRecordingButton();
        }

        [Then(@"the play button has become active")]
        public void ThePlayButtonHasBecomeActive()
        {
            Assert.That(MainPage.IsPlayButtonEnabled(), "Play button in not active!");
        }

        [When(@"click on the play button")]
        public void ClickOnThePlayButton()
        {
            MainPage.ClickPlayButton();
        }

        [When(@"press the multiple run button and run 2 times")]
        public void PressTheMultipleRunButtonAndRunSeveralTimes()
        {
            MainPage.ClickMultipleRunButton();
            MultipleLaunchPage.DocumentTextFillIn("2");
        }
    }
}
