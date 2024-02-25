using Aquality.WinAppDriver.Applications;
using ImTiredProject.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class SearchFormHooks : BaseHooks
    {
        [When(@"paste the text '(.*)' and click next")]
        public void PasteTheTextAndClickNext(string text)
        {
            SearchForm.FillInSearchTextBox(text);
            SearchForm.ClickSearchNextButton();
        }

        [Then(@"the message with text should appear - '(.*)'")]
        public void TheErrorWithTextShouldAppear(string messageText)
        {
            SearchForm.MessageWithTextIsExist(messageText);
        }

        [When(@"go to replacement tab")]
        public void GoToReplacementTab()
        {
            SearchForm.GoToReplacementTab();
        }

        [When(@"fill the search field with text '(.*)'")]
        public void FillTheSearchFieldWithText(string text)
        {
            SearchForm.FillTheSearchFieldWithText(text);
        }

        [When(@"fill the search field with text '([^']*)', but without a capital letter at the beginning")]
        public void WhenFillTheSearchFieldWithTextButWithoutACapitalLetterAtTheBeginning(string text)
        {
            SearchForm.FillTheSearchFieldWithText(text.ToLower());
        }

        [When(@"fill the replace field with text '(.*)'")]
        public void FillTheReplaceFieldWithText(string text)
        {
            SearchForm.FillTheReplaceFieldWithText(text);
        }

        [When(@"click replace all button")]
        public void ClickReplaceAllButton()
        {
            SearchForm.ClickReplaceAllButton();
        }

        [When(@"click replace in all documents button")]
        public void WhenClickReplaceInAllDocumentsButton()
        {
            SearchForm.ClickReplaceInAllDocumentsButton();
        }

        [When(@"press ok in confirm button")]
        public void WhenPressOkInConfirmButton()
        {
            AqualityServices.KeyboardActions.SendKeys(Keys.ArrowLeft + Keys.Enter);
        }

        [When(@"deactivate Match case checkbox")]
        [When(@"activate Match case checkbox")]
        public void ActivateMatchCaseCheckBox()
        {
            SearchForm.MatchCaseCheckBoxActivate();
        }

        [When(@"close find form")]
        public void WhenCloseFindForm()
        {
            SearchForm.Close();
        }
    }
}
