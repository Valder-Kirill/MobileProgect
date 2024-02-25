using NUnitDesctop.HooksFiles;
using TechTalk.SpecFlow;

namespace ImTiredProject.HooksFiles
{
    [Binding]
    public class AlertFormHooks : BaseHooks
    {
        [When(@"select save in close documents alert")]
        public void WhenSelectSaveInCloseDocumentsAlert()
        {
            ConfirmAlertForm.ClickSaveButton();
        }
    }
}
