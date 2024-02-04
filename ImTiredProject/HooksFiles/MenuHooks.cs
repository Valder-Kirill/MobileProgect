using AppiumTestProject.Utils;
using ImTiredProject.Models;
using NUnit.Framework;
using OpenCvSharp.Text;
using System.Text;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace NUnitDesctop.HooksFiles
{
    [Binding]
    public class MenuHooks : BaseHooks
    {
        [When(@"open find form")]
        public void OpenFindForm()
        {
            MainPage.OpenFindForm();
        }

        [When(@"open '([^']*)' documents")]
        public void WhenOpenDocument(int count)
        {
            for(int i = 0; i < count; i++) 
            {
                MainPage.OpenDocument();
            }
        }

        [Then(@"'([^']*)' documents open")]
        public void ThenDocumentsOpen(int count)
        {
            var actualCount = MainPage.GetDocumentCount();
            Assert.That(actualCount, Is.EqualTo(count));
        }

        [When(@"fill in all documents with text '([^']*)'")]
        public void WhenFillInAllDocumentsWithText(string text)
        {
            MainPage.FillInAllDocumentsWithText(text);
        }

        [Then(@"all documents are filled with '([^']*)'")]
        public void ThenAllDocumentsAreFilledWith(string text)
        {
            var docTexts = MainPage.GetAllDocumentsText();

            foreach(var docText in docTexts)
            {
                Assert.That(docText, Is.EqualTo(text));
            }
        }

        [Then(@"all documents have default names")]
        public void ThenAllDocumentsHaveDefaultNames()
        {
            var fileNames = MainPage.GetAllFileNames();
            var defoultName = ConfigUtils.GetAndroidConfig(ConfigNodes.DefaultDocName);

            Assert.That(fileNames.Count() > 0, "Проверка, что кол-во имен файлов не равно нулю");

            for(var i = 1; i < fileNames.Count() + 1; i++)
            {
                Assert.That(defoultName + $"{i}", Is.EqualTo(fileNames[i-1]), $"Проверяем имя {i}-ого файла");
            }
        }

        [When(@"go to document numer '([^']*)'")]
        public void WhenGoToDocumentNumer(int number)
        {
            MainPage.SelectDocTabsByNumber(number);
        }

    }
}
