using NUnitDesctop.HooksFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImTiredProject.HooksFiles
{
    [Binding]
    public class SaveFormHooks : BaseHooks
    {
        [When(@"save document")]
        public void WhenSaveDocument()
        {
            SaveForm.SaveFile("C:\\Users\\emely\\OneDrive\\Рабочий стол", "Aboba");
        }
    }
}
