using ImTiredProject.PageObjects;

namespace NUnitDesctop.HooksFiles
{
    public class BaseHooks
    {
        protected static MainPage MainPage => new();
        protected static MultipleLaunchPage MultipleLaunchPage => new();
        protected static SearchForm SearchForm => new();
        protected static SaveAlertForm ConfirmAlertForm => new();
    }
}
