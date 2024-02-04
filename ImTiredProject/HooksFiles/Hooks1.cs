using Aquality.WinAppDriver.Applications;
using TechTalk.SpecFlow;
using NUnit;
using NUnit.Framework;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class Hooks1 : BaseHooks
    {
        [Given(@"app is open")]
        public void GivenAppIsOpen()
        {
            
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
    }
}