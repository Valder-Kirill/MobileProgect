using ImTiredProject.PageObjects;

namespace NUnitDesctop.HooksFiles
{
    public class BaseHooks
    {
        protected MainPage MainPage => new MainPage();
        protected MultipleLaunchPage MultipleLaunchPage => new MultipleLaunchPage();
        protected SearchForm SearchForm => new SearchForm();
        protected ConfirmAlertForm ConfirmAlertForm => new ConfirmAlertForm();
        protected SaveForm SaveForm => new SaveForm();
    }
}
